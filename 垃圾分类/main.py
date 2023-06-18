import sys
from PyQt5 import QtWidgets, uic
from PyQt5.QtGui import QPixmap
from PyQt5.QtWidgets import QFileDialog
from PyQt5.QtCore import QThread, pyqtSignal
from PyQt5.QtCore import Qt
import torch
from PIL import Image
import numpy as np

import cn_clip.clip as clip
from cn_clip.clip import load_from_name, available_models
from info import recyclable, hazardous, wet, dry, others, others_dict, combined

# 创建一个新的线程类
class ClassificationThread(QThread):
    signal = pyqtSignal(str)

    def __init__(self, image, classify_func):
        QThread.__init__(self)
        self.image = image
        self.classify_func = classify_func

    def run(self):
        result = self.classify_func(self.image)
        self.signal.emit(result)


class ImageClassificationApp(QtWidgets.QMainWindow):
    def __init__(self):
        super(ImageClassificationApp, self).__init__()
        uic.loadUi('ui/image_upload.ui', self)

        # 获取按钮和QLabel
        self.upload_button = self.findChild(QtWidgets.QPushButton, 'upload')
        self.img_show = self.findChild(QtWidgets.QLabel, 'img_show')
        self.msg_show = self.findChild(QtWidgets.QLabel, 'msg_show')

        # 绑定上传图片按钮的点击事件
        self.upload_button.clicked.connect(self.upload_image)
        self.show()

        # 深度学习模型导入
        self.device = "cuda" if torch.cuda.is_available() else "cpu"
        self.model, self.preprocess = load_from_name("ViT-B-16", device=self.device, download_root='./')
        self.model.eval()
        self.text = clip.tokenize(combined).to(self.device)

    def upload_image(self):
        fname, _ = QFileDialog.getOpenFileName(self, 'Open file', './')
        if fname:
            pixmap = QPixmap(fname)
            # 缩放图片以适应标签，保持长宽比
            pixmap = pixmap.scaled(self.img_show.width(), self.img_show.height(), Qt.KeepAspectRatio)
            self.img_show.setPixmap(pixmap)  # 设置图片

            self.msg_show.setText('正在分类...')
            image = self.preprocess(Image.open(fname)).unsqueeze(0).to(self.device)

            # 调用深度学习模型进行分类
            self.thread = ClassificationThread(image, self.classify)
            self.thread.signal.connect(self.update_msg)
            self.thread.start()

    def update_msg(self, result):
        self.msg_show.setText(result)  # 设置分类结果

    def classify(self, img):
        with torch.no_grad():
            image_features = self.model.encode_image(img)
            text_features = self.model.encode_text(self.text)
            # 对特征进行归一化，请使用归一化后的图文特征用于下游任务
            image_features /= image_features.norm(dim=-1, keepdim=True)
            text_features /= text_features.norm(dim=-1, keepdim=True)

            logits_per_image, logits_per_text = self.model.get_similarity(img, self.text)
            probs = logits_per_image.softmax(dim=-1).cpu().numpy()

        # 获取具有前3个最高概率的类的索引
        top3_indices = np.argsort(-probs[0])[:3]

        # 获取具有前3个最高概率的类标签
        top3_classes = [combined[i] for i in top3_indices]

        # 获取前3个概率值
        top3_probs = probs[0][top3_indices]

        print("前3个类别:", top3_classes)
        print("前3个概率:", top3_probs)

        # 它们属于哪个类别
        categories = {"可回收物": recyclable, "有害物": hazardous, "湿垃圾": wet, "干垃圾": dry, "其他": others}
        msg = ''
        for i in range(3):
            prob, cls = top3_probs[i] * 100, top3_classes[i]
            msg += f"{prob:.1f}%的概率是{cls}"
            for category, items in categories.items():
                if top3_classes[i] in items:
                    if category == '其他':
                        msg += '，处理方法：\n\t' + others_dict[cls]
                    else:
                        msg += '，属于' + category
                    if i != 2:
                        msg += '\n'
        return msg

if __name__ == "__main__":
    # 保证others_dict的正确性
    assert set(others) == set(others_dict.keys()), "Keys in others and others_dict do not match."
    app = QtWidgets.QApplication(sys.argv)
    win = ImageClassificationApp()
    sys.exit(app.exec_())

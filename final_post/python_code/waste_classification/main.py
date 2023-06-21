import torch
from PIL import Image
from torchvision import datasets, models, transforms
import torch.nn as nn
import os
import sys

class ImageClassifier:
    def __init__(self):
        # 设置相对路径
        self.dir_path = os.path.dirname(os.path.realpath(__file__))

        # 深度学习模型导入
        self.device = "cuda" if torch.cuda.is_available() else "cpu"

        self.model = models.resnet18()

        # 更改全连接层
        fc_inputs = self.model.fc.in_features

        self.model.fc = nn.Sequential(
            nn.Linear(fc_inputs, 256),
            nn.ReLU(),
            nn.Dropout(0.4),
            nn.Linear(256, 4),
            nn.LogSoftmax(dim=1)
        )

        model_file_path = os.path.join(self.dir_path, '.\\models\\final_model.pt')
        self.model.load_state_dict(torch.load(model_file_path, map_location=self.device))
        self.model = self.model.to(self.device)
        self.model.eval()
        self.transforms = transforms.Compose([transforms.Resize(256),
                                      transforms.CenterCrop(224),
                                      transforms.ToTensor(),
                                      transforms.Normalize([0.485, 0.456, 0.406],
                                                           [0.229, 0.224, 0.225])])

    def classify(self, img_path):
        image = self.transforms(Image.open(img_path)).unsqueeze(0).to(self.device)
        output = self.model(image)
        # 转换为概率
        probabilities = torch.exp(output)

        # 得到概率最大的类别
        _, class_idx = torch.max(probabilities, dim=1)

        # 定义类
        classes = ['有害垃圾', '厨余垃圾', '干垃圾', '可回收物']

        # 得到类名
        msg = classes[class_idx]
        return msg

if __name__ == "__main__":
    classifier = ImageClassifier()
    while True:
        try:
            image_path = input()  # 这会阻塞程序，直到它从stdin中读取到一行
            print(classifier.classify(image_path))
        except EOFError:
            break  # 当C#程序关闭它的stdin时，input()会抛出EOFError


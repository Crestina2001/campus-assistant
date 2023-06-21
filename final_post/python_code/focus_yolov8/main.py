import os
import cv2
import torch
from ultralytics import YOLO
from PyQt5 import QtWidgets, uic, QtCore
from PyQt5.QtCore import QTimer, pyqtSignal
from PyQt5.QtWidgets import QMessageBox
from PyQt5 import QtGui
from datetime import datetime


class Attention(QtWidgets.QDialog):
    time_is_up = pyqtSignal()

    def __init__(self):
        super(Attention, self).__init__()
        # 把路径改为当前路径
        dir_path = os.path.dirname(os.path.realpath(__file__))
        ui_file_path = os.path.join(dir_path, './ui/attention.ui')
        uic.loadUi(ui_file_path, self)  # 加载UI文件

        # 获取按钮和QLabel显示
        self.start_button = self.findChild(QtWidgets.QPushButton, 'attention_start')
        self.suspend_button = self.findChild(QtWidgets.QPushButton, 'suspend')
        self.exit_button = self.findChild(QtWidgets.QPushButton, 'exit_attention')
        self.timer_label = self.findChild(QtWidgets.QLabel, 'timer')
        self.msg_window = self.findChild(QtWidgets.QLabel, 'msg_window')
        self.setting_button = self.findChild(QtWidgets.QPushButton, 'time_setting')
        self.cancel_button = self.findChild(QtWidgets.QPushButton, 'cancel_att')

        # 创建QTimer对象并连接到update_time方法
        self.timer = QTimer()
        self.timer.timeout.connect(self.update_time)

        # 设置专注时长
        self.time_focus = 25 * 60 #剩余时间，单位秒

        # 按钮信号连接到相应槽函数
        self.start_button.clicked.connect(self.start_timer)
        self.suspend_button.clicked.connect(self.suspend_timer)
        self.exit_button.clicked.connect(self.close)
        self.setting_button.clicked.connect(self.set_time)
        self.cancel_button.clicked.connect(self.end_session)

        self.time_is_up.connect(self.time_up)
        self.begin = False

        # 在UI文件中找到名为'video'的QGraphicsView
        self.video_view = self.findChild(QtWidgets.QGraphicsView, 'video')

        # 创建一个新的QGraphicsScene来管理图像
        self.scene = QtWidgets.QGraphicsScene(self.video_view)
        self.video_view.setScene(self.scene)

        # QGraphicsPixmapItem用来显示图像
        self.pixmap_item = QtWidgets.QGraphicsPixmapItem()
        self.scene.addItem(self.pixmap_item)

        # 创建新的QTimer
        self.camera_timer = QTimer()
        self.camera_timer.timeout.connect(self.update_camera)

        # 加载模型
        model_file_path = os.path.join(dir_path, './models/yolov8n.pt')
        self.model = YOLO(model_file_path)

        # CUDA
        self.device = 'cuda' if torch.cuda.is_available() else 'cpu'

        self.FPS_setting = 30 #根据电脑配置设置FPS的值

        self.cap = None

        self.start_button_pressed = False # 用以区分暂停状态和未开始专注状态

    # 关闭程序时，摄像头将会被释放
    def close(self):
        # 保证摄像头的关闭
        if self.cap and self.cap.isOpened():
            self.cap.release()
        super(Attention, self).close()

    def set_time(self):
        #开始后无法修改时间
        if self.start_button_pressed:
            message_box = QMessageBox()
            message_box.setWindowTitle("提示")
            message_box.setText("开始后无法修改时间！")
            message_box.exec_()
            return
        else:
            time_input, ok = QtWidgets.QInputDialog.getInt(self, '输入', '请输入时间（单位：分钟）：', 25, 1, 180,
                                                           1)
            if ok:
                self.time_focus = time_input * 60

    def start_timer(self):
        self.time_remain = self.time_focus
        self.timer.start(1000)  # 每秒更新一次
        self.begin = True
        self.start_button.setText('重新开始')
        self.suspend_button.setText('暂停')

        # 在点击“开始”按钮后，启动摄像头，并开始计时
        self.camera_timer.start(1000 // self.FPS_setting)

        # 打开电脑摄像头
        self.cap = cv2.VideoCapture(0)
        # 更新消息窗口
        self.msg_window.setText("")

        self.start_button_pressed = True

    def suspend_timer(self):
        # 若未开始，则无法暂停
        if self.start_button_pressed == False:
            return
        if self.begin:
            self.timer.stop()  # 停止计时器
            self.begin = False
            self.suspend_button.setText('继续')
            # 停止摄像头，并释放资源
            self.camera_timer.stop()
            self.cap.release()
        else:
            self.timer.start(1000)  # 每秒更新一次
            self.begin = True
            self.suspend_button.setText('暂停')
            # 重启摄像头
            self.camera_timer.start(1000 // self.FPS_setting)
            self.cap = cv2.VideoCapture(0)
            # 更新消息窗口
            self.msg_window.setText("")

    def update_time(self):
        self.time_remain -= 1  # 减少1秒
        mins, secs = divmod(self.time_remain, 60)
        self.timer_label.setText(f"{mins:02d}:{secs:02d}")

        if self.time_remain <= 0:
            self.timer.stop()
            # 停止摄像头，并释放资源
            self.camera_timer.stop()
            self.cap.release()
            self.time_is_up.emit()  # 发出时间结束的信号

    def time_up(self):
        # 获取当前时间
        current_time = datetime.now()

        # 打开文件，并在文件末尾添加（'a' 表示 append，即追加模式）
        dir_path = os.path.dirname(os.path.realpath(__file__))
        log_path = dir_path + '../../WindowsFormsApp1/WindowsFormsApp1/database/time_log.txt'
        with open('../../database/time_log.txt', 'a') as f:
            # 写入当前时间
            f.write(str(current_time) + ' ' +  str(self.time_focus//60) + '\n')
        QtWidgets.QMessageBox.information(self, "提示", "时间到了！")
        self.start_button_pressed = True

    def end_session(self):
        if not self.start_button_pressed:
            return
        confirmation_box = QtWidgets.QMessageBox()
        confirmation_box.setWindowTitle("确认")
        confirmation_box.setText("是否确认要退出专注状态?")
        confirmation_box.setStandardButtons(QtWidgets.QMessageBox.Yes | QtWidgets.QMessageBox.No)
        confirmation_box.setDefaultButton(QtWidgets.QMessageBox.No)

        result = confirmation_box.exec_()
        if result == QtWidgets.QMessageBox.Yes:
            self.timer.stop()
            self.camera_timer.stop()
            if self.cap and self.cap.isOpened():
                self.cap.release()
            self.start_button_pressed = False

            # 获取当前时间
            current_time = datetime.now()

            # 打开文件，并在文件末尾添加（'a' 表示 append，即追加模式）
            with open('../../database/time_log.txt', 'a') as f:
                # 写入当前时间
                f.write(str(current_time) + ' ' + str(-1) + '\n')

    def update_camera(self):
        ret, frame = self.cap.read()
        if ret:
            # 应用YOLO检测
            res = self.model(frame)
            person_detected = False
            for r in res:
                if r.boxes is not None:
                    person_class_index = 0  # 假设'person'类被标记为0
                    person_indices = (r.boxes.cls == person_class_index).nonzero(as_tuple=True)[0]
                    if len(person_indices) == 0:  # 检查person_indices是否为空
                        continue  # 如果未检测到人，则跳过此次循环
                    person_probs = r.boxes.conf[person_indices]
                    if person_probs.max() > 0.5:
                        print("检测到人！")
                        person_detected = True
                        # 在帧上绘制边界框
                        frame = r.plot()
            # 如果未检测到人，则暂停计时器；如果检测到人，则继续计时器
            if not person_detected and self.begin:
                self.suspend_timer()
                self.msg_window.setText("未检测到人，已自动暂停！")
                return  # 如果未检测到人，则立即返回
            # 将颜色从BGR转换为RGB
            frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
            # 将图像转换为Qt格式
            img = QtGui.QImage(frame.data, frame.shape[1], frame.shape[0], QtGui.QImage.Format_RGB888)
            pix = QtGui.QPixmap.fromImage(img)
            # 将QPixmap缩放以适应QGraphicsView
            pix = pix.scaled(self.video_view.size(), QtCore.Qt.KeepAspectRatio)
            # 在QGraphicsPixmapItem中显示图像
            self.pixmap_item.setPixmap(pix)
        else:
            print("摄像头未接收到帧。")


app = QtWidgets.QApplication([])
window = Attention()
window.show()
app.exec()

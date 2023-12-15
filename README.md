# Intelligent Campus Assistance System
Developed a comprehensive intelligent campus assistance system that combined calendar, word memorization, class schedule and other functions, using .NET and PYQT technology stack

## Main page
![image](https://github.com/Crestina2001/campus-assistant/assets/82710275/dfbceb7c-952a-4000-93d0-7e90827bdd2e)

## Focus on learning functions(YOLOV8)：Users have to keep focuing on study. An alert will sound if the user leaves the computer
![image](https://github.com/Crestina2001/campus-assistant/assets/82710275/2eebe037-9e91-4021-aa20-9a57e788499a)

## Garbage classification function：Input garbage images and output garbage types.
Model training
**Framework**: Pytorch

**Graphics card used**: RTX3090

**Dataset**: Public data set on Feijian

**Algorithm**: ResNet-18 pre-trained on ImageNet (fully connected layer output changed to 4)

**Optimizer**: Adam (use Adam’s default learning rate in Pytorch)

**Loss function**: NLLLoss (compared to Cross Entropy Loss, it focuses more on “difficult” samples)

**Number of training rounds**: 30

**Training curve**(split the training set and test set into 4:1):
Accuracy when epoch=30: 93.4%

Use early stopping and select the model with epoch=10
![image](https://github.com/Crestina2001/campus-assistant/assets/82710275/c0d0574f-8504-449e-b5b8-a58382e38a66)

## Curriculum function
![image](https://github.com/Crestina2001/campus-assistant/assets/82710275/8403b1f9-5522-4fc1-a6f0-5942e0bd4677)

## Remember words function
![image](https://github.com/Crestina2001/campus-assistant/assets/82710275/60a377d0-e6d7-4b59-b4d3-1d53c82e38db)

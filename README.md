# DFTHMonitorSample: 东方泰华SDK集成工程
这个工程师用来集成东方泰华设备的操作，数据的存储和打印。
这个工程包含库文件DLL和示例代码

# lib
DFTHMonitorSample/DfthMonitorSample/dll

# 示例使用
本示例包含测量功能和数据回放功能，具体见示例代码MainWindow.xaml.cs

# lib集成
1.将
java DFTHMonitorSample/DfthMonitorSample/dll拷贝到工程中，并且添加对DFTHMonitor.dll的引用
2.添加管理员权限，创建文件
3.初始化类
```java
DfthMonitorOutter outter = new DfthMonitorOutter();
```
4.使用打印功能必须先添加了打印机后，打印自动选择默认打印机
5.蓝牙连接时，请先使用平台蓝牙连接公司设备，确定端口后，在测量界面选择端口后，进行连接

# 联系我们

公司网址:http://www.dftaihua.com 

公司邮箱:dfth@dftaihua.com
公司电话:010-67857716
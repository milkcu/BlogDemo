# A Simple Multi-User Blog System

这是课程《.Net应用开发》最后的实验大作业，做的是一个简单的多用户博客系统。

## 部署运行

只需修改`./BlogDemo/Models/DbHelper.cs`文件中的数据库连接字符串`connString`，就可以在VS2010中运行。
数据库位于`./BlogDemo/App_Data/`目录下，不需要额外配置。

## 文件说明

系统采用MVC架构和单例模式，控制器位于`./BlogDemo/Controllers/`目录，模型位于`./BlogDemo/Models/`目录，视图位于`./BlogDemo/Views/`目录。
另外，系统还使用了模板技术，模板文件位于`./BlogDemo/Views/Shared/Site.Master`。

-EOF-

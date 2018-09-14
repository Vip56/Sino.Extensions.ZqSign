## 基于众签的电子合同SDK
[![Build status](https://ci.appveyor.com/api/projects/status/sqgrako2k1gvfwci?svg=true)](https://ci.appveyor.com/project/vip56/sino-extensions-zqsign)
[![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg?style=plastic)](https://www.nuget.org/packages/Sino.Extensions.ZqSign)

### 安装
```
Install-Package Sino.Extensions.ZqSign
```  

在`Startup`中进行配置，增加用于读和写的MySQL连接字符串
```
services.AddZqSignService(appid, privateKey, publicKey, url);
```   
后面直接使用自带的IOC使用`IZqSignService`接口来操作

### 文件目录结构   
* Common：通用文件夹   
* Contract：合同相关   
* Register：注册相关   
* Utils：工具相关   

### 注意事项   
其中回调地址会将以下参数均通过POST提交（同步与异步一致）   

## ������ǩ�ĵ��Ӻ�ͬSDK
[![Build status](https://ci.appveyor.com/api/projects/status/sqgrako2k1gvfwci?svg=true)](https://ci.appveyor.com/project/vip56/sino-extensions-zqsign)
[![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg?style=plastic)](https://www.nuget.org/packages/Sino.Extensions.ZqSign)

�ο�[�ĵ�](http://doc.sign.zqsign.com/askCode.html)    

### ��װ
```
Install-Package Sino.Extensions.ZqSign
```  

��`Startup`�н�������
```
services.AddZqSignService(appid, privateKey, publicKey, url);
```   
����ֱ��ʹ���Դ���IOCʹ��`IZqSignService`�ӿ�������

### �ļ�Ŀ¼�ṹ   
* Common��ͨ���ļ���   
* Contract����ͬ���   
* Register��ע�����   
* Utils���������   

### ע������   
���лص���ַ�Ὣ���²�����ͨ��POST�ύ��ͬ�����첽һ�£�   

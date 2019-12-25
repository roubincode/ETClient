## ETServer运行使用方法
1 安装.net sdk  
2 通过vs installer安装 .net framework (共享组件需要安装在C盘)  
3 安装vs code 和vs code c#扩展  
4 需要用uinty打开新下载的ES项目，使项目能正确加载unity引擎代码库   
5 NLog.config文件解决ES4,5版本log输出问题(\ET-Branch_V5.0\Server\App)  
6 设置launch.json文件，在vs code中对项目进行调试  
7 用global.json指定项目net sdk版本  
8 命令行编译Server/Hotfix/Server.Hotfix.csproj  
9 调试运行服务端，运行客户端 

### 框架作者：熊猫，社区参与者 哲学绅士，Justin沙特王子
### 框架地址：https://github.com/egametang/ET
__讨论QQ群 : 474643097__

## ETClient版本说明
 1.一方面有的开发者希望可以有最少量代码的简洁纯净客户端版本 
 
 2.这个版本可以直接用于你自己的项目，你只需要把Script下的ET目录放在你项目中即可使用ETModel命名空间来使用ETClient中的类对象 
 当然你还是需要准备好config的资源绑定，建议看一下视频课程。
 
 3.这个版本是没有热更新功能的，满足你不需要热更新的情况，也方便你快速熟悉和掌握这个框架

## ETServer c#游戏服务器框架
这是肉饼负责维护的一个ET框架的纯服务器版本，同步原框架更新，目前同步原框架到3.0正式版本。  

ET框架使用C#做服务端，现在C#是完全可以跨平台的，在linux上安装.netcore，即可，不需要修改任何代码，就能跑起来。性能方面，现在.netcore的性能非常强，比lua，python，js什么快的多了，做游戏服务端完全不在话下。

ET框架不但支持TCP，而且支持可靠的UDP协议（ENET跟KCP），ENet是英雄联盟所使用的网络库，其特点是快速，并且网络丢包的情况下性能也非常好，这个我们做过测试TCP在丢包5%的情况下，moba游戏就卡的不行了，但是使用ENet，丢包20%仍然不会感到卡，非常强大。框架还支持使用KCP协议，KCP也是可靠UDP协议，据说比ENET性能更好，使用kcp请注意，需要自己加心跳机制，否则20秒没收到包，服务端将断开连接。三种协议可以无缝切换。

## 视频教程：  
[肉饼老师主讲：](http://www.taikr.com/course/972) http://www.taikr.com/course/972  
__讨论QQ群 : 474643097__

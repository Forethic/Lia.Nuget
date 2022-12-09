# Lia.Nuget
解决方案中均是将要发布在Nuget上的项目

## 项目结构
### Lia.Core
包含项目常用的框架，比如日志框架、埋点框架等

### Lia.Utils
-Lia.Core

常用C#类的拓展工具类


### Lia.Win32
- Lia.Core

PInvoke，Window系统特有的库函数，和工具方法

### Lia.Wpf
- Lia.Utils
- Lia.Core
- Lia.Win32

WPF (.Net Framework) MVVM框架、常用UI控件模板和工具类

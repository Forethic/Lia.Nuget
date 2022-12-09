using System;

namespace Lia.Win32
{
    /// <summary>
    /// 指定窗口与要检索其句柄的窗口之间的关系
    /// </summary>
    /// <remarks>
    /// 缩写：GetWindow<br/>
    /// <see cref="GetWindow.uCmd"/>中的的参数取值
    /// </remarks>
    public enum GW : uint
    {
        /// <summary>
        /// 检索的句柄按Z顺序中最高类型的窗口。
        /// </summary>
        /// <remarks>
        /// 如果指定的窗口是最顶层的窗口，则句柄将标识最顶部的窗口<br/>
        /// 如果指定的窗口是顶级窗口，则句柄将标识顶级窗口<br/>
        /// 如果指定的窗口是子窗口，则句柄将标识同级窗口
        HWNDFIRST = 0,

        /// <summary>
        /// 检索的句柄按Z顺序中最低类型的窗口。
        /// </summary>
        /// <remarks>
        /// 如果指定的窗口是最顶层的窗口，则句柄将标识最顶部的窗口<br/>
        /// 如果指定的窗口是顶级窗口，则句柄将标识顶级窗口<br/>
        /// 如果指定的窗口是子窗口，则句柄将标识同级窗口
        HWNDLAST = 1,

        /// <summary>
        /// 检索的句柄按Z顺序标识指定窗口下方的窗口。
        /// </summary>
        /// <remarks>
        /// 如果指定的窗口是最顶层的窗口，则句柄将标识最顶部的窗口<br/>
        /// 如果指定的窗口是顶级窗口，则句柄将标识顶级窗口<br/>
        /// 如果指定的窗口是子窗口，则句柄将标识同级窗口
        HWNDNEXT = 2,

        /// <summary>
        /// 检索的句柄按Z顺序标识指定窗口上方的窗口。
        /// </summary>
        /// <remarks>
        /// 如果指定的窗口是最顶层的窗口，则句柄将标识最顶部的窗口<br/>
        /// 如果指定的窗口是顶级窗口，则句柄将标识顶级窗口<br/>
        /// 如果指定的窗口是子窗口，则句柄将标识同级窗口
        /// </remarks>
        HWNDPREV = 3,

        /// <summary>
        /// 检索的句柄标识指定窗口的所有者窗口(如果有)。
        /// </summary>
        OWNER = 4,

        /// <summary>
        /// 如果指定的窗口是父窗口，则检索的句柄标识Z顺序顶部的子窗口<br/>
        /// 否则 检索的句柄为NULL。
        /// </summary>
        /// <remarks><see cref="WinApi.GetWindow"/>检查指定窗口的子窗口，不检查后代窗口</remarks>
        CHILD = 5,

        /// <summary>
        /// 检索的句柄标识指定窗口拥有的已启用弹出窗口，(搜索使用<see cref="GW.HWNDNEXT"/>找到的第一个此类窗口；否则，如果没有启用的弹出窗口，则检索的句柄是指定窗口的句柄)
        /// </summary>
        ENABLEDPOPUP = 6,
    }

    /// <summary>
    /// 检索窗口信息的参数
    /// </summary>
    /// <remarks>
    /// 缩写: GetWindowLong<br/>
    /// <see cref="WinApi.GetWindowLong"/>
    /// </remarks>
    public enum GWL : int
    {
        /// <summary>
        /// 检索窗口过程的地址，或标识窗口过程地址的句柄
        /// </summary>
        WNDPROC = -4,

        /// <summary>
        /// 检索应用程序实例的句柄
        /// </summary>
        HINSTANCE = -6,

        /// <summary>
        /// 检索父窗口的句柄（如果有）
        /// </summary>
        HWNDPARENT = -8,

        /// <summary>
        /// 检索窗口的标识符
        /// </summary>
        ID = -12,

        /// <summary>
        /// 检索窗口样式
        /// </summary>
        STYLE = -16,

        /// <summary>
        /// 检索扩展窗口样式
        /// </summary>
        EXSTYLE = -20,

        /// <summary>
        /// 检索与窗口关联的用户数据。<br/>
        /// 此数据供创建窗口的应用程序使用。
        /// </summary>
        /// <remarks>默认值为0</remarks>
        USERDATA = -21,
    }

    /// <summary>
    /// 窗口显示状态命令
    /// </summary>
    /// <remarks>
    /// 缩写：ShowWindow<br/>
    /// <see cref="WinApi.ShowWindow"/>
    /// </remarks>
    public enum SW
    {
        /// <summary>
        /// 隐藏窗口并激活另一个窗口
        /// </summary>
        HIDE = 0,

        /// <summary>
        /// 激活并显示窗口<br/>
        /// 如果窗口最小化或最大化，系统会将其还原到其原始大小和位置。<br/>
        /// 首次显示窗口时，应用程序应指定此标志。
        /// </summary>
        SHOWNORMAL = 1,

        /// <summary>
        /// 激活并显示窗口<br/>
        /// 如果窗口最小化或最大化，系统会将其还原到其原始大小和位置。<br/>
        /// 首次显示窗口时，应用程序应指定此标志。
        /// </summary>
        NORMAL = 1,

        /// <summary>
        /// 激活窗口并将其显示为最小化窗口
        /// </summary>
        SHOWMINIMIZED = 2,

        /// <summary>
        /// 激活窗口并显示最大化的窗口
        /// </summary>
        SHOWMAXIMIZED = 3,

        /// <summary>
        /// 激活窗口并显示最大化的窗口
        /// </summary>
        MAXIMIZE = 3,

        /// <summary>
        /// 在其最近的大小和位置显示一个窗口。<br/>
        /// 此值类似于 SW_SHOWNORMAL，但窗口未激活
        /// </summary>
        SHOWNOACTIVATE = 4,

        /// <summary>
        /// 在其最近的大小和位置显示一个窗口。 此值类似于 SW_SHOWNORMAL，但窗口未激活
        /// </summary>
        SHOW = 5,

        /// <summary>
        /// 在其最近的大小和位置显示一个窗口。 此值类似于 SW_SHOWNORMAL，但窗口未激活
        /// </summary>
        MINIMIZE = 6,

        /// <summary>
        /// 将窗口显示为最小化窗口。 <br/>
        /// 此值类似于 SW_SHOWMINIMIZED，但窗口未激活
        /// </summary>
        SHOWMINNOACTIVE = 7,

        /// <summary>
        /// 以当前大小和位置显示窗口。 <br/>
        /// 此值类似于 SW_SHOW，但窗口未激活
        /// </summary>
        SHOWNA = 8,

        /// <summary>
        /// 激活并显示窗口。 <br/>
        /// 如果窗口最小化或最大化，系统会将其还原到其原始大小和位置。 <br/>
        /// 还原最小化窗口时，应用程序应指定此标志。
        /// </summary>
        SW_RESTORE = 9,

        /// <summary>
        /// 根据启动应用程序的程序传递给 CreateProcess 函数的 STARTUPINFO 结构中指定的SW_值设置显示状态
        /// </summary>
        SHOWDEFAULT = 10,

        /// <summary>
        /// 即使拥有窗口的线程未响应，也会最小化窗口。 <br/>
        /// 仅当将窗口从不同的线程最小化时，才应使用此标志
        /// </summary>
        FORCEMINIMIZE = 11,
    }

    /// <summary>
    /// 拓展窗口样式 WindowShow ExtendSyle
    /// </summary>
    /// <remarks>
    /// 缩写：WindowStyle ExtendStyle
    /// </remarks>
    public enum WSEX : long
    {
        /// <summary>
        /// 当用户单击该样式时，使用此样式创建的顶级窗口不会成为前台窗口<br/>
        /// 当用户最小化或关闭前台窗口时，系统不会将此窗口引入前台。<br/>
        /// 若要激活窗口，请使用<see cref="WinApi.SetActiveWindow"/>或<see cref="WinApi.SetForegroundWindow"/><br/>
        /// 默认情况下，该窗口不会显示在任务栏上。<br/>
        /// 若要强制窗口显示在任务栏，请使用<see cref="WSEX.APPWINDOW"/>
        /// </summary>
        NOACTIVATE = 0x80000000L,

        /// <summary>
        /// 使用双缓冲按从下到上绘制顺序绘制窗口的所有后代。<br/>
        /// 从下到上绘制顺序允许后代窗口具有半透明和透明度效果，但前提是后代窗口设置了<see cref="WSEX.TRANSPARENT"/><br/>
        /// 双缓冲允许不闪烁地绘制窗口及其后代。<br/>
        /// 如果窗口的类样式为<see cref="CS.OWNDC"/>或<see cref="CS.CLASSDC"/>，则不能使用此样式
        /// </summary>
        /// <remarks>windows 2000: 不支持此样式</remarks>
        COMPOSITED = 0x20000000L,

        /// <summary>
        /// 窗口的水平原点位于右边缘。将水平值增大到左侧
        /// </summary>
        /// <remarks>仅当 shell 语言为希伯来语、阿拉伯语或支持阅读顺序对齐的另一种语言时，此样式才有效;否则，将忽略样式。</remarks>
        LAYOUTRTL = 0x00400000L,

        /// <summary>
        /// 窗口不会呈现到重定向图面。 
        /// 这是对于没有可见内容的窗口，或者使用表面以外的机制来提供视觉对象。
        /// </summary>
        NOREDIRECTIONBITMAP = 0x00200000L,

        /// <summary>
        /// 该窗口不将其窗口布局传递给其子窗口。
        /// </summary>
        NOINHERITLAYOUT = 0x00100000L,

        /// <summary>
        /// 窗口是分层 窗口。 <br/>
        /// 如果窗口的类样式为<see cref="CS.OWNDC"/>或<see cref="CS.CLASSDC"/>，则不能使用此样式。
        /// </summary>
        /// <remarks>
        /// Windows 8：顶级窗口和子窗口支持WS_EX_LAYERED样式。<br/> 
        /// 以前的Windows版本仅支持顶级窗口WS_EX_LAYERED。
        /// </remarks>
        LAYERED = 0x00080000L,

        /// <summary>
        /// 当窗口可见时，将顶级窗口强制到任务栏上。
        /// </summary>
        APPWINDOW = 0x00040000L,

        /// <summary>
        /// 该窗口具有一个三维边框样式，用于不接受用户输入的项目。
        /// </summary>
        STATICEDGE = 0x00020000L,

        /// <summary>
        /// 窗口本身包含应参与对话框导航的子窗口。 <br/>
        /// 如果指定了此样式，则执行导航操作（例如处理 TAB 键、箭头键或键盘助记键）时，对话框管理器将递归到此窗口的子级。
        /// </summary>
        CONTROLPARENT = 0x00010000L,

        /// <summary>
        /// 垂直滚动条 (如果存在) 位于工作区左侧
        /// </summary>
        /// <remarks>仅当 shell 语言为希伯来语、阿拉伯语或支持阅读顺序对齐的另一种语言时，此样式才有效;否则，将忽略样式。</remarks>
        LEFTSCROLLBAR = 0x00004000L,

        /// <summary>
        /// 使用从右到左的阅读顺序属性显示窗口文本。
        /// </summary>
        /// <remarks>仅当 shell 语言为希伯来语、阿拉伯语或支持阅读顺序对齐的另一种语言时，此样式才有效;否则，将忽略样式。</remarks>
        RTLREADING = 0x00002000L,

        /// <summary>
        /// 该窗口具有泛型“右对齐”属性。 这依赖于窗口类。<br/>
        /// 对静态控件或编辑控件使用<see cref="WSEX.RIGHT"/>样式的效果与分别使用 <see cref="SS.RIGHT"/>或<see cref="ES.RIGHT"/>样式的效果相同。<br/>
        /// 将此样式与按钮控件结合使用的效果与使用<see cref="BS.RIGHT"/>和<see cref="BS.RIGHTBUTTON"/>样式的效果相同。
        /// </summary>
        /// <remarks>仅当 shell 语言为希伯来语、阿拉伯语或支持阅读顺序对齐的另一种语言时，此样式才有效;否则，将忽略样式。</remarks>
        RIGHT = 0x00001000L,

        /// <summary>
        /// 窗口的标题栏包含问号。<br/>
        /// 当用户单击问号时，光标将更改为带有指针的问号。<br/>
        /// 如果用户单击子窗口，子窗口将收到<see cref="WM.HELP"/>消息。<br/>
        /// 子窗口应将消息传递给父窗口过程，该过程应使用<see cref="WM.HELP"/>命令调用<see cref="WinApi.WinHelp"/>函数。<br/>
        /// 帮助应用程序会显示一个弹出窗口，该窗口通常包含子窗口的帮助。
        /// </summary>
        /// <remarks><see cref="WSEX.CONTEXTHELP"/>不能与<see cref="WS.MINIMIZEBOX"/>或<see cref="WS.MAXIMIZEBOX"/>一起使用</remarks>
        CONTEXTHELP = 0x00000400L,

        /// <summary>
        /// 窗口是重叠的窗口
        /// </summary>
        /// <remarks><see cref="WSEX.WINDOWEDGE"/> | <see cref="WSEX.CLIENTEDGE"/></remarks>
        OVERLAPPEDWINDOW = 0x00000300L,

        /// <summary>
        /// 窗口有一个边框，带有沉没边缘。
        /// </summary>
        CLIENTEDGE = 0x00000200L,

        /// <summary>
        /// 窗口是调色板窗口，它是一个无模式对话框，用于显示命令数组。
        /// </summary>
        /// <remarks><see cref="WSEX.WINDOWEDGE"/> | <see cref="WSEX.TOOLWINDOW"/> | <see cref="WSEX.TOPMOST"/> </remarks>
        PALETTEWINDOW = 0x00000188L,

        /// <summary>
        /// 窗口具有带有凸起边缘的边框。
        /// </summary>
        WINDOWEDGE = 0x00000100L,

        /// <summary>
        /// 该窗口旨在用作浮动工具栏。<br/>
        /// 工具窗口具有短于普通标题栏的标题栏和使用较小的字体绘制的窗口标题。<br/>
        /// 工具窗口不会显示在任务栏中，也不会显示在用户按下 Alt+TAB 时出现的对话框中。<br/>
        /// 如果工具窗口有系统菜单，则其图标不会显示在标题栏上。<br/>
        /// 但是，可以通过右键单击或键入 Alt+SPACE 来显示系统菜单。
        /// </summary>
        TOOLWINDOW = 0x00000080L,

        /// <summary>
        /// 窗口是 MDI 子窗口。
        /// </summary>
        MDICHILD = 0x00000040L,

        /// <summary>
        /// 在绘制同一线程(创建的窗口下方的同级)之前，不应绘制窗口。<br/>
        /// 窗口显示为透明，因为已绘制基础同级窗口的位。<br/>
        /// 若要在不使用这些限制的情况下实现透明度，请使用<see cref="WinApi.SetWindowRgn"/> 函数。
        /// </summary>
        TRANSPARENT = 0x00000020L,

        /// <summary>
        /// 窗口接受拖放文件。
        /// </summary>
        ACCEPTFILES = 0x00000010L,

        /// <summary>
        /// 该窗口应放置在所有非最顶层窗口上方，并且应保持其上方，即使窗口已停用也是如此。<br/>
        /// 若要添加或删除此样式，请使用<see cref="WinApi.SetWindowPos"/>函数。
        /// </summary>
        TOPMOST = 0x00000008L,

        /// <summary>
        /// 使用此样式创建的子窗口不会在创建或销毁时将<see cref="WM.PARENTNOTIFY"/>消息发送到其父窗口
        /// </summary>
        NOPARENTNOTIFY = 0x00000004L,

        /// <summary>
        /// 窗口具有双边框;可以选择使用标题栏创建窗口，方法是在dwStyle参数中指定<see cref="WS.CAPTION"/>样式。
        /// </summary>
        DLGMODALFRAME = 0x00000001L,

        /// <summary>
        /// 该窗口具有泛型左对齐属性。 
        /// </summary>
        /// <remarks>这是默认值。</remarks>
        LEFT = 0x00000000L,

        /// <summary>
        /// 窗口文本使用从左到右的阅读顺序属性显示。 
        /// </summary>
        /// <remarks>这是默认值。</remarks>
        LTRREADING = 0x00000000L,

        /// <summary>
        /// 如果存在位于工作区右侧，则垂直滚动条。
        /// </summary>
        /// <remarks>这是默认值。</remarks>
        RIGHTSCROLLBAR = 0x00000000L,
    }

    /// <summary>
    /// 窗口样式
    /// </summary>
    /// <remarks>
    /// 缩写：WindowStyle
    /// </remarks>
    public enum WS : long
    {
        /// <summary>
        /// 窗口是弹出窗口。
        /// </summary>
        /// <remarks>必须组合<see cref="WS.CAPTION"/>和<see cref="WS.POPUPWINDOW"/>样式以使窗口菜单可见。</remarks>
        /// <value><see cref="WS.POPUP"/> | <see cref="WS.BORDER"/> | <see cref="WS.SYSMENU"/></value>
        POPUPWINDOW = 0x80880000L,

        /// <summary>
        /// 窗口是弹出窗口。
        /// </summary>
        /// <remarks>不能与<see cref="WS.CHILD"/>一起使用</remarks>
        POPUP = 0x80000000L,

        /// <summary>
        /// 窗口是子窗口。 具有此样式的窗口不能有菜单栏。 
        /// </summary>
        /// <remarks>不能与<see cref="WS.POPUP"/>一起使用</remarks>
        CHILD = 0x40000000L,

        /// <remarks>
        /// 与<see cref="WS.CHILD"/>样式相同
        /// </remarks>
        CHILDWINDOW = 0x40000000L,

        /// <summary>
        /// 窗口最小化。
        /// </summary>
        /// <remarks>与<see cref="WS.MINIMIZE"/>样式相同</remarks>
        ICONIC = 0x20000000L,

        /// <summary>
        /// 窗口最小化。
        /// </summary>
        /// <remarks>与<see cref="WS.ICONIC"/>样式相同</remarks>
        MINIMIZE = 0x20000000L,

        /// <summary>
        /// 窗口可见。
        /// </summary>
        /// <remarks>可以使用<see cref="WinApi.ShowWindow"/>或<see cref="WinApi.SetWindowPos"/>函数打开和关闭此样式</remarks>
        VISIBLE = 0x10000000L,

        /// <summary>
        /// 窗口处于禁用状态<br/>
        /// 禁用的窗口无法从用户接收输入。<br/>
        /// </summary>
        /// <remarks>若要在创建窗口后进行更改，请使用<see cref="WinApi.EnableWindow"/>函数</remarks>
        DISABLED = 0x08000000L,

        /// <summary>
        /// 将子窗口相对于彼此剪裁;也就是说，当特定子窗口收到<see cref="WM.PAINT"/>消息时,<see cref="WS.CLIPSIBLINGS"/>样式会将所有其他重叠子窗口剪辑到要更新的子窗口区域。<br/>
        /// 如果未指定<see cref="WS.CLIPCHILDREN"/>并且子窗口重叠，则当在子窗口的工作区内绘制时，可以在相邻子窗口的工作区内绘制。
        /// </summary>
        CLIPSIBLINGS = 0x04000000L,

        /// <summary>
        /// 在父窗口中绘制时，排除子窗口占用的区域。 创建父窗口时会使用此样式。
        /// </summary>
        CLIPCHILDREN = 0x02000000L,

        /// <summary>
        /// 窗口最大化
        /// </summary>
        MAXIMIZE = 0x01000000L,

        /// <summary>
        /// 窗口是重叠的窗口。
        /// </summary>
        /// <remarks>与<see cref="WS.TILEDWINDOW"/>样式相同。</remarks>
        /// <value><see cref="WS.OVERLAPPED"/> | <see cref="WS.CAPTION"/> | <see cref="WS.SYSMENU"/> | <see cref="WS.THICKFRAME"/> | <see cref="WS.MINIMIZEBOX"/> | <see cref="WS.MAXIMIZEBOX"/></value>
        OVERLAPPEDWINDOW = 0x00CF0000L,

        /// <summary>
        /// 窗口是重叠的窗口。
        /// </summary>
        /// <remarks>与<see cref="WS.OVERLAPPEDWINDOW"/>样式相同。</remarks>
        /// <value><see cref="WS.OVERLAPPED"/> | <see cref="WS.CAPTION"/> | <see cref="WS.SYSMENU"/> | <see cref="WS.THICKFRAME"/> | <see cref="WS.MINIMIZEBOX"/> | <see cref="WS.MAXIMIZEBOX"/></value>
        TILEDWINDOW = 0x00CF0000L,

        /// <summary>
        /// 窗口具有标题栏 (包括<see cref="WS.BORDER"/>样式) 。
        /// </summary>
        CAPTION = 0x00C00000L,

        /// <summary>
        /// 窗口具有细线边框
        /// </summary>
        BORDER = 0x00800000L,

        /// <summary>
        /// 窗口具有通常与对话框一起使用的样式边框。 
        /// </summary>
        /// <remarks>具有此样式的窗口不能有标题栏。</remarks>
        DLGFRAME = 0x00400000L,

        /// <summary>
        /// 该窗口具有垂直滚动条。
        /// </summary>
        VSCROLL = 0x00200000L,

        /// <summary>
        /// 窗口具有水平滚动条。
        /// </summary>
        HSCROLL = 0x00100000L,

        /// <summary>
        /// 窗口的标题栏上有一个窗口菜单。
        /// </summary>
        /// <remarks>必须指定 WS_CAPTION 样式。</remarks>
        SYSMENU = 0x00080000L,

        /// <summary>
        /// 窗口具有大小调整边框。
        /// </summary>
        /// <remarks>与<see cref="WS.THICKFRAME"/>样式相同</remarks>
        SIZEBOX = 0x00040000L,

        /// <summary>
        /// 窗口具有大小调整边框。
        /// </summary>
        /// <remarks>与<see cref="WS.SIZEBOX"/>样式相同</remarks>
        THICKFRAME = 0x00040000L,

        /// <summary>
        /// 窗口是一组控件的第一个控件。<br/>
        /// 该组包含此第一个控件及其之后定义的所有控件，最多包含<see cref="WS.GROUP"/>样式的下一个控件。<br/>
        /// 每个组中的第一个控件通常具有<see cref="WS.TABSTOP"/>样式，以便用户可以从组移动到组。<br/>
        /// 用户随后可以使用方向键将组中的一个控件中的键盘焦点更改为组中的下一个控件。<br/>
        /// 可以打开和关闭此样式以更改对话框导航。 
        /// </summary>
        /// <remarks>若要在创建窗口后更改此样式，请使用<see cref="WinApi.SetWindowLong"/> 函数</remarks>
        GROUP = 0x00020000L,

        /// <summary>
        /// 窗口具有最小化按钮。 
        /// </summary>
        /// <remarks>
        /// 不能与<see cref="WSEX.CONTEXTHELP"/>样式组合<br/>
        /// 必须指定<see cref="WS.SYSMENU"/>样式
        /// </remarks>
        MINIMIZEBOX = 0x00020000L,

        /// <summary>
        /// 窗口是一个控件，当用户按下 TAB 键时，可以接收键盘焦点。<br/>
        /// 按 Tab 键会将键盘焦点更改为具有<see cref="WS.TABSTOP"/>样式的下一个控件。<br/>
        /// 可以打开和关闭此样式以更改对话框导航。<br/>
        /// </summary>
        /// <remarks>
        /// 若要在创建窗口后更改此样式，请使用<see cref="WinApi.SetWindowLong"/>函数。<br/>
        /// 若要使用户创建的窗口和无模式对话框使用制表位，请更改消息循环以调用<see cref="WinApi.IsDialogMessage"/>函数。
        /// </remarks>
        TABSTOP = 0x00010000L,

        /// <summary>
        /// 窗口具有最大化按钮。 
        /// </summary>
        /// <remarks>
        /// 不能与<see cref="WSEX.CONTEXTHELP"/>样式组合<br/>
        /// 必须指定<see cref="WS.SYSMENU"/>样式
        /// </remarks>
        MAXIMIZEBOX = 0x00010000L,

        /// <summary>
        /// 窗口是重叠的窗口。 重叠的窗口具有标题栏和边框。
        /// </summary>
        /// <remarks>与<see cref="WS.TILED"/>样式相同</remarks>
        OVERLAPPED = 0x00000000L,

        /// <summary>
        /// 窗口是重叠的窗口。 重叠的窗口具有标题栏和边框。
        /// </summary>
        /// <remarks>与<see cref="WS.OVERLAPPED"/>样式相同</remarks>
        TILED = 0x00000000L,
    }

    /// <summary>
    /// 类样式定义窗口类的其他元素。可以使用按位 OR （|） 运算符组合两个或多个样式
    /// </summary>
    /// <remarks>
    /// 缩写：Window Class Styles
    /// </remarks>
    public enum CS
    {
        /// <summary>
        /// 在窗口上启用投影效果。<br/>
        /// 效果通过<see cref="SPI.SETDROPSHADOW"/>打开和关闭。<br/>
        /// 通常，为小型、生存期较短的窗口（如菜单）启用此功能，以强调其与其他窗口的 Z 顺序关系。<br/>
        /// 从具有此样式的类创建的窗口必须是顶级窗口;它们可能不是子窗口。
        /// </summary>
        DROPSHADOW = 0x00020000,

        /// <summary>
        /// 指示窗口类是应用程序全局类。
        /// </summary>
        GLOBALCLASS = 0x4000,

        /// <summary>
        /// 在字节边界上对齐窗口（在 x 方向上）。
        /// </summary>
        /// <remarks>
        /// 此样式会影响窗口的宽度及其在显示器上的水平位置。
        /// </remarks>
        BYTEALIGNWINDOW = 0x2000,

        /// <summary>
        /// 在字节边界上对齐窗口的工作区（在 x 方向上）。
        /// </summary>
        /// <remarks>
        /// 此样式会影响窗口的宽度及其在显示器上的水平位置。
        /// </remarks>
        BYTEALIGNCLIENT = 0x1000,

        /// <summary>
        /// 将屏幕图像中被此类窗口遮挡的部分保存为位图。<br/>
        /// 删除窗口后，系统将使用保存的位图来恢复屏幕图像，包括被遮挡的其他窗口。<br/>
        /// 因此，如果位图使用的内存尚未被丢弃，并且其他屏幕操作未使存储的图像无效，则系统不会将<see cref="WM.PAINT"/>消息发送到被遮盖的窗口。<br/>
        /// 此样式对于在其他屏幕活动发生之前短暂显示然后删除的小窗口（例如，菜单或对话框）很有用。<br/>
        /// 此样式会增加显示窗口所需的时间，因为系统必须首先分配内存来存储位图。
        /// </summary>
        SAVEBITS = 0x0800,

        /// <summary>
        /// 禁用窗口菜单上的关闭。
        /// </summary>
        NOCLOSE = 0x0200,

        /// <summary>
        /// 将子窗口的剪裁矩形设置为父窗口的剪裁矩形，以便子窗口可以在父窗口上绘制。<br/>
        /// 具有<see cref="CS.PARENTDC"/>样式位的窗口从系统的设备上下文缓存中接收常规设备上下文。<br/>
        /// 它不会为子级提供父级的设备上下文或设备上下文设置。
        /// </summary>
        /// <remarks>
        /// 指定<see cref="CS.PARENTDC"/>可提高应用程序的性能。
        /// </remarks>
        PARENTDC = 0x0080,

        /// <summary>
        /// 分配一个要由类中的所有窗口共享的设备上下文。<br/>
        /// 由于窗口类是特定于进程的，因此应用程序的多个线程可以创建同一类的窗口。<br/>
        /// 线程也可以尝试同时使用设备上下文。<br/>
        /// 发生这种情况时，系统只允许一个线程成功完成其绘图操作。
        /// </summary>
        CLASSDC = 0x0040,

        /// <summary>
        /// 为类中的每个窗口分配唯一的设备上下文。
        /// </summary>
        OWNDC = 0x0020,

        /// <summary>
        /// 当用户在光标位于属于该类的窗口中时双击鼠标时，向窗口过程发送双击消息。
        /// </summary>
        DBLCLKS = 0x0008,

        /// <summary>
        /// 如果移动或大小调整更改了工作区的宽度，则重绘整个窗口。
        /// </summary>
        HREDRAW = 0x0002,

        /// <summary>
        /// 如果移动或大小调整更改了工作区的高度，则重绘整个窗口。
        /// </summary>
        VREDRAW = 0x0001,
    }

    /// <summary>
    /// 设置窗口大小和定位的标志
    /// </summary>
    /// <remarks>
    /// 缩写：SetWindowPos<br/>
    /// <see cref="WinApi.SetWindowPos"/>
    /// </remarks>
    public enum SWP : uint
    {
        /// <summary>
        /// 如果调用线程和拥有窗口的线程附加到不同的输入队列，则系统会将请求发布到拥有该窗口的线程。<br/>
        /// 这可以防止调用线程在其他线程处理请求时阻止其执行。
        /// </summary>
        ASYNCWINDOWPOS = 0x4000,

        /// <summary>
        /// 防止生成<see cref="WM.SYNCPAINT"/>消息。
        /// </summary>
        DEFERERASE = 0x2000,

        /// <summary>
        /// 防止窗口接收<see cref="WM.WINDOWPOSCHANGING"/>消息。
        /// </summary>
        NOSENDCHANGING = 0x0400,

        /// <remarks>
        /// 与<see cref="SWP.NOOWNERZORDER"/>标志相同。
        /// </remarks>
        NOREPOSITION = 0x0200,

        /// <summary>
        /// 不更改所有者窗口在 Z 顺序中的位置。
        /// </summary>
        NOOWNERZORDER = 0x0200,

        /// <summary>
        /// 丢弃工作区的全部内容。<br/>
        /// 如果未指定此标志，则在调整窗口大小或重新定位窗口后，将保存工作区的有效内容并将其复制回工作区。
        /// </summary>
        NOCOPYBITS = 0x0100,

        /// <summary>
        /// 隐藏窗口。
        /// </summary>
        HIDEWINDOW = 0x0080,

        /// <summary>
        /// 显示窗口。
        /// </summary>
        SHOWWINDOW = 0x0040,

        /// <summary>
        /// 防止生成WM_SYNCPAINT消息。
        /// </summary>
        DRAWFRAME = 0x0020,

        /// <summary>
        /// 应用使用<see cref="WinApi.SetWindowLong"/>函数设置的新框架样式。
        /// 向窗口发送<see cref="WM.NCCALCSIZE"/>消息，即使窗口的大小未更改也是如此。
        /// 如果未指定此标志，则仅在更改窗口大小时发送<see cref="WM.NCCALCSIZE"/>。
        /// </summary>
        FRAMECHANGED = 0x0020,

        /// <summary>
        /// 不激活窗口。<br/>
        /// 如果未设置此标志，则会激活窗口并将其移动到最顶层或非最顶层组的顶部（取决于hWndInsertAfter参数的设置）。
        /// </summary>
        NOACTIVATE = 0x0010,

        /// <summary>
        /// 不重绘更改。<br/>
        /// 如果设置了此标志，则不会发生任何类型的重新绘制。<br/>
        /// 这适用于工作区、非工作区（包括标题栏和滚动条）以及由于窗口被移动而未覆盖的父窗口的任何部分。<br/>
        /// 设置此标志后，应用程序必须显式使需要重绘的窗口和父窗口的任何部分失效或重绘。
        /// </summary>
        NOREDRAW = 0x0008,

        /// <summary>
        /// 保留当前的 Z 顺序（忽略hWndInsertAfter参数）。
        /// </summary>
        NOZORDER = 0x0004,

        /// <summary>
        /// 保留当前位置（忽略X和Y参数）。
        /// </summary>
        NOMOVE = 0x0002,

        /// <summary>
        /// 保留当前大小（忽略cx和cy参数）。
        /// </summary>
        NOSIZE = 0x0001,
    }

    /// <summary>
    /// <see cref="WinApi.GetAncestor(IntPtr, GA)"/>
    /// </summary>
    public enum GA
    {
        /// <summary>
        /// 检索父窗口。
        /// </summary>
        /// <remarks>
        /// 不包括所有者，因为它与<see cref="WinApi.GetParent"/>一样
        /// </remarks>
        PARENT = 1,

        /// <summary>
        /// 通过走父窗口链来检索根窗口
        /// </summary>
        ROOT = 2,

        /// <summary>
        /// 通过走<see cref="WinApi.GetParent/>返回的父窗口和所有者窗口链来检索拥有的根窗口
        /// </summary>
        ROOTOWNER = 3,
    }

    /// <summary>
    /// 控制最小化窗口的位置以及还原窗口的方法的标志。
    /// </summary>
    /// <remarks>
    /// 缩写：WindowPlacement Flag
    /// </remarks>
    public enum WPF : uint
    {
        /// <summary>
        /// 如果调用线程和拥有窗口的线程附加到不同的输入队列，则系统会将请求发布到拥有窗口的线程。 这可以防止调用线程阻止其执行，而其他线程处理请求。
        /// </summary>
        ASYNCWINDOWPLACEMENT = 0x0004,

        /// <summary>
        /// 无论还原的窗口在最小化之前是否最大化，都将最大化还原的窗口。 <br/>
        /// </summary>
        /// <remarks>
        /// 此设置仅在下次还原窗口时有效。<br/>
        /// 它不会更改默认还原行为。<br/>
        /// 仅当为<see cref="WINDOWPLACEMENT.ShowCmd"/>成员指定了<see cref="SW.SHOWMINIMIZED"/>值时，此标志才有效。
        /// </remarks>
        RESTORETOMAXIMIZED = 0x0002,

        /// <summary>
        /// 可以指定最小化窗口的坐标。
        /// </summary>
        /// <remarks>
        /// 如果在<see cref="WINDOWPLACEMENT.MinPosition"/>设置了坐标，则必须指定此标志。
        /// </remarks>  
        SETMINPOSITION = 0x0001,
    }
}
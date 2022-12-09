using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lia.Win32
{
    /// <summary>
    /// Win32原装函数
    /// </summary>
    public class WinApi
    {
        #region Delegate

        /// <summary>
        /// 接收顶级窗口句柄
        /// </summary>
        /// <param name="hWnd">顶级窗口的句柄</param>
        /// <param name="lParam">在<see cref="EnumWindows"/>或<see cref="EnumDesktopWindows"/>中给出的应用程序定义值</param>
        /// <returns>
        /// 若要继续枚举，回调函数必须返回true<br/>
        /// 否则，必须返回false
        /// </returns>
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        #endregion

        #region 窗口查询

        /// <summary>
        /// 检索顶级窗口的句柄，该窗口的类名称和窗口名称与指定的字符串匹配。 
        /// </summary>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口标题</param>
        /// <returns>
        /// 如果函数成功，返回值是具有指定类名和窗口名称的窗口句柄<br/>
        /// 如果函数失败，返回值为NULL
        /// </returns>
        /// <remarks>
        /// 此函数不搜索子窗口。 <br/>
        /// 此函数不执行区分大小写的搜索。<br/>
        /// 如果<paramref name="lpClassName"/>为NULL，将查找其标题与<paramref name="lpWindowName"/>参数匹配的任何窗口<br/>
        /// 如果<paramref name="lpWindowName"/>为NULL，则所有窗口名称都匹配<br/>
        /// 如果<paramref name="lpWindowName"/>不为NULL，<see cref="FindWindow"/>将调用<see cref="GetWindowText"/>以检索窗口名称进行比较。
        /// </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 检索一个窗口的句柄，该窗口的类名和窗口名称与指定的字符串匹配。 该函数搜索子窗口，从指定子窗口后面的子窗口开始。 此函数不执行区分大小写的搜索。
        /// </summary>
        /// <param name="hWndParent">要搜索其子窗口的父窗口的句柄。</param>
        /// <param name="hWndChildAfter">子窗口句柄。搜索顺序从Z顺序中的下一个子窗口开始。</param>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口标题</param>
        /// <returns>
        /// 如果函数成功，返回值是具有指定类名和窗口名称的窗口句柄<br/>
        /// 如果函数失败，返回值为NULL
        /// </returns>
        /// <remarks>
        /// 如果<paramref name="hWndParent"/>为NULL，则以桌面窗口为父窗口<br/>
        /// 如果<paramref name="hWndParent"/>为<see cref="WinArgs.HWND_MESSAGE"/>，则函数将搜索所有仅消息窗口<br/>
        /// <paramref name="hWndChildAfter"/>必须是<paramref name="hWndParent"/>的直接子窗口<br/>
        /// 如果<paramref name="hWndChildAfter"/>为NULL，则搜索从<paramref name="hWndParent"/>的第一个子窗口开始。<br/>
        /// 如果<paramref name="hWndParent"/>和<paramref name="hWndChildAfter"/>均为NULL，则该函数将搜索所有顶级窗口和仅消息窗口。<br/>
        /// <see cref="FindWindowEx"/>仅搜索直接子窗口，不搜索其他后代。
        /// </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hWndParent, IntPtr hWndChildAfter, string lpClassName, string lpWindowName);

        /// <summary>
        /// 通过将句柄传递到应用程序定义的回调函数，枚举屏幕上的所有顶级窗口。<br/>
        /// 直到最后一个顶级窗口或回调函数返回False为止。
        /// </summary>
        /// <param name="lpEnumFunc"><see cref="EnumWindowsProc"/>回调函数</param>
        /// <param name="lParam">要传递给回调函数的应用程序定义值</param>
        /// <returns>true：函数成功</returns>
        /// <remarks>
        /// <see cref="EnumWindows"/>不枚举子窗口，但具有<see cref="WS.CHILD"/>样式的系统拥有的几个顶级窗口除外。<br/>
        /// 此函数比在循环中调用<see cref="GetWindow"/>更可靠。调用<see cref="GetWindow"/>以执行此任务的应用程序可能会陷入无限循环或引用已销毁窗口的句柄<br/>
        /// 对于Windows8及更高版本，<see cref="EnumWindows"/>仅枚举桌面应用的顶级窗口。
        /// </remarks>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, int lParam);
        /// <summary>
        /// 枚举与指定桌面关联的所有顶级窗口。将每个窗口的句柄传递给应用程序定义的回调函数。
        /// </summary>
        /// <param name="hDesktop">要枚举其顶级窗口的桌面句柄</param>
        /// <param name="lpEnumFunc"><see cref="EnumWindowsProc"/>回调函数</param>
        /// <param name="lParam">要传递给回调函数的应用程序定义值</param>
        /// <returns>true:函数成功，false:函数失败或无法执行枚举</returns>
        /// <remarks>
        /// <paramref name="hDesktop"/>由<see cref="CreateDesktop"/>、<see cref="GetThreadDesktop"/>、<see cref="OpenDesktop"/>或OpenInputDesktop函数返回，并且必须具有<see cref="DESKTOP.READOBJECTS"/>访问权限。<br/>
        /// 如果<paramref name="hDesktop"/>为NULL，则使用当前桌面。
        /// </remarks>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumWindowsProc lpEnumFunc, int lParam);

        /// <summary>
        /// 通过将句柄传递给应用程序定义的回调函数，枚举属于指定父窗口的子窗口。直到枚举最后一个子窗口或回调函数返回 FALSE。
        /// </summary>
        /// <param name="hWndParent">要枚举其子窗口的父窗口的句柄。</param>
        /// <param name="lpEnumFunc">指向应用程序定义的回调函数的指针。</param>
        /// <param name="lParam">要传递给回调函数的应用程序定义值。</param>
        /// <returns>不使用返回值。</returns>
        /// <remarks>
        /// 如果<paramref name="hWndParent"/>为NULL，此函数等效于<see cref="EnumWindows"/><br/>
        /// 如果子窗口已创建自己的子窗口， 则 EnumChildWindows 也会枚举这些窗口。<br/>
        /// 在枚举过程中按 Z 顺序移动或重新定位的子窗口将被正确枚举。<br/>
        /// 该函数不会枚举调用函数之前销毁的子窗口，也不会枚举函数执行过程中创建的窗口。
        /// </remarks>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindow(IntPtr hWndParent, EnumWindowsProc lpEnumFunc, int lParam);

        /// <summary>
        /// 检索与指定窗口有指定关系（Z-Order或所有者）的窗口句柄
        /// </summary>
        /// <param name="hWnd">指定的窗口句柄</param>
        /// <param name="uCmd">指定窗口与要检索句柄的窗口之间的关系</param>
        /// <returns>
        /// 如果函数成功，则返回值为窗口句柄。<br/>
        /// 如果不存在具有指定关系的窗口，则返回值为NULL
        /// </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, GW uCmd);

        /// <summary>
        /// 检索指定窗口标题的长度
        /// </summary>
        /// <param name="hWnd">指定的窗口句柄</param>
        /// <returns>
        /// 如果函数成功，则返回值是复制字符串的长度。<br/>
        /// 如果窗口没有标题，或者窗口句柄无效，则返回值为0
        /// </returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowTextLengthW", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>
        /// 如果指定窗口的标题栏存在，则将其文本复制到缓冲区中。
        /// </summary>
        /// <param name="hWnd">包含文本的窗口或控件的句柄</param>
        /// <param name="lpString">将接收文本的缓冲区。如果字符串长度大于缓冲区，则字符串将被截断</param>
        /// <param name="nMaxCount">要复制到缓冲区的最大字符数</param>
        /// <returns>
        /// 如果函数成功，则返回值是复制字符串的长度。<br/>
        /// 如果窗口没有标题，或者窗口句柄无效，则返回值为0
        /// </returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowTextW", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// 检索指定窗口的边界矩形的尺寸。
        /// </summary>
        /// <param name="hWnd">指定窗口的句柄</param>
        /// <param name="lpRect">指向 RECT 结构的指针，用于接收窗口左上角和右下角的屏幕坐标。</param>
        /// <returns>true:函数执行成功</returns>
        /// <remarks><see cref="GetWindowRect"/>已虚拟化为DPI</remarks>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        /// <summary>
        /// 检索指定窗口所属的类名称
        /// </summary>
        /// <param name="hWnd">指定的窗口句柄</param>
        /// <param name="lpString">存放类名称的缓冲区</param>
        /// <param name="nMaxCount">缓冲区的长度</param>
        /// <returns>
        /// 如果函数成功，则返回值是复制到缓冲区的字符长度<br/>
        /// 如果函数失败，则返回值为0。
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetClassNameW")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// 确定指定窗口句柄是否标识窗口
        /// </summary>
        /// <param name="hWnd">要测试的窗口句柄</param>
        /// <returns>true:窗口句柄标识窗口</returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindow(IntPtr hWnd);

        /// <summary>
        /// 确定指定的窗口是否最小化
        /// </summary>
        /// <param name="hWnd">要测试的窗口句柄</param>
        /// <returns>true:是最小化</returns>
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        /// 确定指定的窗口是否最大化
        /// </summary>
        /// <param name="hWnd">要测试的窗口句柄</param>
        /// <returns>true:是最大化</returns>
        [DllImport("user32.dll")]
        public static extern bool IsZoom(IntPtr hWnd);

        /// <summary>
        /// 检索桌面窗口的句柄。<br/>
        /// 桌面窗口覆盖整个屏幕。<br/>
        /// 桌面窗口是绘制其他窗口顶部的区域。
        /// </summary>
        /// <returns>桌面窗口的句柄</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// 检索Shell桌面窗口的句柄。<br/>
        /// </summary>
        /// <returns>Shell桌面窗口的句柄。如果没有Shell进程，则返回值为NULL。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetShellWindow();

        /// <summary>
        /// 检索指定窗口的上级句柄。
        /// </summary>
        /// <param name="hWnd">要检索其上级窗口的句柄。</param>
        /// <param name="gaFlags">要检索的上级</param>
        /// <returns>上级窗口的句柄</returns>
        /// <remarks>
        /// <paramref name="hWnd"/>是桌面窗口句柄，则该函数返回NULL。
        /// </remarks>
        [DllImport("user32.dll")]
        public static extern IntPtr GetAncestor(IntPtr hWnd, GA gaFlags);

        /// <summary>
        /// 检索前台窗口的句柄。
        /// </summary>
        /// <returns>前台窗口的句柄，窗口丢失激活时，返回值可能为NULL</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// 检指定窗口的索显示状态和已还原、最小化和最大化的位置。
        /// </summary>
        /// <param name="hWnd">指定窗口的句柄</param>
        /// <param name="lpwndpl"><see cref="WINDOWPLACEMENT"/></param>
        /// <returns>true:函数成功</returns>
        /// <remarks>
        /// <paramref name="lpwndpl"/>的Length成员必须设置未 sizeof(WINDOWPLACEMENT)，否则函数将失败。
        /// </remarks>
        [DllImport("user32.dll")]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// 检索指定窗口的父或所有者的句柄。
        /// </summary>
        /// <param name="hWndChild">要检索其父窗口句柄的窗口的句柄</param>
        /// <returns>
        /// 如果窗口是子窗口，则返回值是父窗口的句柄<br/>
        /// 如果窗口具有<see cref="WS.POPUP"/>样式的顶级窗口，则返回值是所有者窗口的句柄,br/>
        /// 如果函数失败，则返回值为NULL。
        /// </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWndChild);

        /// <summary>
        /// 检索指定窗口的相关信息
        /// </summary>
        /// <param name="hWnd">窗口的句柄</param>
        /// <param name="attribute">指定的窗口参数</param>
        /// <returns>
        /// 成功，返回值为请求的值<br/>
        /// 失败，则返回值为0.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern uint GetWindowLong(IntPtr hWnd, GWL attribute);

        /// <summary>
        /// 如果窗口附加到调用线程的消息队列，则检索具有键盘焦点的窗口的句柄。
        /// </summary>
        /// <returns>返回值是具有键盘焦点的窗口的句柄。 如果调用线程的消息队列没有与键盘焦点关联的窗口，则返回值为 NULL。</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();

        #endregion

        #region 窗口操作

        /// <summary>
        /// 将键盘焦点设置为指定的窗口。 该窗口必须附加到调用线程的消息队列。
        /// </summary>
        /// <param name="hWnd">将键盘焦点设置为指定的窗口。 该窗口必须附加到调用线程的消息队列。</param>
        /// <returns>
        /// 如果函数成功，则返回值是以前具有键盘焦点的窗口的句柄。 <br/>
        /// 如果 hWnd 参数无效或窗口未附加到调用线程的消息队列，则返回值为 NULL。 
        /// </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        /// <summary>
        /// 更改指定窗口的属性
        /// </summary>
        /// <param name="hWnd">窗口的句柄</param>
        /// <param name="attribute"><see cref="GWL"/></param>
        /// <param name="value">新的属性值</param>
        /// <returns>返回值为0时，函数执行失败</returns>
        [DllImport("user32.dll")]
        public static extern uint SetWindowLong(IntPtr hWnd, GWL attribute, uint value);

        /// <summary>
        /// 设置指定窗口的显示状态
        /// </summary>
        /// <param name="hWnd">窗口的句柄</param>
        /// <param name="nCmdShow">控制窗口的显示方式</param>
        /// <returns>
        /// 如果窗口以前可见，则返回值为非零<br/>
        /// 如果窗口之前已隐藏，则返回值为零
        /// </returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, SW nCmdShow);

        /// <summary>
        /// 设置指定窗口的显示状态，无需等待操作完成
        /// </summary>
        /// <param name="hWnd">窗口的句柄</param>
        /// <param name="nCmdShow">控制窗口的显示方式</param>
        /// <returns>
        /// 如果窗口以前可见，则返回值为非零<br/>
        /// 如果窗口之前已隐藏，则返回值为零
        /// </returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, SW nCmdShow);

        /// <summary>
        /// 更改指定子窗口的父窗口
        /// </summary>
        /// <param name="hWndChild">子窗口的句柄</param>
        /// <param name="hWndParent">父窗口的句柄</param>
        /// <returns></returns>
        /// <remarks>
        /// hWndParent 为NULL，桌面窗口将成为新的父窗口。<br/>
        /// hWndParent 为<see cref="WinArgs.HWND_MESSAGE"/>,则子窗口将成为 Message-Only 窗口
        /// </remarks>
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndParent);

        /// <summary>
        /// 激活窗口
        /// </summary>
        /// <param name="hWnd">要激活的窗口句柄</param>
        /// <returns>
        /// 如果成功,返回值是以前处于活动状态的窗口句柄<br/>
        /// 如果失败，返回值为NULL。
        /// </returns>
        /// <remarks>
        /// 如果应用程序在后台，则不会激活。
        /// </remarks>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);

        /// <summary>
        /// 将指定窗口的线程置于前台并激活该窗口
        /// </summary>
        /// <param name="hWnd">应激活并置于前台的窗口句柄</param>
        /// <returns>true:成功将指定窗口置于前台</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 更改子窗口、弹出窗口或顶级窗口的大小、位置和 Z 顺序。
        /// </summary>
        /// <param name="hWnd">窗口的句柄。</param>
        /// <param name="hWndInsertAfter">窗口的句柄，位于按 Z 顺序排列的定位窗口之前。必须是窗口句柄或者是<see cref="WinArgs.HWND_BOTTOM"/> | <see cref="WinArgs.HWND_NOTTOPMOST"/> | <see cref="WinArgs.HWND_TOP"/> | <see cref="WinArgs.HWND_TOPMOST"/></param>
        /// <param name="x">窗口左侧的新位置，在客户端坐标中</param>
        /// <param name="y">窗口顶部的新位置，位于客户端坐标中。</param>
        /// <param name="cx">窗口的新宽度（以像素为单位）。</param>
        /// <param name="cy">窗口的新高度（以像素为单位）。</param>
        /// <param name="uFlags">窗口大小调整和定位标志</param>
        /// <returns>true:调用成功</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SWP uFlags);

        #endregion

        #region 通用方法

        /// <summary>
        /// 获取系统错误信息
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

        #endregion
    }
}
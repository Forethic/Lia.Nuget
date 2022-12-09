using System;

namespace Lia.Win32
{
    /// <summary>
    /// Win32 常用常量
    /// </summary>
    public class WinArgs
    {
        /// <value>-1</value>
        public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        /// <summary>
        /// 广播
        /// </summary>
        /// <value>0xFFFF</value>
        public static readonly IntPtr HWND_BROADCAST = new IntPtr(0xFFFF);

        /// <summary>
        /// 专用于消息回调窗口的窗口标识
        /// </summary>
        /// <value>-3</value>
        public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

        #region SendWindowPos

        /// <summary>
        /// 将窗口放在 Z 顺序的底部。<br/>
        /// 如果hWnd参数标识最顶层的窗口，则该窗口将失去其最顶层的状态，并放置在所有其他窗口的底部。
        /// </summary>
        /// <value>1</value>
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        /// <summary>
        /// 将窗口放在 Z 顺序的顶部。
        /// </summary>
        /// <value>0</value>
        public static readonly IntPtr HWND_TOP = new IntPtr(0);

        /// <summary>
        /// 将窗口置于所有非最顶层窗口的上方。即使停用窗口，窗口也会保持其最顶层位置。
        /// </summary>
        /// <value>-1</value>
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        /// <summary>
        /// 将窗口置于所有非最顶层窗口的上方（即，在所有最顶层窗口的后面）。如果窗口已经是非最顶层的窗口，则此标志不起作用。
        /// </summary>
        /// <value>-2</value>
        public static readonly IntPtr HWND_NOTTOPMOST = new IntPtr(-2);

        #endregion
    }
}
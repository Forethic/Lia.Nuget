using System;

namespace Lia.Win32
{
    /// <summary>
    /// 窗口类Win32封装工具
    /// </summary>
    public static class WindowUtil
    {
        /// <summary>
        /// 窗口在Alt+Tab时隐藏
        /// </summary>
        /// <param name="handle">窗口句柄</param>
        public static void HideOnAltTab(IntPtr handle)
        {
            var exStyle = WinApi.GetWindowLong(handle, GWL.EXSTYLE);
            exStyle |= (uint)WSEX.TOOLWINDOW;
            exStyle &= ~(uint)WSEX.APPWINDOW;
            WinApi.SetWindowLong(handle, GWL.EXSTYLE, exStyle);
        }

        /// <summary>
        /// 给指定窗口设定所有者窗口
        /// </summary>
        /// <param name="hWndChild">指定窗口的句柄</param>
        /// <param name="hWndOwner">要设定的所有者窗口的句柄</param>
        public static void SetOwner(IntPtr hWndChild, IntPtr hWndOwner)
        {
            // 不需要找，窗口句柄不存在
            if (hWndChild == null || hWndChild == IntPtr.Zero) { return; }

            var ownerHandle = WinApi.GetWindow(hWndChild, GW.OWNER);
            if (ownerHandle == hWndOwner && ownerHandle == IntPtr.Zero)
            {
                // 没有找到所有者句柄，并且设定的所有者句柄也是空的，不需要设定了
                return;
            }

            ownerHandle = (hWndOwner == IntPtr.Zero)
                         ? IntPtr.Zero
                         : hWndOwner;

            var res = WinApi.SetWindowLong(hWndChild, GWL.HWNDPARENT, (uint)ownerHandle);
            // TODO: Log Error
        }
    }
}
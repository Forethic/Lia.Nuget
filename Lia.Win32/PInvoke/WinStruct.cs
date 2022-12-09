using System.Runtime.InteropServices;

namespace Lia.Win32
{
    /// <summary>
    /// 按其左上角和右下角的坐标定义矩形
    /// </summary>
    public struct RECT
    {
        /// <summary>
        /// 指定矩形左上角的x坐标
        /// </summary>
        public int Left;

        /// <summary>
        /// 指定矩形左上角的y坐标
        /// </summary>
        public int Top;

        /// <summary>
        /// 指定矩形右下角的x坐标
        /// </summary>
        public int Right;

        /// <summary>
        /// 指定矩形右下角的y坐标
        /// </summary>
        public int Bottom;
    }

    /// <summary>
    /// 定义点的x坐标和y坐标
    /// </summary>
    public struct POINT
    {
        /// <summary>
        /// 指定点的 x 坐标。
        /// </summary>
        public int X;

        /// <summary>
        /// 指定点的 y 坐标。
        /// </summary>
        public int Y;
    }

    /// <summary>
    /// 包含有关窗口在屏幕上的位置的信息。
    /// </summary>
    /// <remarks>
    /// 如果窗口没有<see cref="WSEX.TOOLWINDOW"/>样式的顶级窗口，则由以下成员表示的坐标是位于工作区坐标中：<see cref="WINDOWPLACEMENT.MinPosition"/>、<see cref="WINDOWPLACEMENT.MaxPosition"/>和<see cref="WINDOWPLACEMENT.NormalPosition"/>。<br/>
    /// 否则这些成员位于屏幕坐标中<br/>
    /// 工作区坐标与屏幕坐标的不同在于，包括任务栏。
    /// </remarks>
    public struct WINDOWPLACEMENT
    {
        /// <summary>
        /// 结构的长度
        /// </summary>
        /// <remarks>
        /// 在调用 <see cref="WinApi.GetWindowPlacement"/>或<see cref="WinApi.SetWindowPlacement"/>之前，将此成员设置为sizeof(WINDOWPLACEMENT)<br/>
        /// 如果未正确设置此成员，<see cref="WinApi.GetWindowPlacement"/>或<see cref="WinApi.SetWindowPlacement"/>将失败。
        /// </remarks>
        public int Length;

        /// <summary>
        /// 控制最小化窗口的位置以及还原窗口的方法的标志。
        /// </summary>
        /// <remarks>可以是<see cref="WPF"/>的单个值或者是组合值</remarks>
        public WPF Flags;

        /// <summary>
        /// 窗口的当前显示状态。
        /// </summary>
        public SW ShowCmd;

        /// <summary>
        /// 窗口最小化时窗口左上角的坐标。
        /// </summary>
        public POINT MinPosition;

        /// <summary>
        /// 窗口最大化时窗口左上角的坐标。
        /// </summary>
        public POINT MaxPosition;

        /// <summary>
        /// 窗口处于还原位置时的窗口坐标。
        /// </summary>
        public RECT NormalPosition;

        /// <summary>
        /// 默认值
        /// </summary>
        public static WINDOWPLACEMENT Default
        {
            get
            {
                var result = new WINDOWPLACEMENT();
                result.Length = Marshal.SizeOf(result);
                return result;
            }
        }
    }
}
using BrightIdeasSoftware;
using System.Windows.Forms;

namespace NetStalker
{
    public interface IView
    {
        FastObjectListView DeviceListView { get; }
        Main MainForm { get; }
        PictureBox PictureBox { get; }
        PictureBox LoadingBar { get; }
        Label DeviceCountIndicator { get; }
        Label CurrentOperationStatusIndicator { get; }
        Button SnifferToggle { get; }
        Button LimiterToggle { get; }
    }
}

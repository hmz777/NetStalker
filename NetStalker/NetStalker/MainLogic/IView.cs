using BrightIdeasSoftware;
using System.Windows.Forms;

namespace NetStalker
{
    public interface IView
    {
        FastObjectListView ListView1 { get; }
        Form MainForm { get; }
        Label StatusLabel { get; }
        PictureBox PictureBox { get; }
        PictureBox LoadingBar { get; }
        Label StatusLabel2 { get; }
        ToolTip TTip { get; }
        Button Tile { get; }
        Button Tile2 { get; }
    }
}

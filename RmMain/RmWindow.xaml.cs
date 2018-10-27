using RmMain.Properties;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace RmMain
{
    /// <summary>
    /// RmWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RmWindow : Window
    {
        Timer t = new Timer();
        public RmWindow()
        {
            InitializeComponent();
            t.Interval = Settings.Default.Spend;
            t.Tick += delegate {
                if (forInt != Settings.Default.Count)
                {
                    forInt++;
                    tb.Text = forInt.ToString();
                }
                else forInt = 0;
            };
        }
        private int forInt = 0;
        private bool isRunning = false;
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isRunning)
                t.Stop();
            else t.Start();
            isRunning = !isRunning;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var ani = Resources["Stop"] as Storyboard;
            ani.Completed += (s, ex) => { Close(); };
            ani.Begin();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}

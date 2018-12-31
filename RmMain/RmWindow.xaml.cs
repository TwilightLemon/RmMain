using RmMain.Properties;
using System;
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
        private Random rd = new Random();
        private int index = 0;
        public RmWindow()
        {
            InitializeComponent();
            t.Interval = Settings.Default.Spend;
            t.Tick += delegate
            {
                tb.Text = rd.Next(1, Settings.Default.Count).ToString();
            };
        }
        public RmWindow(int ix)
        {
            InitializeComponent();
            forInt = ix;
            tb.Text = ix.ToString();
            t.Interval = Settings.Default.Spend;
            t.Tick += delegate
            {
                tb.Text = rd.Next(1, Settings.Default.Count).ToString();
            };
        }
        private int forInt = 0;
        private bool isRunning = false;
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (isRunning)
            {
                t.Stop();
                if (App.list.Count != 0)
                {
                    tb.Text = App.list[index].ToString();
                    index++;
                    if (index >= App.list.Count) { index = 0; App.list.Clear(); }
                }
            }
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

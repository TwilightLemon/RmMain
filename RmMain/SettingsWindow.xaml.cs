using RmMain.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RmMain
{
    /// <summary>
    /// SettingsWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            jd.Value=Settings.Default.Spend;
            ps.Text = Settings.Default.Count.ToString();
            jd.ValueChanged += Slider_ValueChanged;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Default.Spend = (int)jd.Value;
        }

        private void ps_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(int.TryParse(ps.Text, out int i))
                Settings.Default.Count=i;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.Save();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] str = sd.Text.Split(';');
            foreach (var st in str)
                App.list.Add(int.Parse(st));
        }
    }
}

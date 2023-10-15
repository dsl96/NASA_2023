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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GUI.Mvvm.VM;

namespace GUI.MVVM.View.UserControlls
{
    /// <summary>
    /// Interaction logic for DailyImgUserControl.xaml
    /// </summary>
    public partial class DailyImgUserControl : UserControl
    {

        private readonly DailyImgVM vm;
        public DailyImgUserControl()
        {
            vm = new DailyImgVM();
            InitializeComponent();
            DataContext = vm;
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;

            if (e.Delta > 0)
            {
                // Scroll up
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - 10);
            }
            else
            {
                // Scroll down
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + 10);
            }

            // Mark the event as handled to prevent the default scrolling behavior
            e.Handled = true;
        }
    }
}

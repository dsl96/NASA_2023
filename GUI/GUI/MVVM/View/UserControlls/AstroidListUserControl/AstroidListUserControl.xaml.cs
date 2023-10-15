using GUI.MVVM.ViewModel;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace GUI.MVVM.View.UserControlls
{
    public partial class AstroidListUserControl : UserControl
    {
        private readonly AstroidListVM vm;
        public ICollectionView CollectionView { get; set; }

        public AstroidListUserControl()
        {
            vm = new AstroidListVM();
            DataContext = vm;
            InitializeComponent();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            if (e.Delta > 0)
            {
                // Scroll up
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - 20);
            }
            else
            {
                // Scroll down
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + 20);
            }

            // Mark the event as handled to prevent the default scrolling behavior
            e.Handled = true;
        }

    }
}



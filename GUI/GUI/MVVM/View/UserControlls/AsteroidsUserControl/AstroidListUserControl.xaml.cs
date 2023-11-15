using GUI.MVVM.Model;
using GUI.MVVM.ViewModel;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI.MVVM.View.UserControlls
{
    public partial class AstroidListUserControl : UserControl
    {
        private ICollectionView collectionView { get; set; }
        public AstroidListUserControl()
        {
            AstroidListVM _vm = new AstroidListVM();
            this.DataContext = _vm;
            InitializeComponent();
            collectionView = CollectionViewSource.GetDefaultView(_vm.DataAstroidList);
            this.collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Key"));

        }

        private void SelectGrouping(object sender, SelectionChangedEventArgs e)
        {
            string selected = (string)((ComboBox)sender).SelectedItem;
            collectionView.GroupDescriptions.Clear();
            switch (selected)
            {
                case "Key":
                    collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Key"));
                    break;

                case "Hazardous":
                    collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Value.IsPotentiallyHazardousAsteroid"));
                    break;
                case "Senty":
                    collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Value.IsSentryObject"));
                    break;
                default:
                    collectionView.GroupDescriptions.Add(new PropertyGroupDescription("None"));
                    break;
            }

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

        private void PlayMedia(object sender, RoutedEventArgs e)
        {
            var mediaElement = (MediaElement)sender;
            mediaElement.Position = TimeSpan.FromSeconds(2);
            mediaElement.Play();
        }
    }
}



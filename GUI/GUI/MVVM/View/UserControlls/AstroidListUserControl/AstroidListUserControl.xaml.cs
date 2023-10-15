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
    }
}



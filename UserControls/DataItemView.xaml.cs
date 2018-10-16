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

namespace DiagramDesigner.UserControls
{
    /// <summary>
    /// DataItemUC.xaml 的交互逻辑
    /// </summary>
    public partial class DataItemView : UserControl
    {
        public DataItemView()
        {
            InitializeComponent();
        }


        public Visibility SaveVisibility
        {
            get { return (Visibility)GetValue(SaveVisibilityProperty); }
            set { SetValue(SaveVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SaveVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SaveVisibilityProperty =
            DependencyProperty.Register("SaveVisibility", typeof(Visibility), typeof(DataItemView), new PropertyMetadata(Visibility.Visible));


        public Visibility ExecuteVisibility
        {
            get { return (Visibility)GetValue(ExecuteVisibilityProperty); }
            set { SetValue(ExecuteVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExecuteVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExecuteVisibilityProperty =
            DependencyProperty.Register("ExecuteVisibility", typeof(Visibility), typeof(DataItemView), new PropertyMetadata(Visibility.Visible));


        public Visibility AddVisibility
        {
            get { return (Visibility)GetValue(AddVisibilityProperty); }
            set { SetValue(AddVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddVisibilityProperty =
            DependencyProperty.Register("AddVisibility", typeof(Visibility), typeof(DataItemView), new PropertyMetadata(Visibility.Visible));


        public Visibility DeleteVisibility
        {
            get { return (Visibility)GetValue(DeleteVisibilityProperty); }
            set { SetValue(DeleteVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteVisibilityProperty =
            DependencyProperty.Register("DeleteVisibility", typeof(Visibility), typeof(DataItemView), new PropertyMetadata(Visibility.Visible));


        public Visibility SelectVisibility
        {
            get { return (Visibility)GetValue(SelectVisibilityProperty); }
            set { SetValue(SelectVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectVisibilityProperty =
            DependencyProperty.Register("SelectVisibility", typeof(Visibility), typeof(DataItemView), new PropertyMetadata(Visibility.Collapsed));


    }
}

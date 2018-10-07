using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DiagramDesigner.Controls
{
    /// <summary>
    /// Label_Dragable.xaml 的交互逻辑
    /// </summary>
    public partial class Label_Dragable : UserControl
    {
        public Label_Dragable()
        {
            InitializeComponent();
            //int i= VisualTreeHelper.GetChildrenCount(this);
        }

        private string _content;

        //public string Text
        //{
        //    get { return _content; }
        //    set
        //    {
        //        Label_Dragable lb = this as Label_Dragable;
        //        lb.dragLabel.Content = _content = value;
        //        //int count = VisualTreeHelper.GetChildrenCount(this);
        //        //Label _label= VisualTreeHelper.GetChild(this, 0) as Label;
        //        //if (_label != null)
        //        //{
        //        //this..Content = _content = value;
        //        //}
        //    }
        //}

        [BrowsableAttribute(true)]
        [ReadOnlyAttribute(false)]
        [DisplayName("TextAAAA")]
        public string TextAAAA { get; set; }


        [BrowsableAttribute(true)]
        [ReadOnlyAttribute(false)]
        [DisplayName("Text")]
        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="MyProperty" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text",
            typeof(string),
            typeof(Label_Dragable),
            new FrameworkPropertyMetadata("设计中"));


    }
}

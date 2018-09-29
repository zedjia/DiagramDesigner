using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using DevExpress.Xpf.Grid;
using DiagramDesigner;
using WpfApplication1.Annotations;

namespace WpfApplication1
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public List<testdata> Datalist { get; set; }
        public Window2()
        {
            InitializeComponent();
                //SetConnectorDecoratorTemplate();
            this.DataContext = this;

            this.Loaded += (s, e) =>
            {
                Datalist=new List<testdata>()
                {
                    new testdata()
                    {
                        name = "ceshishuju1"
                    },
                    new testdata()
                    {
                        name = "ceshishuju2"
                    },
                };
                Binding binding=new Binding()
                {
                    Source = this.Datalist,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,

                };
                DataGrid.SetBinding(DataControlBase.ItemsSourceProperty, binding);
            };
        }

        private void SetConnectorDecoratorTemplate()
        {
            var item = DesignerItem;
//            if (item.ApplyTemplate() && item.Content is UIElement)
//            {
                ControlTemplate template = DesignerItem.GetConnectorDecoratorTemplate(item.Content as UIElement);
                Control decorator = item.Template.FindName("PART_ConnectorDecorator", item) as Control;
                if (decorator != null && template != null)
                    decorator.Template = template;
            //}
            item.IsSelected = true;
        }


       
    }
    public class testdata: INotifyPropertyChanged
    {
        private string _name;

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public int Length => _name.Length;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

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

namespace DiagramDesigner.Windows.WindDataSource
{
    /// <summary>
    /// WDataSource.xaml 的交互逻辑
    /// </summary>
    public partial class WDataSource : Window
    {
        public DataSourceConnModel dataSourceModel { get; set; }

        public WDataSource()
        {
            InitializeComponent();
            dataSourceModel = new DataSourceConnModel(){DBAlias = "test",DBConnUrl = "aaa"};
            this.DataContext = dataSourceModel;



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }


    public enum DataSourceType
    {
        Database,
        Interface
    }

    public class DataSourceConnModel
    {
        public Guid Id { get; set; }
        public DataSourceType Type { get; set; }
        public string DBType { get; set; }
        public string DBAlias { get; set; }
        public string DBConnUrl { get; set; }
        public bool ConnStatus { get; set; }
    }
}

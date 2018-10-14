using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace DiagramDesigner.Windows.WindDataSource
{
    /// <summary>
    /// WDataSource.xaml 的交互逻辑
    /// </summary>
    public partial class DataSourceView : Window
    {
        public DataSourceView()
        {
            InitializeComponent();
            this.Closing += DataSourceView_Closing;
        }

        private void DataSourceView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataSourceViewBindingModel Context = this.DataContext as DataSourceViewBindingModel;
            if (Context != null) Context.CloseForm();
        }
        
        
    }
}

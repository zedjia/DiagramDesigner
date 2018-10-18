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
using DevExpress.Xpf.Core;
using DiagramDesigner.UserControls;

namespace DiagramDesigner.Windows.WindDataSource
{
    /// <summary>
    /// WDataSource.xaml 的交互逻辑
    /// </summary>
    public partial class DataSourceView : DXWindow
    {
        public DataSourceView()
        {
            InitializeComponent();
            this.Closing += DataSourceView_Closing;
            dataSourceTabContrl.SelectedIndex = 0;
        }

        private void DataSourceView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataSourceViewBindingModel Context = this.DataContext as DataSourceViewBindingModel;
            bool result = false;
            if (Context != null) result = Context.CloseForm();
            if (!result)
            {
                MessageBox.Show("数据配置保存失败,请重新尝试或者联系管理员", "提示");
                e.Cancel = true;
            }

        }
        

        private void dataSourceTabContrl_Loaded(object sender, RoutedEventArgs e)
        {
            DataSourceViewBindingModel Context = this.DataContext as DataSourceViewBindingModel;
            if (Context == null)
            {
                return;
            }
            Context.CloseForm();// 这里必须要保存一次配置到文件，所以调用一次这个方法.
            dataSourceTabContrl.Items.Clear();


            var dataSources = Context.dataSourceModels.OrderBy(i => i.Sort);
            foreach (var dataSourceModel in dataSources)
            {
                DataItemView uc = new DataItemView();
                uc.DataContext = new DataItemViewModel() {TabDataSourceModel = dataSourceModel,SetSqlExecResult = Context.SetSqlExecResult};
                TabItem tabItem = new TabItem() {Header = $"{dataSourceModel.DBAlias}({dataSourceModel.DBType})"};
                tabItem.Style = (Style)this.FindResource("TabItemStyle");
                //tabItem.RegisterName($"uc{dataSourceModel.Id}", uc);
                tabItem.Content = uc;
                dataSourceTabContrl.Items.Add(tabItem);
            }
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}

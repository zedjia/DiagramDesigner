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

        /// <summary>
        /// 外侧tab change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSourceViewBindingModel Context = this.DataContext as DataSourceViewBindingModel;
            if (Context == null)
            {
                return;
            }
            Context.CloseForm();// 这里必须要保存一次配置到文件，所以调用一次这个方法.

            var dataSources = Context.dataSourceModels.OrderBy(i => i.Sort);
            //以下是测试代码
            if(dataSources.Count()<3)
                return;
            
            var tmpdata = dataSources.Take(dataSourceTabContrl.Items.Count).ToArray();
            for (int i=0;i<dataSourceTabContrl.Items.Count;i++)
            {
                TabItem tabiemp = dataSourceTabContrl.Items[i] as TabItem;
                tabiemp.Header = $"{tmpdata[i].DBType}({tmpdata[i].DBAlias})";
            }
            tmpdata=dataSources.Skip(dataSourceTabContrl.Items.Count).ToArray();
            foreach (var i in tmpdata)
            {
                dataSourceTabContrl.Items.Add(new TabItem() {Header = $"{i.DBType}({i.DBAlias})"});
            }
        }
    }
}

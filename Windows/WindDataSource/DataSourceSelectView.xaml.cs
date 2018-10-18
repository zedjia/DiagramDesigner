using DevExpress.Xpf.Core;
using DiagramDesigner.CustomControls.Charts;
using DiagramDesigner.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// DataSourceConfigView.xaml 的交互逻辑
    /// </summary>
    public partial class DataSourceSelectView : DXWindow
    {
        private IChartViewModel ChartViewModel;
        public DataSourceSelectView()
        {
            InitializeComponent();
        }
        public DataSourceSelectView(IChartViewModel chartViewModel)
        {
            InitializeComponent();

            ChartViewModel = chartViewModel;
        }

        private void dataSourceTabContrl_Loaded(object sender, RoutedEventArgs e)
        {
            DataSourceSelectViewModel Context = this.DataContext as DataSourceSelectViewModel;

            var dataSources = Context.dataSourceModels.OrderBy(i => i.Sort);
            foreach (var dataSourceModel in dataSources)
            {
                DataItemView uc = new DataItemView();
                uc.DataContext = new DataItemViewModel() { TabDataSourceModel = dataSourceModel, SetSqlExecResult = Context.SetSqlExecResult,ChartViewModel= ChartViewModel };
                uc.AddVisibility = Visibility.Collapsed;
                uc.DeleteVisibility = Visibility.Collapsed;
                uc.SaveVisibility = Visibility.Collapsed;
                uc.SelectVisibility = Visibility.Visible;
                TabItem tabItem = new TabItem() { Header = $"{dataSourceModel.DBAlias}({dataSourceModel.DBType})" };
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

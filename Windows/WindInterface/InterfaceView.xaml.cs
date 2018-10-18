using DevExpress.Xpf.Core;
using DiagramDesigner.CustomControls.Charts;
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

namespace DiagramDesigner.Windows.WindInterface
{
    /// <summary>
    /// InterfaceView.xaml 的交互逻辑
    /// </summary>
    public partial class InterfaceView : DXWindow
    {
        private IChartViewModel ChartViewModel;
        public InterfaceView()
        {
            InitializeComponent();

            this.Loaded += InterfaceView_Loaded;
            this.Closing += InterfaceView_Closing;
        }
        public InterfaceView(IChartViewModel chartViewModel)
        {
            InitializeComponent();

            ChartViewModel = chartViewModel;

            this.Loaded += InterfaceView_Loaded;
            this.Closing += InterfaceView_Closing;
        }

        private void InterfaceView_Loaded(object sender, RoutedEventArgs e)
        {
            var dc = this.DataContext as InterfaceViewModel;
            dc.ChartViewModel = ChartViewModel;
        }

        private void InterfaceView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InterfaceViewModel Context = this.DataContext as InterfaceViewModel;
            bool result = false;
            if (Context != null) result = Context.CloseForm();
            if (!result)
            {
                MessageBox.Show("数据配置保存失败,请重新尝试或者联系管理员", "提示");
                e.Cancel = true;
            }
        }
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}

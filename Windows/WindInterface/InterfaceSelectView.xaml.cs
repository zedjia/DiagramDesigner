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
    /// InterfaceSelectView.xaml 的交互逻辑
    /// </summary>
    public partial class InterfaceSelectView : DXWindow
    {
        private IChartViewModel ChartViewModel;
        public InterfaceSelectView()
        {
            InitializeComponent();

            this.Loaded += InterfaceView_Loaded;
        }
        public InterfaceSelectView(IChartViewModel chartViewModel)
        {
            InitializeComponent();

            ChartViewModel = chartViewModel;

            this.Loaded += InterfaceView_Loaded;
        }

        private void InterfaceView_Loaded(object sender, RoutedEventArgs e)
        {
            var dc = this.DataContext as InterfaceSelectViewModel;
            dc.ChartViewModel = ChartViewModel;
        }

        private void dataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}

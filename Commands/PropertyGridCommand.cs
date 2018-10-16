using DevExpress.Xpf.PropertyGrid;
using DiagramDesigner.CustomControls.Charts;
using DiagramDesigner.Windows.WindDataSource;
using DiagramDesigner.Windows.WindInterface;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiagramDesigner.Commands
{
    /// <summary>
    /// 属性栏命令
    /// </summary>
    public class PropertyGridCommand
    {
        /// <summary>
        /// 单柱状图数据源配置
        /// </summary>
        public ICommand SingleHisDSCmd => new DelegateCommand<PropertyGridControl>(SingleHisDS);

        void SingleHisDS(PropertyGridControl propertyGridControl)
        {
            if (propertyGridControl != null)
            {
                SingleHisChart singleHisChart = propertyGridControl.SelectedObject as SingleHisChart;
                if (singleHisChart != null)
                {
                    SingleHisViewModel singleHisViewModel = singleHisChart.DC as SingleHisViewModel;
                    DataSourceConfigView dataSourceConfigView = new DataSourceConfigView(singleHisViewModel);
                    MainView mainWindow = ((((propertyGridControl.Parent as Grid).Parent as Grid).Parent) as Grid).Parent as MainView;
                    //MainView mainWindow = frameworkElement.FindName("mainWindow") as MainView;
                    dataSourceConfigView.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    dataSourceConfigView.Owner = mainWindow;
                    dataSourceConfigView.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 单柱状图数据源接口配置
        /// </summary>
        public ICommand SingleHisDTCmd => new DelegateCommand<PropertyGridControl>(SingleHisDT);

        void SingleHisDT(PropertyGridControl propertyGridControl)
        {
            if (propertyGridControl != null)
            {
                SingleHisChart singleHisChart = propertyGridControl.SelectedObject as SingleHisChart;
                if (singleHisChart != null)
                {
                    SingleHisViewModel singleHisViewModel = singleHisChart.DC as SingleHisViewModel;
                    InterfaceView interfaceView = new InterfaceView();
                    MainView mainWindow = ((((propertyGridControl.Parent as Grid).Parent as Grid).Parent) as Grid).Parent as MainView;
                    //MainView mainWindow = frameworkElement.FindName("mainWindow") as MainView;
                    interfaceView.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    interfaceView.Owner = mainWindow;
                    interfaceView.ShowDialog();
                }
            }
        }
    }
}

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
            ConfigDataSource(propertyGridControl);
        }

        /// <summary>
        /// 单柱状图数据源接口配置
        /// </summary>
        public ICommand SingleHisDTCmd => new DelegateCommand<PropertyGridControl>(SingleHisDT);

        void SingleHisDT(PropertyGridControl propertyGridControl)
        {
            ConfigDataInterface(propertyGridControl);
        }
        /// <summary>
        /// 配置数据源
        /// </summary>
        /// <param name="propertyGridControl"></param>
        private void ConfigDataSource(PropertyGridControl propertyGridControl)
        {
            if (propertyGridControl != null)
            {
                IChartControl chartControl = propertyGridControl.SelectedObject as IChartControl;
                if (chartControl != null)
                {
                    IChartViewModel singleHisViewModel = chartControl.ChartViewModel;
                    DataSourceSelectView dataSourceConfigView = new DataSourceSelectView(singleHisViewModel);
                    OpenConfigWindow(propertyGridControl, dataSourceConfigView);
                }
            }
        }
        /// <summary>
        /// 配置数据接口
        /// </summary>
        /// <param name="propertyGridControl"></param>
        private void ConfigDataInterface(PropertyGridControl propertyGridControl)
        {
            if (propertyGridControl != null)
            {
                IChartControl chartControl = propertyGridControl.SelectedObject as IChartControl;
                if (chartControl != null)
                {
                    IChartViewModel singleHisViewModel = chartControl.ChartViewModel;
                    InterfaceSelectView interfaceView = new InterfaceSelectView(singleHisViewModel);
                    OpenConfigWindow(propertyGridControl, interfaceView);
                }
            }
        }
        /// <summary>
        /// 打开配置窗体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyGridControl"></param>
        /// <param name="t"></param>
        private void OpenConfigWindow(PropertyGridControl propertyGridControl, Window window)
        {
            MainView mainWindow = (((((propertyGridControl.Parent as ScrollViewer).Parent as Grid).Parent) as Grid).Parent as Grid).Parent as MainView;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Owner = mainWindow;
            window.ShowDialog();
        }
    }
}

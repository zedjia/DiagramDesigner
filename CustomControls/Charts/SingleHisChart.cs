using DiagramDesigner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiagramDesigner.CustomControls.Charts
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:DiagramDesigner.CustomControls.Charts"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:DiagramDesigner.CustomControls.Charts;assembly=DiagramDesigner.CustomControls.Charts"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:SingleHisChart/>
    ///
    /// </summary>
    public class SingleHisChart : Control
    {
        static SingleHisChart()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SingleHisChart), new FrameworkPropertyMetadata(typeof(SingleHisChart)));
        }
        /// <summary>
        /// 柱状图颜色
        /// </summary>
        public Brush ChartColor
        {
            get { return (Brush)GetValue(ChartColorProperty); }
            set { SetValue(ChartColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChartColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChartColorProperty =
            DependencyProperty.Register("ChartColor", typeof(Brush), typeof(SingleHisChart), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0084FF"))));

        [DisplayName("数据源")]
        public SingleHisDataSource ChartSource
        {
            get { return (SingleHisDataSource)GetValue(ChartSourceProperty); }
            set { SetValue(ChartSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChartSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChartSourceProperty =
            DependencyProperty.Register("ChartSource", typeof(SingleHisDataSource), typeof(SingleHisChart), new PropertyMetadata(null));

        [DisplayName("图例文字")]
        public string DisplayName
        {
            get { return (string)GetValue(DisplayNameProperty); }
            set { SetValue(DisplayNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayNameProperty =
            DependencyProperty.Register("DisplayName", typeof(string), typeof(SingleHisChart), new PropertyMetadata("图例"));


        [DisplayName("DataContext")]
        public object DC
        {
            get { return (object)GetValue(DCProperty); }
            set { SetValue(DCProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DC.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DCProperty =
            DependencyProperty.Register("DC", typeof(object), typeof(SingleHisChart), new PropertyMetadata(new SingleHisViewModel()));


    }
}

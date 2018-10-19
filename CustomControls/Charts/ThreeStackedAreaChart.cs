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
    ///     <MyNamespace:ThreeStackedAreaChart/>
    ///
    /// </summary>
    public class ThreeStackedAreaChart : Control
    {
        static ThreeStackedAreaChart()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ThreeStackedAreaChart), new FrameworkPropertyMetadata(typeof(ThreeStackedAreaChart)));
        }
        /// <summary>
        /// 最上层图形颜色
        /// </summary>
        [DisplayName("最上层图形颜色")]
        public Brush AreaColor1
        {
            get { return (Brush)GetValue(AreaColor1Property); }
            set { SetValue(AreaColor1Property, value); }
        }

        // Using a DependencyProperty as the backing store for ChartColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AreaColor1Property =
            DependencyProperty.Register("AreaColor1", typeof(Brush), typeof(ThreeStackedAreaChart), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#91E9FD"))));

        /// <summary>
        /// 中间层图形颜色
        /// </summary>
        [DisplayName("中间层图形颜色")]
        public Brush AreaColor2
        {
            get { return (Brush)GetValue(AreaColor2Property); }
            set { SetValue(AreaColor2Property, value); }
        }

        // Using a DependencyProperty as the backing store for ChartColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AreaColor2Property =
            DependencyProperty.Register("AreaColor2", typeof(Brush), typeof(ThreeStackedAreaChart), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#38D8FD"))));

        /// <summary>
        /// 最下层图形颜色
        /// </summary>
        [DisplayName("最下层图形颜色")]
        public Brush AreaColor3
        {
            get { return (Brush)GetValue(AreaColor3Property); }
            set { SetValue(AreaColor3Property, value); }
        }

        // Using a DependencyProperty as the backing store for ChartColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AreaColor3Property =
            DependencyProperty.Register("AreaColor3", typeof(Brush), typeof(ThreeStackedAreaChart), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00C3EE"))));

        /// <summary>
        /// X轴文字颜色
        /// </summary>
        [DisplayName("X轴文字颜色")]
        public Brush XColor
        {
            get { return (Brush)GetValue(XColorProperty); }
            set { SetValue(XColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChartColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XColorProperty =
            DependencyProperty.Register("XColor", typeof(Brush), typeof(ThreeStackedAreaChart), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B7C4CF"))));

        /// <summary>
        /// Y轴文字颜色
        /// </summary>
        [DisplayName("Y轴文字颜色")]
        public Brush YColor
        {
            get { return (Brush)GetValue(YColorProperty); }
            set { SetValue(YColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChartColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YColorProperty =
            DependencyProperty.Register("YColor", typeof(Brush), typeof(ThreeStackedAreaChart), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B7C4CF"))));

        [DisplayName("数据源")]
        public IDataSourceModel ChartSource
        {
            get { return (IDataSourceModel)GetValue(ChartSourceProperty); }
            set { SetValue(ChartSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChartSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChartSourceProperty =
            DependencyProperty.Register("ChartSource", typeof(IDataSourceModel), typeof(ThreeStackedAreaChart), new PropertyMetadata(null));


        [DisplayName("DataContext")]
        public IChartViewModel ChartViewModel
        {
            get { return (IChartViewModel)GetValue(ChartViewModelProperty); }
            set { SetValue(ChartViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DC.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChartViewModelProperty =
            DependencyProperty.Register("ChartViewModel", typeof(IChartViewModel), typeof(ThreeStackedAreaChart), new PropertyMetadata(new StackedAreaViewModel()));
    }
}

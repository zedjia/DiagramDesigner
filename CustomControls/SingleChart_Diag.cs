using DevExpress.Xpf.Charts;
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

namespace DiagramDesigner.CustomControls
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:DiagramDesigner.CustomControls"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:DiagramDesigner.CustomControls;assembly=DiagramDesigner.CustomControls"
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
    ///     <MyNamespace:SingleChart_Diag/>
    ///
    /// 说明：单柱状图自定义控件、属性
    /// 作者：maxfish
    /// 时间：2018-10-7
    /// </summary>
    public class SingleChart_Diag : Control
    {
        static SingleChart_Diag()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SingleChart_Diag), new FrameworkPropertyMetadata(typeof(SingleChart_Diag)));
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(SingleChart_Diag), new PropertyMetadata("单柱状图"));
        /// <summary>
        /// 柱状图颜色
        /// </summary>
        public SolidColorBrush ChartColor
        {
            get { return (SolidColorBrush)GetValue(ChartColorProperty); }
            set { SetValue(ChartColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChartColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChartColorProperty =
            DependencyProperty.Register("ChartColor", typeof(SolidColorBrush), typeof(SingleChart_Diag), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#09B0B8"))));
        /// <summary>
        /// 图例文字
        /// </summary>
        public string DisplayName
        {
            get { return (string)GetValue(DisplayNameProperty); }
            set { SetValue(DisplayNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayNameProperty =
            DependencyProperty.Register("DisplayName", typeof(string), typeof(SingleChart_Diag), new PropertyMetadata("图例"));
        /// <summary>
        /// 标题颜色
        /// </summary>
        public SolidColorBrush TitleColor
        {
            get { return (SolidColorBrush)GetValue(TitleColorProperty); }
            set { SetValue(TitleColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleColorProperty =
            DependencyProperty.Register("TitleColor", typeof(SolidColorBrush), typeof(SingleChart_Diag), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#09B0B8"))));
        /// <summary>
        /// 标题大小
        /// </summary>
        [DisplayName("标题大小")]
        public double TitleSize
        {
            get { return (double)GetValue(TitleSizeProperty); }
            set { SetValue(TitleSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleSizeProperty =
            DependencyProperty.Register("TitleSize", typeof(double), typeof(SingleChart_Diag), new PropertyMetadata(15.0));


    }
}

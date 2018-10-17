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

namespace DiagramDesigner.CustomControls.Labels
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:DiagramDesigner.CustomControls.Labels"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:DiagramDesigner.CustomControls.Labels;assembly=DiagramDesigner.CustomControls.Labels"
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
    ///     <MyNamespace:Label1/>
    ///
    /// </summary>
    public class Label1 : Control
    {
        static Label1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Label1), new FrameworkPropertyMetadata(typeof(Label1)));
        }
        #region 类型
        [DisplayName("文字")]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Label1), new PropertyMetadata("文字"));

        [DisplayName("字体")]
        public FontFamily TextFontFamily
        {
            get { return (FontFamily)GetValue(TextFontFamilyProperty); }
            set { SetValue(TextFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextFontFamilyProperty =
            DependencyProperty.Register("TextFontFamily", typeof(FontFamily), typeof(Label1), new PropertyMetadata(new FontFamily("微软雅黑")));



        [DisplayName("文字颜色")]
        public Brush TextColor
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register("TextColor", typeof(Brush), typeof(Label1), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B7C4CF"))));

        [DisplayName("文字大小")]
        public double TextSize
        {
            get { return (double)GetValue(TextSizeProperty); }
            set { SetValue(TextSizeProperty, value); }
        }

        //Using a DependencyProperty as the backing store for TextSize.This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextSizeProperty =
            DependencyProperty.Register("TextSize", typeof(double), typeof(Label1), new PropertyMetadata(18.0));

        [DisplayName("文字纵向位置")]
        public VerticalAlignment TextVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(TextVerticalAlignmentProperty); }
            set { SetValue(TextVerticalAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextVerticalAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextVerticalAlignmentProperty =
            DependencyProperty.Register("TextVerticalAlignment", typeof(VerticalAlignment), typeof(Label1), new PropertyMetadata(VerticalAlignment.Bottom));


        [DisplayName("文字横向位置")]
        public HorizontalAlignment TextHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty); }
            set { SetValue(TextHorizontalAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextHorizontalAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextHorizontalAlignmentProperty =
            DependencyProperty.Register("TextHorizontalAlignment", typeof(HorizontalAlignment), typeof(Label1), new PropertyMetadata(HorizontalAlignment.Left));

        [DisplayName("文字与各边距离")]
        public Thickness TextThickness
        {
            get { return (Thickness)GetValue(TextThicknessProperty); }
            set { SetValue(TextThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextThicknessProperty =
            DependencyProperty.Register("TextThickness", typeof(Thickness), typeof(Label1), new PropertyMetadata(new Thickness(0, 0, 0, 0)));
        #endregion

        #region 数字
        [DisplayName("数字")]
        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(Label1), new PropertyMetadata("666"));

        [DisplayName("数字字体")]
        public FontFamily NumberFontFamily
        {
            get { return (FontFamily)GetValue(NumberFontFamilyProperty); }
            set { SetValue(NumberFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberFontFamilyProperty =
            DependencyProperty.Register("NumberFontFamily", typeof(FontFamily), typeof(Label1), new PropertyMetadata(new FontFamily("微软雅黑")));



        [DisplayName("数字颜色")]
        public Brush NumberColor
        {
            get { return (Brush)GetValue(NumberColorProperty); }
            set { SetValue(NumberColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberColorProperty =
            DependencyProperty.Register("NumberColor", typeof(Brush), typeof(Label1), new PropertyMetadata(CreateLineBrush()));

        [DisplayName("数字大小")]
        public double NumberSize
        {
            get { return (double)GetValue(NumberSizeProperty); }
            set { SetValue(NumberSizeProperty, value); }
        }

        //Using a DependencyProperty as the backing store for TextSize.This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberSizeProperty =
            DependencyProperty.Register("NumberSize", typeof(double), typeof(Label1), new PropertyMetadata(32.0));

        [DisplayName("数字纵向位置")]
        public VerticalAlignment NumberVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(NumberVerticalAlignmentProperty); }
            set { SetValue(NumberVerticalAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextVerticalAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberVerticalAlignmentProperty =
            DependencyProperty.Register("NumberVerticalAlignment", typeof(VerticalAlignment), typeof(Label1), new PropertyMetadata(VerticalAlignment.Top));


        [DisplayName("数字横向位置")]
        public HorizontalAlignment NumberHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(NumberHorizontalAlignmentProperty); }
            set { SetValue(NumberHorizontalAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextHorizontalAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberHorizontalAlignmentProperty =
            DependencyProperty.Register("NumberHorizontalAlignment", typeof(HorizontalAlignment), typeof(Label1), new PropertyMetadata(HorizontalAlignment.Left));
        #endregion

        #region 单位
        [DisplayName("单位")]
        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(string), typeof(Label1), new PropertyMetadata("个"));

        [DisplayName("单位字体")]
        public FontFamily UnitFontFamily
        {
            get { return (FontFamily)GetValue(UnitFontFamilyProperty); }
            set { SetValue(UnitFontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextFontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitFontFamilyProperty =
            DependencyProperty.Register("UnitFontFamily", typeof(FontFamily), typeof(Label1), new PropertyMetadata(new FontFamily("微软雅黑")));



        [DisplayName("单位颜色")]
        public Brush UnitColor
        {
            get { return (Brush)GetValue(UnitColorProperty); }
            set { SetValue(UnitColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitColorProperty =
            DependencyProperty.Register("UnitColor", typeof(Brush), typeof(Label1), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B7C4CF"))));

        [DisplayName("单位大小")]
        public double UnitSize
        {
            get { return (double)GetValue(UnitSizeProperty); }
            set { SetValue(UnitSizeProperty, value); }
        }

        //Using a DependencyProperty as the backing store for TextSize.This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitSizeProperty =
            DependencyProperty.Register("UnitSize", typeof(double), typeof(Label1), new PropertyMetadata(14.0));

        [DisplayName("单位纵向位置")]
        public VerticalAlignment UnitVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(UnitVerticalAlignmentProperty); }
            set { SetValue(UnitVerticalAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextVerticalAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitVerticalAlignmentProperty =
            DependencyProperty.Register("UnitVerticalAlignment", typeof(VerticalAlignment), typeof(Label1), new PropertyMetadata(VerticalAlignment.Center));


        [DisplayName("单位横向位置")]
        public HorizontalAlignment UnitHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(UnitHorizontalAlignmentProperty); }
            set { SetValue(UnitHorizontalAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextHorizontalAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnitHorizontalAlignmentProperty =
            DependencyProperty.Register("UnitHorizontalAlignment", typeof(HorizontalAlignment), typeof(Label1), new PropertyMetadata(HorizontalAlignment.Left));
        #endregion

        private static LinearGradientBrush CreateLineBrush()
        {
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0.5, 0);
            brush.EndPoint = new Point(0.5, 1);

            GradientStop gs1 = new GradientStop();
            gs1.Offset = 0;
            gs1.Color = (Color)ColorConverter.ConvertFromString("#01BAFE");
            brush.GradientStops.Add(gs1);
            GradientStop gs2 = new GradientStop();
            gs2.Offset = 1;
            gs2.Color = (Color)ColorConverter.ConvertFromString("#0179FE");
            brush.GradientStops.Add(gs2);
            return brush;
        }
    }
}

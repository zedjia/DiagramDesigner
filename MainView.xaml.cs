using DevExpress.Xpf.Bars;
using DiagramDesigner.CustomControls.Browsers;
using DiagramDesigner.CustomControls.Images;
using DiagramDesigner.Tools;
using DiagramDesigner.Windows.DataSourceWD;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DiagramDesigner
{
    public partial class MainView : Window
    {
        private DesignerCanvas DesignerCanvas;
        private PreviewView previewView;
        public MainView()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.F2)
            {
                OpenPreviewView();
            }
        }

        private void PreviewView_Closed(object sender, System.EventArgs e)
        {
            previewView.Canvas.Children.Remove(DesignerCanvas);
            this.ScrollViewer.Content = DesignerCanvas;
            DesignerCanvas.SetValue(System.Windows.Controls.Grid.RowProperty, 0);
            DesignerCanvas.SetValue(System.Windows.Controls.Grid.ColumnProperty, 0);
            
        }

        private void OpenPreviewView()
        {
            previewView = new PreviewView();
            //var uis = this.Grid.Children;
            //DesignerCanvas = this.MyDesigner;
            //this.ScrollViewer.Content = null;
            //previewView.GridContent.Children.Add(DesignerCanvas);//Content = DesignerCanvas;
            //DesignerCanvas.SetValue(DesignerCanvas.NameProperty, "MyDesigner");
            

            
            var uiCollection = this.MyDesigner.Children;
            foreach (var ui in uiCollection)
            {
                
                var designerItem = ui as DesignerItem;
                Vector vector = VisualTreeHelper.GetOffset(designerItem);//获取相对位置
                if (designerItem.Content is CefSharpBrowser)
                {
                    var map = designerItem.Content as CefSharpBrowser;
                    CefSharpBrowser cefSharpBrowser = new CefSharpBrowser();
                    cefSharpBrowser.Url = map.Url;
                    cefSharpBrowser.Height = map.ActualHeight;
                    cefSharpBrowser.Width = map.ActualWidth;
                    Canvas.SetLeft(cefSharpBrowser, vector.X);
                    Canvas.SetTop(cefSharpBrowser, vector.Y);
                    Canvas.SetZIndex(cefSharpBrowser, 0);
                    previewView.Canvas.Children.Add(cefSharpBrowser);
                }
                else
                {
                    var control = designerItem.Content as Control;
                    if (control is ImageCommon)
                    {
                        Canvas.SetZIndex(control, 1);
                    }
                    else
                    {
                        Canvas.SetZIndex(control, 2);
                    }
                    var cloneControl = ControlUtility.CloneControl<Control>(control);
                    cloneControl.Height = control.ActualHeight;
                    cloneControl.Width = control.ActualWidth;
                    Canvas.SetLeft(cloneControl, vector.X);
                    Canvas.SetTop(cloneControl, vector.Y);
                    previewView.Canvas.Children.Add(cloneControl);
                }
            }

            previewView.Topmost = true;
            previewView.Show();

            //previewView.Closed += PreviewView_Closed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenPreviewView();
        }

        private void ModuleChange_Click(object sender, RoutedEventArgs e)
        {
            if(this.ModuleLabel.Content.Equals("透明"))
            {
                this.MyDesigner.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                this.ModuleLabel.Content = "常规";
            }
            else
            {
                this.MyDesigner.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                this.ModuleLabel.Content = "透明";
            }
        }
    }
}

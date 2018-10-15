using DevExpress.Xpf.Bars;
using DiagramDesigner.Windows.DataSourceWD;
using System.Windows;
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
            previewView.GridContent.Children.Remove(DesignerCanvas);
            this.ScrollViewer.Content = DesignerCanvas;
            DesignerCanvas.SetValue(System.Windows.Controls.Grid.RowProperty, 0);
            DesignerCanvas.SetValue(System.Windows.Controls.Grid.ColumnProperty, 0);
            
        }

        private void OpenPreviewView()
        {
            previewView = new PreviewView();
            var uis = this.Grid.Children;
            DesignerCanvas = this.MyDesigner;
            this.ScrollViewer.Content = null;
            previewView.GridContent.Children.Add(DesignerCanvas);//Content = DesignerCanvas;
            DesignerCanvas.SetValue(DesignerCanvas.NameProperty, "MyDesigner");
            previewView.Topmost = true;
            previewView.Show();

            previewView.Closed += PreviewView_Closed;
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

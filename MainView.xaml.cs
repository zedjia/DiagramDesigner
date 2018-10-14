using DevExpress.Xpf.Bars;
using DiagramDesigner.Windows.DataSourceWD;
using System.Windows;

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
                previewView = new PreviewView();
                var uis = this.Grid.Children;
                DesignerCanvas = this.MyDesigner;
                this.Grid.Children.Remove(DesignerCanvas);
                previewView.GridContent.Children.Add(DesignerCanvas);//Content = DesignerCanvas;
                DesignerCanvas.SetValue(DesignerCanvas.NameProperty, "MyDesigner");
                //DesignerCanvas.SetValue(DesignerCanvas.WidthProperty, "MyDesigner");
                //DesignerCanvas.SetValue(DesignerCanvas.HeightProperty, "MyDesigner");
                previewView.Show();

                previewView.Closed += PreviewView_Closed;
            }
        }

        private void PreviewView_Closed(object sender, System.EventArgs e)
        {
            previewView.GridContent.Children.Remove(DesignerCanvas);
            this.Grid.Children.Add(DesignerCanvas);
            DesignerCanvas.SetValue(System.Windows.Controls.Grid.RowProperty, 0);
            DesignerCanvas.SetValue(System.Windows.Controls.Grid.ColumnProperty, 0);
            
        }
    }
}

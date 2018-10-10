using DevExpress.Xpf.Bars;
using DiagramDesigner.Windows.DataSourceWD;
using System.Windows;

namespace DiagramDesigner
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void sqlserver_CheckedChanged(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (sqlserver.IsChecked.Value)
            {
                SqlConfigWindow sqlConfigWindow = new SqlConfigWindow();
                sqlConfigWindow.ShowDialog();
            }
        }
    }
}

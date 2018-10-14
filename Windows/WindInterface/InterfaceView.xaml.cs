using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace DiagramDesigner.Windows.WindInterface
{
    /// <summary>
    /// InterfaceView.xaml 的交互逻辑
    /// </summary>
    public partial class InterfaceView : Window
    {
        public InterfaceView()
        {
            InitializeComponent();
            this.Closing += InterfaceView_Closing;
        }

        private void InterfaceView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InterfaceViewModel Context = this.DataContext as InterfaceViewModel;
            bool result = false;
            if (Context != null) result = Context.CloseForm();
            if (!result)
            {
                MessageBox.Show("数据配置保存失败,请重新尝试或者联系管理员", "提示");
                e.Cancel = true;
            }
        }
        
    }
}

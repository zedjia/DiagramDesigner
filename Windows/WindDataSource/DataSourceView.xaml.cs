using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace DiagramDesigner.Windows.WindDataSource
{
    /// <summary>
    /// WDataSource.xaml 的交互逻辑
    /// </summary>
    public partial class DataSourceView : Window
    {
        public DataSourceView()
        {
            InitializeComponent();
        }

        private void ConnButton_Click(object sender, RoutedEventArgs e)
        {
            TestResultlbl.Content = "测试连接中";
            //test connstr
            string connstr =
                "Data Source = 172.18.0.88;Initial Catalog = myDataBase;User Id = sa;Password = 123!@#qwe;";
            using (SqlConnection cn = new SqlConnection(connstr))
            {
                try
                {
                    cn.ExecuteScalar("select 1");
                    TestResultlbl.Content = "连接成功";
                }
                catch (Exception ex)
                {
                    TestResultlbl.Content = "连接失败";
                }
                finally
                {
                }
            }
        }
    }
}

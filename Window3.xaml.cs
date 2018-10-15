using System;
using System.Collections.Generic;
using System.Data;
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

namespace DiagramDesigner
{
    /// <summary>
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();

            this.Loaded += Window3_Loaded;

            //this.TabControl.ItemsSource = new List<string>() { "1","2","3" };
        }

        private void Window3_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable DataTable = new DataTable("Datas");
            DataColumn dc = null;
            dc = DataTable.Columns.Add("ID", Type.GetType("System.Int32"));
            dc.AutoIncrement = true;//自动增加
            dc.AutoIncrementSeed = 1;//起始为1
            dc.AutoIncrementStep = 1;//步长为1
            dc.AllowDBNull = false;//

            dc = DataTable.Columns.Add("Product", Type.GetType("System.String"));
            dc = DataTable.Columns.Add("Version", Type.GetType("System.String"));


            DataRow newRow;
            newRow = DataTable.NewRow();
            newRow["Product"] = "A区";
            newRow["Version"] = "90";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Product"] = "B区";
            newRow["Version"] = "40";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Product"] = "C区";
            newRow["Version"] = "75";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Product"] = "D区";
            newRow["Version"] = "60";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Product"] = "E区";
            newRow["Version"] = "30";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Product"] = "F区";
            newRow["Version"] = "30";
            DataTable.Rows.Add(newRow);

            ////这里绑定的是每一个系列的datatable，也就是说必须先把数据源过滤了再来绑定
            //SingleChart.DataSource = DataTable;
            ////这个属性必须和绑定的datatable中的列名一致
            //BarSideBySideSeries2D.ArgumentDataMember = DataTable.Columns[1].ColumnName;
            ////可以指定多个纵坐标，这里只有一个，也必须和绑定的datatable中一致
            //BarSideBySideSeries2D.ValueDataMember = DataTable.Columns[2].ColumnName;
        }
    }
}

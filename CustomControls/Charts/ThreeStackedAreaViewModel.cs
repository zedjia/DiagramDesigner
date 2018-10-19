using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramDesigner.CustomControls.Charts
{
    [AddINotifyPropertyChangedInterface]
    public class ThreeStackedAreaViewModel: IChartViewModel
    {
        public DataTable DataTable { get; set; }

        public ThreeStackedAreaViewModel()
        {
            #region 示例数据
            DataTable = new DataTable("Datas");
            DataColumn dc = null;
            dc = DataTable.Columns.Add("ID", Type.GetType("System.Int32"));
            dc.AutoIncrement = true;//自动增加
            dc.AutoIncrementSeed = 1;//起始为1
            dc.AutoIncrementStep = 1;//步长为1
            dc.AllowDBNull = false;//

            dc = DataTable.Columns.Add("Argument", Type.GetType("System.String"));
            dc = DataTable.Columns.Add("Value1", Type.GetType("System.String"));
            dc = DataTable.Columns.Add("Value2", Type.GetType("System.String"));
            dc = DataTable.Columns.Add("Value3", Type.GetType("System.String"));


            DataRow newRow;
            newRow = DataTable.NewRow();
            newRow["Argument"] = "周一";
            newRow["Value1"] = "6859";
            newRow["Value2"] = "4210";
            newRow["Value3"] = "2649";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "周二";
            newRow["Value1"] = "6859";
            newRow["Value2"] = "4160";
            newRow["Value3"] = "2699";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "周三";
            newRow["Value1"] = "6859";
            newRow["Value2"] = "4219";
            newRow["Value3"] = "2640";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "周四";
            newRow["Value1"] = "6859";
            newRow["Value2"] = "4250";
            newRow["Value3"] = "2609";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "周五";
            newRow["Value1"] = "6859";
            newRow["Value2"] = "4110";
            newRow["Value3"] = "2749";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "周六";
            newRow["Value1"] = "6859";
            newRow["Value2"] = "4310";
            newRow["Value3"] = "2549";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "周日";
            newRow["Value1"] = "6859";
            newRow["Value2"] = "4410";
            newRow["Value3"] = "2449";
            DataTable.Rows.Add(newRow);
            #endregion
        }
    }
}

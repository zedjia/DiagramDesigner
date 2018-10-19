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
    public class HisAndAreaViewModel : IChartViewModel
    {
        public DataTable DataTable { get; set; }

        public HisAndAreaViewModel()
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


            DataRow newRow;
            newRow = DataTable.NewRow();
            newRow["Argument"] = "0/HR";
            newRow["Value1"] = "3200";
            newRow["Value2"] = "2800";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "8/HR";
            newRow["Value1"] = "7000";
            newRow["Value2"] = "6500";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "16/HR";
            newRow["Value1"] = "4500";
            newRow["Value2"] = "5000";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "24/HR";
            newRow["Value1"] = "2000";
            newRow["Value2"] = "3000";
            DataTable.Rows.Add(newRow);
            #endregion
        }
    }
}

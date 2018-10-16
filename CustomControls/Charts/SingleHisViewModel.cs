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
    public class SingleHisViewModel: IChartViewModel
    {
        public DataTable DataTable { get; set; }

        public SingleHisViewModel()
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
            dc = DataTable.Columns.Add("Value", Type.GetType("System.String"));


            DataRow newRow;
            newRow = DataTable.NewRow();
            newRow["Argument"] = "A区";
            newRow["Value"] = "90";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "B区";
            newRow["Value"] = "40";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "C区";
            newRow["Value"] = "75";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "D区";
            newRow["Value"] = "60";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "E区";
            newRow["Value"] = "30";
            DataTable.Rows.Add(newRow);

            newRow = DataTable.NewRow();
            newRow["Argument"] = "G区";
            newRow["Value"] = "30";
            DataTable.Rows.Add(newRow);
            #endregion
        }
    }
}

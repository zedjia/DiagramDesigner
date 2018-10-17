using DiagramDesigner.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramDesigner.Windows.WindDataSource
{
    [AddINotifyPropertyChangedInterface]
    public class DataSourceSelectViewModel
    {
        public DataTable SqlExecResult { get; set; }
        public ObservableCollection<DataSourceModel> dataSourceModels { get; set; }
        public DataSourceSelectViewModel()
        {
            SqlExecResult = new DataTable();

            dataSourceModels = FileDataServices.GetDataModelFromFile<ObservableCollection<DataSourceModel>>();
            dataSourceModels = dataSourceModels ?? new ObservableCollection<DataSourceModel>();
        }

        public void SetSqlExecResult(DataTable dt)
        {
            SqlExecResult = dt;
        }
    }
}

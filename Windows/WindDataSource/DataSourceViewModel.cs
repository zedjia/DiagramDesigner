using DiagramDesigner.Models;
using Prism.Commands;
using PropertyChanged;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiagramDesigner.Windows.WindDataSource
{
    public class DataSourceViewModel
    {
        public DataSourceModel DataSourceModel { get; set; } = new DataSourceModel();
        public ObservableCollection<DataSourceModel> dataSourceModels { get; set; }

        public DataSourceViewModel()
        {
            dataSourceModels = new ObservableCollection<DataSourceModel>()
            {
                new DataSourceModel(){ DBType="SQL Server",DBAlias="test",DBConnUrl="127.0.0.1"},
                new DataSourceModel(){ DBType="Oracle",DBAlias="test",DBConnUrl="127.0.0.1"},
                new DataSourceModel(){ DBType="Access",DBAlias="test",DBConnUrl="127.0.0.1"},
                new DataSourceModel(){ DBType="DB2",DBAlias="test",DBConnUrl="127.0.0.1"},
                new DataSourceModel(){ DBType="MySQL",DBAlias="test",DBConnUrl="127.0.0.1"},
                new DataSourceModel(){ DBType="SQLite",DBAlias="test",DBConnUrl="127.0.0.1"},
                new DataSourceModel(){ DBType="PostgreSQL",DBAlias="test",DBConnUrl="127.0.0.1"}
            };
        }
        /// <summary>
        /// 数据源类型选择
        /// </summary>
        public ICommand SelectionChangedCmd
        {
            get
            {
                return new DelegateCommand<ListBox>(SelectionChanged);
            }
        }

        void SelectionChanged(ListBox lst)
        {
            DataSourceModel dataSourceModel = lst.SelectedItem as DataSourceModel;
            DataSourceModel.DBType = dataSourceModel.DBType;
        }
        /// <summary>
        /// 测试链接
        /// </summary>
        public ICommand TestConnectionCmd
        {
            get
            {
                return new DelegateCommand(TestConnection);
            }
        }
        void TestConnection()
        {
            Console.WriteLine(DataSourceModel.DBType);
            var obj = DataSourceModel;
            DataSourceModel.DBAlias = "1111";
        }
        /// <summary>
        /// 新增到配置列表
        /// </summary>
        public ICommand AddConfigCmd
        {
            get
            {
                return new DelegateCommand(AddConfig);
            }
        }

        void AddConfig()
        {

        }
        /// <summary>
        /// 保存
        /// </summary>
        public ICommand SaveConfigCmd
        {
            get
            {
                return new DelegateCommand(SaveConfig);
            }
        }

        void SaveConfig()
        {

        }
        /// <summary>
        /// 删除
        /// </summary>
        public ICommand DeleteConfigCmd
        {
            get
            {
                return new DelegateCommand<DataGrid>(DeleteConfig);
            }
        }

        void DeleteConfig(DataGrid dataGrid)
        {
            DataSourceModel dataSourceModel = dataGrid.SelectedItem as DataSourceModel;
            this.dataSourceModels.Remove(dataSourceModel);
        }
    }
    [AddINotifyPropertyChangedInterface]
    public class DataSourceModel
    {
        public Guid Id { get; set; }
        public string DBType { get; set; } = "Oracle";
        public string DBAlias { get; set; } = "test";
        public string DBConnUrl { get; set; } = "127.0.0.1";
        public bool ConnStatus { get; set; }
    }
}

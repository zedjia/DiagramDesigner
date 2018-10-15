using DiagramDesigner.Models;
using Prism.Commands;
using PropertyChanged;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Dapper;
using DiagramDesigner.Services;
using ListBox = System.Windows.Controls.ListBox;
using MessageBox = System.Windows.MessageBox;

namespace DiagramDesigner.Windows.WindDataSource
{
    [AddINotifyPropertyChangedInterface]
    public class DataSourceViewBindingModel
    {
        public ObservableCollection<DataSourceModel> dataSourceModels { get; set; }
        public DataSourceModel SelectedDataSourceModel { get; set; } = new DataSourceModel();


        public DataTable SqlExecResult { get; set; }
        


        public DataSourceViewBindingModel()
        {
            SqlExecResult=new DataTable();

            dataSourceModels =FileDataServices.GetDataModelFromFile<ObservableCollection<DataSourceModel>>();
            dataSourceModels = dataSourceModels ?? new ObservableCollection<DataSourceModel>();


            //dataSourceModels = new ObservableCollection<DataSourceModel>()
            //{
            //    new DataSourceModel(){ DBType="SQL Server",DBAlias="test",DBConnUrl="Data Source = 172.18.0.88;Initial Catalog = myDataBase;User Id = sa;Password = 123!@#qwe;"},
            //    new DataSourceModel(){ DBType="Oracle",DBAlias="test1",DBConnUrl="127.0.0.1"},
            //    new DataSourceModel(){ DBType="Access",DBAlias="test2",DBConnUrl="127.0.0.1"},
            //    new DataSourceModel(){ DBType="DB2",DBAlias="test3",DBConnUrl="127.0.0.1"},
            //    new DataSourceModel(){ DBType="MySQL",DBAlias="test4",DBConnUrl="127.0.0.1"},
            //    new DataSourceModel(){ DBType="SQLite",DBAlias="test",DBConnUrl="127.0.0.1"},
            //    new DataSourceModel(){ DBType="PostgreSQL",DBAlias="test",DBConnUrl="127.0.0.1"}
            //};
        }

        public string TestResult { get; set; }

        public List<DbType> DbTypeList => new List<DbType>()
        {
            new DbType(){Name = "SQLServer",Value = 0},
            new DbType(){Name = "Oracle",Value = 1},
            new DbType(){Name = "Access",Value = 2},
            new DbType(){Name = "DB2",Value = 3},
            new DbType(){Name = "MySQL",Value = 4},
            new DbType(){Name = "SQLite",Value = 5},
            new DbType(){Name = "PostgreSQL",Value = 6}
        };

        public void SetSqlExecResult(DataTable dt)
        {
            SqlExecResult = dt;
        }




        #region tab1 事件委托




        /// <summary>
        /// 数据源类型选择
        /// </summary>
        public ICommand SelectionChangedCmd => new DelegateCommand<ListBox>(SelectionChanged);

        void SelectionChanged(ListBox lst)
        {
            DbType dataSourceModel = lst.SelectedItem as DbType;
            if (dataSourceModel != null) SelectedDataSourceModel.DBType = dataSourceModel.Name;
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
            Console.WriteLine(SelectedDataSourceModel.DBType);
            TestResult = "测试中.";
            using (SqlConnection cn = new SqlConnection(SelectedDataSourceModel.DBConnUrl))
            {
                try
                {
                    cn.ExecuteScalarAsync("select 1").Wait();
                    TestResult = "连接成功";
                }
                catch (Exception ex)
                {
                    TestResult = "连接失败";
                }
            }
        }
        /// <summary>
        /// 新增到配置列表
        /// </summary>
        public ICommand AddConfigCmd => new DelegateCommand(AddConfig);

        void AddConfig()
        {
            SelectedDataSourceModel.Id = Guid.NewGuid();
            dataSourceModels.Add(SelectedDataSourceModel.Clone());
            TestResult = string.Empty;
        }
        /// <summary>
        /// 保存
        /// </summary>
        public ICommand SaveConfigCmd => new DelegateCommand(SaveConfig);

        void SaveConfig()
        {
            var editItem = dataSourceModels.FirstOrDefault(i => i.Id == SelectedDataSourceModel.Id);
            if (editItem == null)
            {
                MessageBox.Show("无法编辑本条记录,请先进行新增操作.", "提示");
                return;
            }
            editItem.SetValue(SelectedDataSourceModel);
            TestResult = string.Empty;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        public ICommand EditConfigCmd => new DelegateCommand<DataSourceModel>(EditConfig);

        void EditConfig(DataSourceModel dataSourceModel)
        {
            SelectedDataSourceModel = dataSourceModel.Clone();
            TestResult = string.Empty;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public ICommand DeleteConfigCmd => new DelegateCommand<DataSourceModel>(DeleteConfig);

        void DeleteConfig(DataSourceModel dataSourceModel)
        {
            if(MessageBox.Show("是否删除选中的记录?","删除确认",MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                this.dataSourceModels.Remove(dataSourceModel);
            }
        }

        #endregion




        /// <summary>
        /// 保存
        /// </summary>
        public ICommand SaveExConfigCmd => new DelegateCommand<DataSourceModel>(SaveExConfig);

        void SaveExConfig(DataSourceModel dataSourceModel)
        {
            //if (MessageBox.Show("是否删除选中的记录?", "删除确认", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            //{
            //    this.dataSourceModels.Remove(dataSourceModel);
            //}
        }

        /// <summary>
        /// 关闭窗体时写入文件,如果失败则取消关闭
        /// </summary>
        public bool CloseForm()
        {
            return FileDataServices.SaveDataModelToFile(dataSourceModels, FileDataServices.DATASOURCEFILENAME);
        }


    }



    [AddINotifyPropertyChangedInterface]
    public class DataSourceModel
    {
        public DataSourceModel()
        {
            DataItems=new ObservableCollection<DataItem>();
        }

        public Guid Id { get; set; }

        private string _dbtype;

        public string DBType
        {
            get { return _dbtype; }
            set
            {
                if (value == "SQLServer")
                {
                    Sort = 0;
                }
                _dbtype = value;
            }
        }

        public string DBAlias { get; set; } = "test";
        public string DBConnUrl { get; set; } = "Data Source = 172.18.0.88;Initial Catalog = myDataBase;User Id = sa;Password = 123!@#qwe;";
        public bool ConnStatus { get; set; }

        public int Sort { get; set; } = 1;

        public ObservableCollection<DataItem> DataItems { get; set; }

        public DataSourceModel Clone()
        {
            return new DataSourceModel()
            {
                Id = this.Id,
                DBType = this.DBType,
                DBAlias = this.DBAlias,
                DBConnUrl = this.DBConnUrl,
                ConnStatus = this.ConnStatus
            };
        }

        public void SetValue(DataSourceModel model)
        {
            this.Id = model.Id;
            this.DBType = model.DBType;
            this.DBAlias = model.DBAlias;
            this.DBConnUrl = model.DBConnUrl;
            this.ConnStatus = model.ConnStatus;
        }

    }

    [AddINotifyPropertyChangedInterface]
    public class DataItem
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public string SqlStr { get; set; }

        public DataItem Clone()
        {
            return new DataItem()
            {
                Id = this.Id,
                Alias = this.Alias,
                SqlStr = this.SqlStr,
            };
        }

        public void SetValue(DataItem model)
        {
            this.Id = model.Id;
            this.Alias = model.Alias;
            this.SqlStr = model.SqlStr;
        }

    }



    public class DbType
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}

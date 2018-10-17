using Prism.Commands;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DiagramDesigner.Helper;
using DiagramDesigner.Models;
using DiagramDesigner.Services;
using Newtonsoft.Json;
using DiagramDesigner.CustomControls.Charts;

namespace DiagramDesigner.Windows.WindInterface
{
    [AddINotifyPropertyChangedInterface]
    public class InterfaceViewModel
    {
        public IChartViewModel ChartViewModel { get; set; }
        public InterfaceModel SelectedInterfaceModel { get; set; } = new InterfaceModel();
        public ObservableCollection<InterfaceModel> InterfaceModels { get; set; }
        public InterfaceViewModel()
        {
            InterfaceModels = FileDataServices.GetDataModelFromFile<ObservableCollection<InterfaceModel>>(FileDataServices.INTERFACEFILENAME);
            InterfaceModels = InterfaceModels ?? new ObservableCollection<InterfaceModel>();
            //InterfaceModels = new ObservableCollection<InterfaceModel>()
            //{
            //    new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"},
            //    new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"},
            //    new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"},
            //    new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"},
            //    new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"},
            //    new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"},
            //    new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"}
            //};
        }

        public DataTable TestResult { get; set; }

        /// <summary>
        /// 测试链接
        /// </summary>
        public ICommand TestConnectionCmd => new DelegateCommand(TestConnection);

        void TestConnection()
        {
            HttpHelper helper=new HttpHelper();
            try
            {
                var result = helper.GetHtml(new HttpItem() { URL = SelectedInterfaceModel.IFUrl });
                TestResult = JsonConvert.DeserializeObject<DataTable>(result.Html);
            }
            catch (Exception e)
            {
                MessageBox.Show("测试出错，无法获取数据或者数据格式不支持,请使用DataTable类型.","错误提示");
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// 新增到配置列表
        /// </summary>
        public ICommand AddConfigCmd => new DelegateCommand(AddConfig);

        void AddConfig()
        {
            SelectedInterfaceModel.Id = Guid.NewGuid();
            InterfaceModels.Add(SelectedInterfaceModel.Clone());
        }
        /// <summary>
        /// 保存
        /// </summary>
        public ICommand SaveConfigCmd => new DelegateCommand(SaveConfig);

        void SaveConfig()
        {
            var editItem = InterfaceModels.FirstOrDefault(i => i.Id == SelectedInterfaceModel.Id);
            if (editItem == null)
            {
                MessageBox.Show("无法编辑本条记录,请先进行新增操作.", "提示");
                return;
            }
            editItem.SetValue(SelectedInterfaceModel);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        public ICommand EditConfigCmd => new DelegateCommand<InterfaceModel>(EditConfig);

        void EditConfig(InterfaceModel dataSourceModel)
        {
            SelectedInterfaceModel = dataSourceModel.Clone();
            TestResult = null;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public ICommand DeleteConfigCmd => new DelegateCommand<InterfaceModel>(DeleteConfig);

        void DeleteConfig(InterfaceModel model)
        {
            if (MessageBox.Show("是否删除选中的记录?", "删除确认", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                this.InterfaceModels.Remove(model);
            }
        }

        /// <summary>
        /// 选择
        /// </summary>
        public ICommand SelectConfigCmd => new DelegateCommand<InterfaceModel>(SelectConfig);

        void SelectConfig(InterfaceModel model)
        {
            if (TestResult != null && TestResult.Rows.Count > 0)
            {
                ChartViewModel.DataTable = TestResult;
            }
        }


        public bool CloseForm()
        {
            return FileDataServices.SaveDataModelToFile(InterfaceModels, FileDataServices.INTERFACEFILENAME);
        }

    }

    [AddINotifyPropertyChangedInterface]
    public class InterfaceModel
    {
        public Guid Id { get; set; }
        public string IFAlias { get; set; } = "test";
        public string IFUrl { get; set; } = "http://127.0.0.1";
        public bool ConnStatus { get; set; }


        public InterfaceModel Clone()
        {
            return new InterfaceModel()
            {
                Id = this.Id,
                IFAlias = this.IFAlias,
                IFUrl = this.IFUrl,
                ConnStatus = this.ConnStatus
            };
        }

        public void SetValue(InterfaceModel model)
        {
            this.Id = model.Id;
            this.IFAlias = model.IFAlias;
            this.IFUrl = model.IFUrl;
            this.ConnStatus = model.ConnStatus;
        }

    }
}

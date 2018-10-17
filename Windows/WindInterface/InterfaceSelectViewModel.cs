using DiagramDesigner.CustomControls.Charts;
using DiagramDesigner.Helper;
using DiagramDesigner.Services;
using Newtonsoft.Json;
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

namespace DiagramDesigner.Windows.WindInterface
{
    [AddINotifyPropertyChangedInterface]
    public class InterfaceSelectViewModel
    {
        public IChartViewModel ChartViewModel { get; set; }
        public InterfaceModel SelectedInterfaceModel { get; set; } = new InterfaceModel();
        public ObservableCollection<InterfaceModel> InterfaceModels { get; set; }
        public InterfaceSelectViewModel()
        {
            InterfaceModels = FileDataServices.GetDataModelFromFile<ObservableCollection<InterfaceModel>>(FileDataServices.INTERFACEFILENAME);
            InterfaceModels = InterfaceModels ?? new ObservableCollection<InterfaceModel>();
        }

        public DataTable TestResult { get; set; }

        /// <summary>
        /// 测试链接
        /// </summary>
        public ICommand TestConnectionCmd => new DelegateCommand(TestConnection);

        void TestConnection()
        {
            HttpHelper helper = new HttpHelper();
            try
            {
                var result = helper.GetHtml(new HttpItem() { URL = SelectedInterfaceModel.IFUrl });
                TestResult = JsonConvert.DeserializeObject<DataTable>(result.Html);
            }
            catch (Exception e)
            {
                MessageBox.Show("测试出错，无法获取数据或者数据格式不支持,请使用DataTable类型.", "错误提示");
                Console.WriteLine(e);
            }
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
    }
}

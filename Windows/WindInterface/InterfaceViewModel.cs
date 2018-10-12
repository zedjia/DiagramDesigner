using Prism.Commands;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiagramDesigner.Windows.WindInterface
{
    public class InterfaceViewModel
    {
        public InterfaceModel InterfaceModel { get; set; } = new InterfaceModel();
        public ObservableCollection<InterfaceModel> InterfaceModels { get; set; }
        public InterfaceViewModel()
        {
            InterfaceModels = new ObservableCollection<InterfaceModel>()
            {
                new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"},
                new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"},
                new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"},
                new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"},
                new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"},
                new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"},
                new InterfaceModel(){ IFAlias="test",IFUrl="127.0.0.1"}
            };
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
            var obj = InterfaceModel;
            InterfaceModel.IFAlias = "1111";
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
            InterfaceModel interfaceModel = dataGrid.SelectedItem as InterfaceModel;
            this.InterfaceModels.RemoveAt(0);
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class InterfaceModel
    {
        public Guid Id { get; set; }
        public string IFAlias { get; set; } = "test";
        public string IFUrl { get; set; } = "127.0.0.1";
        public bool ConnStatus { get; set; }
    }
}

using DiagramDesigner.Services;
using DiagramDesigner.Windows.WindDataSource;
using Prism.Commands;
using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DiagramDesigner
{
    public class MainViewModel
    {
        public ObservableCollection<DataSourceModel> DataSourceModels { get; set; }

        public MainViewModel()
        {
            DataSourceModels = FileDataServices.GetDataModelFromFile<ObservableCollection<DataSourceModel>>();
            DataSourceModels = DataSourceModels ?? new ObservableCollection<DataSourceModel>();
        }

        /// <summary>
        /// 分辨率宽度设置
        /// </summary>
        public ICommand WidthChangedCmd => new DelegateCommand<MainView>(WidthChanged);

        void WidthChanged(MainView mainView)
        {
            var width = mainView.WidthTxt.Text;
            if (IsNumberic(width))
            {
                mainView.MyDesigner.Width = double.Parse(width);
            }
        }

        /// <summary>
        /// 分辨率宽度设置
        /// </summary>
        public ICommand HeightChangedCmd => new DelegateCommand<MainView>(HeightChanged);

        void HeightChanged(MainView mainView)
        {
            var height = mainView.HeightTxt.Text;
            if (IsNumberic(height))
            {
                mainView.MyDesigner.Height = double.Parse(height);
            }
        }

        /// <summary>
        /// 判断字符串是否可以转化为数字
        /// </summary>
        /// <param name="str">要检查的字符串</param>
        /// <returns>true:可以转换为数字；false：不是数字</returns>
        public static bool IsNumberic(string str)
        {
            double vsNum;
            bool isNum;
            isNum = double.TryParse(str, System.Globalization.NumberStyles.Float,
                System.Globalization.NumberFormatInfo.InvariantInfo, out vsNum);
            return isNum;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DiagramDesigner.CustomControls.Charts;
using DiagramDesigner.Models;
using DiagramDesigner.Services;
using DiagramDesigner.Windows.WindDataSource;
using Prism.Commands;
using PropertyChanged;

namespace DiagramDesigner.UserControls
{
    [AddINotifyPropertyChangedInterface]
    public class DataItemViewModel
    {
        public DataSourceModel TabDataSourceModel { get; set; } = new DataSourceModel();
        public DataItem SelectedDataItemModel { get; set; } = new DataItem();
        public DataTable DataTable { get; set; }
        public IChartViewModel ChartViewModel { get; set; }


        public Action<DataTable> SetSqlExecResult;




        #region tab2 事件


        /// <summary>
        /// 新增到配置列表
        /// </summary>
        public ICommand AddDataItemCmd => new DelegateCommand(AddDataItem);

        void AddDataItem()
        {
            SelectedDataItemModel.Id = Guid.NewGuid();
            TabDataSourceModel.DataItems.Add(SelectedDataItemModel);
        }
        /// <summary>
        /// 保存
        /// </summary>
        public ICommand SaveDataItemCmd => new DelegateCommand(SaveDataItem);

        void SaveDataItem()
        {
            var editItem = TabDataSourceModel.DataItems.FirstOrDefault(i => i.Id == SelectedDataItemModel.Id);
            if (editItem == null)
            {
                MessageBox.Show("无法编辑本条记录,请先进行新增操作.", "提示");
                return;
            }
            editItem.SetValue(SelectedDataItemModel);
        }


        public ICommand SelectionDataItemChangedCmd => new DelegateCommand<ListBox>(SelectionDataItemChanged);

        void SelectionDataItemChanged(ListBox lst)
        {
            DataItem item = lst.SelectedItem as DataItem;
            if (item != null) SelectedDataItemModel = item.Clone();
        }

        /// <summary>
        /// 执行
        /// </summary>
        public ICommand ExecuteDataItemCmd => new DelegateCommand<DataItem>(ExecuteDataItem);

        void ExecuteDataItem(DataItem dataitem)
        {
            DataTable = DbServices.GetDataTableBySql(SelectedDataItemModel.SqlStr, TabDataSourceModel.DBConnUrl);
            //todo:需要绑定table
            SetSqlExecResult(DataTable);
        }

        /// <summary>
        /// 选择
        /// </summary>
        public ICommand SelectDataItemCmd => new DelegateCommand<DataItem>(SelectDataItem);

        void SelectDataItem(DataItem dataitem)
        {
            if (DataTable != null && DataTable.Rows.Count > 0)
            {
                ChartViewModel.DataTable = DataTable;
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        public ICommand DeleteDataItemCmd => new DelegateCommand<DataItem>(DeleteDataItem);

        void DeleteDataItem(DataItem dataItem)
        {
            if (MessageBox.Show("是否删除选中的记录?", "删除确认", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var editItem = TabDataSourceModel.DataItems.FirstOrDefault(i => i.Id == SelectedDataItemModel.Id);
                if (editItem != null)
                    this.TabDataSourceModel.DataItems.Remove(editItem);
            }
        }

        #endregion





    }
}

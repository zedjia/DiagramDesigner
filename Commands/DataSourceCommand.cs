using DiagramDesigner.Windows.DataSourceWD;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DiagramDesigner.Commands
{
    public partial class DataSourceCommand
    {
        /// <summary>
        /// 打开sql server数据源配置窗口
        /// </summary>
        public ICommand OpenSqlConfigWD
        {
            get
            {
                return new DelegateCommand(() => {
                    SqlConfigWindow sqlConfigWindow = new SqlConfigWindow();
                    sqlConfigWindow.ShowDialog();
                });
            }
        }
        /// <summary>
        /// 打开Oracle数据源配置窗口
        /// </summary>
        public ICommand OpenOracleConfigWD
        {
            get
            {
                return new DelegateCommand(() => {
                    OracleConfigWD sqlConfigWindow = new OracleConfigWD();
                    sqlConfigWindow.ShowDialog();
                });
            }
        }
        /// <summary>
        /// 打开MySql数据源配置窗口
        /// </summary>
        public ICommand OpenMySqlConfigWD
        {
            get
            {
                return new DelegateCommand(() => {
                    MySqlConfigWD sqlConfigWindow = new MySqlConfigWD();
                    sqlConfigWindow.ShowDialog();
                });
            }
        }
    }
}

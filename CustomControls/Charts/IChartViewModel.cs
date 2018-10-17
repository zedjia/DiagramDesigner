using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramDesigner.CustomControls.Charts
{
    /// <summary>
    /// 所有chart的viewmodel都需要实现该接口，用于为属性添加菜单
    /// </summary>
    public interface IChartViewModel
    {
        DataTable DataTable { get; set; }
    }
}

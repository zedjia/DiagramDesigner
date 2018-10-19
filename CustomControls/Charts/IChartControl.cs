using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramDesigner.CustomControls.Charts
{
    /// <summary>
    /// 所有图表View都需要实现该接口，用于绑定图表数据源
    /// </summary>
    public interface IChartControl
    {
        IChartViewModel ChartViewModel { get; set; }
    }
}

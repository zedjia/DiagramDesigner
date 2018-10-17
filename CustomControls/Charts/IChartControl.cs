using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramDesigner.CustomControls.Charts
{
    public interface IChartControl
    {
        IChartViewModel ChartViewModel { get; set; }
    }
}

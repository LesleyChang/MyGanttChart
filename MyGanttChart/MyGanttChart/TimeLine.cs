using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGanttChart
{
    public class TimeLine
    {
        public TimeLine()
        {
            Items = new ObservableCollection<TimeLineItem>();
        }

        public ObservableCollection<TimeLineItem> Items { get; set; }

    }
}

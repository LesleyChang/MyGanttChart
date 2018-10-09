using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyGanttChart
{
    /// <summary>
    /// UserControl_Gantt.xaml 的互動邏輯
    /// </summary>
    public partial class UserControl_Gantt : UserControl
    {
        public UserControl_Gantt()
        {
            InitializeComponent();
            GanttTimeColumnStyle = TimeColumnStyle.Day;
            DataContext = this;
            SelectionPeriod = new Period();
            
        }

        public void Initialize(DateTime minDate, DateTime maxDate)
        {
            this.ganttChartData.MinDate = minDate;
            this.ganttChartData.MaxDate = maxDate;
        }

        public TimeLine CreateTimeLine(PeriodSplitter splitter, PeriodNameFormatter PeriodNameFormatter)
        {
            var timeLineParts = splitter.Split();

            var timeline = new TimeLine();
            foreach (var p in timeLineParts)
            {
                timeline.Items.Add(new TimeLineItem() { Name = PeriodNameFormatter(p), Start = p.Start, End = p.End.AddSeconds(-1) });
            }

            ganttChartData.TimeLines.Add(timeline);
            return timeline;
        }
        public void SetGridLinesTimeline(TimeLine timeline)
        {
            if (!ganttChartData.TimeLines.Contains(timeline))
                throw new Exception("Invalid timeline");

            gridLineTimeLine = timeline;
        }
        public void SetGridLinesTimeline(TimeLine timeline, BackgroundFormatter backgroundFormatter)
        {
            if (!ganttChartData.TimeLines.Contains(timeline))
                throw new Exception("Invalid timeline");

            foreach (var item in timeline.Items)
            {
                item.BackgroundColor = backgroundFormatter(item);
            }
                

            gridLineTimeLines.Clear();
            gridLineTimeLines.Add(timeline);
            //gridLineTimeLine = timeline;
        }

        public delegate string PeriodNameFormatter(Period period);
        public delegate Brush BackgroundFormatter(TimeLineItem timeLineItem);
        public enum TimeColumnStyle { Day,Week,Month};
        public TimeColumnStyle GanttTimeColumnStyle;
        private GanttChartData ganttChartData = new GanttChartData();
        public GanttChartData GanttData { get { return ganttChartData; } }
        private TimeLine gridLineTimeLine;
        private ObservableCollection<TimeLine> gridLineTimeLines = new ObservableCollection<TimeLine>();
        public ObservableCollection<TimeLine> GridLineTimeLine { get { return gridLineTimeLines; } }
        public Period SelectionPeriod { get; private set; }
    }
}

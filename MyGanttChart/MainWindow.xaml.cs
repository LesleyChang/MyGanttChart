using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyGanttChart
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateData(DateTime.Now, DateTime.Now.AddDays(20));
        }
        private void CreateData(DateTime minDate, DateTime maxDate)
        {
            // Set max and min dates
            ganttControl1.Initialize(minDate, maxDate);

            // Create timelines and define how they should be presented
            ganttControl1.CreateTimeLine(new PeriodYearSplitter(minDate, maxDate), FormatYear);
            ganttControl1.CreateTimeLine(new PeriodMonthSplitter(minDate, maxDate), FormatMonth);
            var gridLineTimeLine = ganttControl1.CreateTimeLine(new PeriodDaySplitter(minDate, maxDate), FormatDay);
            

            // Set the timeline to atatch gridlines to
            ganttControl1.SetGridLinesTimeline(gridLineTimeLine, DetermineBackground);

        }
        private Brush DetermineBackground(TimeLineItem timeLineItem)
        {
            if (timeLineItem.End.Date.DayOfWeek == DayOfWeek.Saturday || timeLineItem.End.Date.DayOfWeek == DayOfWeek.Sunday)
                return new SolidColorBrush(Colors.LightBlue);
            else
                return new SolidColorBrush(Colors.Transparent);
        }
        private string FormatYear(Period period)
        {
            return period.Start.Year.ToString();
        }

        private string FormatMonth(Period period)
        {
            return period.Start.Month.ToString();
        }

        private string FormatDay(Period period)
        {
            return period.Start.Day.ToString();
        }

        private string FormatDayName(Period period)
        {
            return period.Start.DayOfWeek.ToString();
        }
    }
}

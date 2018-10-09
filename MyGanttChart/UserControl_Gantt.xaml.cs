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
    public partial class UserControl_Gantt : Window
    {
        public UserControl_Gantt()
        {
            InitializeComponent();
            DataContext = this;
            SelectionPeriod = new Period();
            
        }

        







        private GanttChartData ganttChartData = new GanttChartData();
        public GanttChartData GanttData { get { return ganttChartData; } }
        private TimeLine gridLineTimeLine;
        private ObservableCollection<TimeLine> gridLineTimeLines = new ObservableCollection<TimeLine>();
        public ObservableCollection<TimeLine> GridLineTimeLine { get { return gridLineTimeLines; } }
        public Period SelectionPeriod { get; private set; }
    }
}

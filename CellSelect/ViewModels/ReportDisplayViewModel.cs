using CellSelect.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CellSelect.ViewModels
{

    class ReportDisplayViewModel
    {
        #region Properties
        public List<CellCount> CellReport { get; set; }
        public List<DifferentialCount> DiffReport { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        #endregion

        #region ctor
        public ReportDisplayViewModel()
        {

        }
        public ReportDisplayViewModel(List<CellCount> reportList, DateTime startDate, DateTime endDate)
        {
            CellReport = reportList;
            StartDate = startDate;
            EndDate = endDate;
        }
        public ReportDisplayViewModel(List<DifferentialCount> reportList, DateTime startDate, DateTime endDate)
        {
            DiffReport = reportList;
            StartDate = startDate;
            EndDate = endDate;
        }
        public ReportDisplayViewModel(List<CellCount> reportList1, List<DifferentialCount> reportList2, DateTime startDate, DateTime endDate)
        {
            CellReport = reportList1;
            DiffReport = reportList2;
            StartDate = startDate;
            EndDate = endDate;
        }
        #endregion ctor
    }
}

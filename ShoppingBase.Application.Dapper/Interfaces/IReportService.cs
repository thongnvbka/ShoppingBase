using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShoppingBase.Application.Dapper.ViewModels;

namespace ShoppingBase.Application.Dapper.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<RevenueReportViewModel>> GetReportAsync(string fromDate, string toDate);
    }
}

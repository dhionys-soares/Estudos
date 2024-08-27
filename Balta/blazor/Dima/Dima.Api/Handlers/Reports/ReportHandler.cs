using Dima.Api.Data;
using Dima.core.Enums;
using Dima.core.Handlers;
using Dima.core.Models.Reports;
using Dima.core.Requests.Reports;
using Dima.core.Responses;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dima.Api.Handlers.Reports
{
    public class ReportHandler(AppDbContext context) : IReportHandler
    {
        public async Task<Response<List<ExpensesByCategory>?>> GetExpensesByCategoryReportAsync(GetExpensesByCategoryRequest request)
        {
            try
            {
                var data = await context.ExpensesByCategories
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId)
                    .OrderByDescending(x => x.Year)
                    .ThenBy(x => x.Category)
                    .ToListAsync();

                return new Response<List<ExpensesByCategory>?>(data);
            }
            catch
            {
                return new Response<List<ExpensesByCategory>?>(null, 500, "Não foi possível obter as saídas por categoria");
            }
        }

        public async Task<Response<FinancialSummary?>> GetFinancialSummaryReportAsync(GetFinancialSummaryRequest request)
        {
            var date = new DateTime(DateTime.Now.Year,1, 1 );
            var startDate = new DateTime(DateTime.Now.Year, DateTime
                .Now.Month, 1);
            try
            {
                var data = await context.Transactions
                    .AsNoTracking()
                    .Where(x =>
                    x.UserId == request.UserId &&
                    x.PaidOrReceivedAt >= date &&
                    x.PaidOrReceivedAt <= DateTime.Now)
                    .GroupBy(x => 1)
                    .Select(
                    x => new FinancialSummary(
                        request.UserId,
                        x.Where(t => t.Type == ETransactionType.Deposit).Sum(a => a.Amount),
                        x.Where(t => t.Type == ETransactionType.Withdraw).Sum(a => a.Amount)
                        ))
                    .FirstOrDefaultAsync();
                return new Response<FinancialSummary?>(data);
            }
            catch
            {
                return new Response<FinancialSummary?>(null, 500, "Não foi possível obter o relatório financeiro");
            }
            
        }

        public async Task<Response<List<IncomesAndExpenses>?>> GetIncomesAndExpensesReportAsync(GetIncomesAndExpensesRequest request)
        {
            try
            {
                var data = await context.IncomesAndExpenses
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId)
                    .OrderByDescending(x => x.Year)
                    .ThenBy(x => x.Month)
                    .ToListAsync();

                return new Response<List<IncomesAndExpenses>?>(data);
            }
            catch
            {
                return new Response<List<IncomesAndExpenses>?>(null, 500, "Não foi possível obter as entradas e saídas");
            }

        }

        public async Task<Response<List<IncomesByCategory>?>> GetIncomesByCategoryReportAsync(GetIncomesByCategoryRequest request)
        {
            try
            {
                var data = await context.IncomesByCategories
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId)
                    .OrderByDescending(x => x.Year)
                    .ThenBy(x => x.Category)
                    .ToListAsync();

                return new Response<List<IncomesByCategory>?>(data);
            }
            catch
            {
                return new Response<List<IncomesByCategory>?>(null, 500, "Não foi possível obter as entradas por categorias");
            }
        }
    }
}

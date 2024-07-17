using Fina.Api.Data;
using Fina.Core.Enums;
using Fina.Core.Extensions.Common;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Handlers
{
    public class TransactionHandler(AppDbContext context) : ItransactionHandler
    {
        public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
        {
            if (request.Type == ETransactionType.Withdraw && request.Amount >= 0)
                request.Amount *= -1;
            
            var transaction = new Transaction 
            { 
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                CreatedAt = DateTime.Now,
                Amount = request.Amount,
                PaidOrReceivedAt = request.PaidOrReceivedAt,
                Title = request.Title,
                Type = request.Type                
            };

            try
            {
                await context.Transactions.AddAsync(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, 201, "Transaction criada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Response<Transaction?>(null, 500, "Não foi possível criar transaction");
            }
            
            
        }

        public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
        {
            var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (transaction == null)
                return new Response<Transaction?>(null, 404, message: "Transaction não encontrada");

            try
            {
                context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();
                return new Response<Transaction?>(transaction, message: "Transaction excluída com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Response<Transaction?>(null, 500, "Não foi possível excluir transaction");
            }
        }

        public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
        {
            var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            return transaction is null
                ? new Response<Transaction?>(null, 404, message: "Transaction não encontrada")
                : new Response<Transaction?>(transaction);
        }

        public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
        {
            try
            {
                request.StartDate ??= DateTime.Now.GetFirstDay();
                request.EndDate ??= DateTime.Now.GetLastDay();


                var query = context.Transactions.AsNoTracking().Where(x => x.PaidOrReceivedAt >= request.StartDate && x.PaidOrReceivedAt <= request.EndDate && x.UserId == request.UserId).OrderBy(x => x.PaidOrReceivedAt);

                var transactions = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await context.Transactions.CountAsync();

                return new PagedResponse<List<Transaction>?>(transactions, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Transaction>?>(null, message: "Não foi possível obter as transactions");
            
            }
        }

        public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
        {
            if (request.Type == ETransactionType.Withdraw && request.Amount >= 0)
                request.Amount *= -1;

            var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (transaction == null)
                return new Response<Transaction?>(null, 404, message: "Transaction não encontrada");

            try
            {
                transaction.CategoryId = request.CategoryId;
                transaction.Amount = request.Amount;
                transaction.Type = request.Type;
                transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;

                context.Transactions.Update(transaction);
                await context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, message: "Transaction atualizada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Response<Transaction?>(null, 500, "Não foi possível criar transaction");
            }
        }
    }
}

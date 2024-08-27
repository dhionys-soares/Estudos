using Dima.Api.Data;
using Dima.core.Common.Extensions;
using Dima.core.Enums;
using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Transactions;
using Dima.core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers.Transactions
{
    public class TransactionHandler(AppDbContext Context) : ITransactionHandler
    {
        public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
        {
            if (request is { Type: ETransactionType.Withdraw, Amount: >= 0 })
                request.Amount *= -1;
            try
            {
                var transaction = new Transaction
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Type = request.Type,
                    Amount = request.Amount,
                    PaidOrReceivedAt = request.PaidOrReceivedAt,
                    CategoryId = request.CategoryId,
                    CreatedAt = DateTime.Now
                };

                var result = await Context.Transactions.AddAsync(transaction);
                await Context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, 201, "Transação criada com sucesso");
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Não foi possível criar transação");
            }
        }

        public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
        {
            try
            {
                var transaction = await Context.Transactions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);
                if (transaction == null)
                    return new Response<Transaction?>(null, 404, "Transação não encontrada");

                Context.Transactions.Remove(transaction);
                await Context.SaveChangesAsync();
                return new Response<Transaction?>(transaction, 200, "Transação excluída com sucesso");
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Não foi possível excluir a transação");
            }

        }

        public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
        {
            try
            {
                var transaction = await Context.Transactions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return transaction is not null
                    ? new Response<Transaction?>(transaction)
                    : new Response<Transaction?>(null, 404, "Transação não encontrada");
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Não foi possível obter a transação");
            }

        }

        public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
        {
            try
            {
                request.StartDate ??= DateTime.Now.GetFirstDay();
                request.EndDate ??= DateTime.Now.GetLastDay();

                var query = Context.Transactions.AsNoTracking().Where(
                    x => x.PaidOrReceivedAt >= request.StartDate && 
                    x.PaidOrReceivedAt <= request.EndDate 
                    && x.UserId == request.UserId)
                    .OrderBy(x => 
                    x.PaidOrReceivedAt);

                var transactions = await query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

                var count = await query.CountAsync();
                
                return transactions is null
                    ? new PagedResponse<List<Transaction>?>(null, 404, "Transações não encontradas")
                    : new PagedResponse<List<Transaction>?>(transactions, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Transaction>?>(null, 500, "Não foi possível obter as transações");
            }
            
        }

        public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
        {
            if (request is { Type: ETransactionType.Withdraw, Amount: >= 0 })
                request.Amount *= -1;
            try
            {
                var transaction = await Context.Transactions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (transaction is null)
                    return new Response<Transaction?>(null, 404, "Transação não encontrada");

                transaction.Title = request.Title;
                transaction.Amount = request.Amount;
                transaction.PaidOrReceivedAt = request.PaidOrReceivedAt;
                transaction.CategoryId = request.CategoryId;
                transaction.Type = request.Type;

                Context.Transactions.Update(transaction);
                await Context.SaveChangesAsync();
                return new Response<Transaction?>(transaction   );
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Não foi possível atualizar a transação");
            }
        }
    }
}

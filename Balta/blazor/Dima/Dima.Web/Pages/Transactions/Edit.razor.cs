using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Categories;
using Dima.core.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Transactions
{
    public partial class EditTransactionPage : ComponentBase
    {
        #region Proporties
        [Parameter]
        public string Id { get; set; } = string.Empty;
        public bool IsBusy { get; set; } = false;
        public UpdateTransactionRequest InputModel { get; set; } = new();
        public List<Category> Categories { get; set; } = [];

        #endregion

        #region Services

        [Inject]
        ITransactionHandler TransactionHandler { get; set; } = null!;
        [Inject]
        ICategoryHandler CategoryHandler { get; set; } = null!;
        [Inject]
        ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;

            try
            {
                await GetTransactionByIdAsync();
                await GetAllCategoriesAsync();
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            try
            {
                var result = await TransactionHandler.UpdateAsync(InputModel);
                if (result.IsSucess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/lancamentos/historico");
                }


                else
                {
                    Snackbar.Add(result.Message, Severity.Error);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        #region Private Methods
        private async Task GetAllCategoriesAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllCategoriesRequest();
                var result = await CategoryHandler.GetAllAsync(request);
                if (result.IsSucess)
                {
                    Categories = result.Data ?? [];
                    InputModel.CategoryId = Categories.FirstOrDefault()?.Id ?? 0;
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GetTransactionByIdAsync()
        {
            IsBusy = true;

            try
            {
                var request = new GetTransactionByIdRequest { Id = long.Parse(Id) };
                var result = await TransactionHandler.GetByIdAsync(request);
                if (result is { IsSucess: true, Data: not null })
                    InputModel = new UpdateTransactionRequest
                    {
                        Id = result.Data.Id,
                        Amount = result.Data.Amount,
                        Title = result.Data.Title,
                        CategoryId = result.Data.CategoryId,
                        PaidOrReceivedAt = result.Data.PaidOrReceivedAt,
                        Type = result.Data.Type
                    };

            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}

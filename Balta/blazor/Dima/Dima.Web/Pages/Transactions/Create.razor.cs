﻿using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Categories;
using Dima.core.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Transactions
{
    public class CreateTransactionPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public CreateTransactionRequest InputModel { get; set; } = new();
        public List<Category> Categories { get; set; } = [];
        #endregion

        #region Services

        [Inject]
        public ITransactionHandler TransactionHandler { get; set; } = null!;

        [Inject]
        public ICategoryHandler CategoryHandler { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
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

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await TransactionHandler.CreateAsync(InputModel);
                if (result.IsSucess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    await Task.Delay(2000);
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

            #endregion
        }
    }
}
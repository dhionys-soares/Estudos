﻿using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Categories
{
    public partial class ListCategoriesPage : ComponentBase
    {
        #region Properties
        public bool IsBusy { get; set; } = false;
        public List<Category> Categories { get; set; } = [];
        public string SearchTerm { get; set; } = string.Empty;
        #endregion

        #region Services

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public ICategoryHandler Handler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public IDialogService DialogService { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;

            try
            {
                var request = new GetAllCategoriesRequest();
                var result = await Handler.GetAllAsync(request);
                if (result.IsSucess)
                    Categories = result.Data ?? [];
                else
                    Snackbar.Add(result.Message, Severity.Error);
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

        public Func<Category, bool> Filter
            => category =>
            {
                if (string.IsNullOrWhiteSpace(SearchTerm))
                    return true;

                if (category.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    return true;

                if (category.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    return true;

                if (category.Description is not null && category.Description.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    return true;

                return false;
            };

        public async void OnDeleteButtonClickedAsync(long id, string title)
        {
            var result = await DialogService.ShowMessageBox("Atenção!", $"Ao prosseguir, a categoria {title} será excluída. Deseja continuar?", yesText: "Excluir", cancelText: "Cancelar");
            if (result is true)
                await OnDeleteAsync(id, title);

            StateHasChanged();
        }

        public async Task OnDeleteAsync(long id, string title)
        {
            try
            {
                await Handler.DeleteAsync(new DeleteCategoryRequest { Id = id });
                Categories.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Categoria {title} excluída", Severity.Success);
            }
            catch(Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        #endregion
    }
}

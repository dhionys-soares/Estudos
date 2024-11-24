using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Products
{
    public partial class ListProductsPage : ComponentBase
    {
        #region Properties

        public List<Product> Products { get; set; } = [];
        public bool IsBusy { get; set; } = false;
        #endregion

        #region Services

        [Inject] public ISnackbar Snackbar { get; set; } = null!;
        [Inject] public IProductHandler Handler { get; set; } = null!;
        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllProductsRequest();
                var result = await Handler.GetAllAsync(request);

                if (result.IsSucess)
                    Products = result.Data ?? [];
            }
            catch(Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
    #endregion
}

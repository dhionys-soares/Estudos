using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Requests.Stripe;
using Dima.Web.Pages.Orders;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System.ComponentModel.Design;

namespace Dima.Web.Components.Orders
{
    public partial class OrderActionComponent : ComponentBase
    {
        #region Parameters
        [Parameter, EditorRequired]
        public Order Order { get; set; } = null!;

        [CascadingParameter]
        public DetailsPage Parent { get; set; } = null!;
        #endregion

        #region Services
        [Inject] IOrderHandler OrderHandler { get; set; } = null!;
        [Inject] IJSRuntime JSRuntime { get; set; } = null!;
        [Inject] IStripeHandler StripeHandler { get; set; } = null!;
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        [Inject] IDialogService Dialog { get; set; } = null!;
        #endregion

        #region Public Methods
        public async void OnCancelButtonClikedAsync()
        {
            var result = await Dialog.ShowMessageBox("Atenção!", "Você deseja realmente cancelar este pedido?", "Sim", cancelText: "Não");
            if (result is not null && result == true)
                await CancelOrderAsync();
        }

        public async void OnPayButtonClickedAsync()
        {
            await PayOrderAsync();
        }

        public async void OnRefundButtonClikedAsync()
        {
            var result = await Dialog.ShowMessageBox("Atenção!", "Você deseja realmente estornar este pedido?", "Sim", cancelText: "Não");
            if (result is not null && result == true)
                await RefundOrderAsync();
        }
        #endregion

        #region Private Methods
        private async Task CancelOrderAsync()
        {
            var request = new CancelOrderRequest { Id = Order.Id };
            var result = await OrderHandler.CancelAsync(request);
            if (result.IsSucess)
            {
                Parent.RefreshState(result.Data!);
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }

        private async Task PayOrderAsync()
        {
            var request = new CreateSessionRequest
            {
                OrderNumber = Order.Number,
                OrderTotal = (int)(Math.Round(Order.Total *100, 2)),
                ProductTitle = Order.Product.Title,
                ProductDescription = Order.Product.Description,
            };

            try
            {
                var result = await StripeHandler.CreateSessionAsync(request);
                
                if (result.IsSucess == false)
                {
                    Snackbar.Add(result.Message, Severity.Error);
                    return;
                }
                if (result.Data is null)
                {
                    Snackbar.Add(result.Message, Severity.Error);
                    return;
                }

                await JSRuntime.InvokeVoidAsync("checkout", Configuration.StripePublicKey, result.Data);

            }
            catch
            {
                Snackbar.Add("Não foi possível iniciar sessão com stripe", Severity.Error);
            }
        }

        private async Task RefundOrderAsync()
        {
            var request = new RefundOrderRequest { Id = Order.Id };
            var result = await OrderHandler.RefundAsync(request);
            if (result.IsSucess)
            {
                Parent.RefreshState(result.Data!);
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }
        #endregion
    }
}

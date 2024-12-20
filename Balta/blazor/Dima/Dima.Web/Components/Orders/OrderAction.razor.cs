﻿using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.Web.Pages.Orders;
using Microsoft.AspNetCore.Components;
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
        [Inject] IOrderHandler Handler { get; set; } = null!;
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        [Inject] IDialogService Dialog { get; set; } = null!;
        #endregion

        #region Public Methods
        public async void OnCancelButtonCliked()
        {
            var result = await Dialog.ShowMessageBox("Atenção!", "Você deseja realmente cancelar este pedido?", "Sim", cancelText: "Não");
            if (result is not null && result == true)
                await CancelOrderAsync();
        }
        #endregion

        #region Private Methods
        private async Task CancelOrderAsync()
        {
            var request = new CancelOrderRequest { Id = Order.Id };
            var result = await Handler.CancelAsync(request);
            if (result.IsSucess)
            {
                Parent.RefreshState(result.Data!);
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
            #endregion
        }
    }
}

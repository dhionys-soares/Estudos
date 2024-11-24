using Dima.core.Handlers;
using Dima.core.Models;
using Dima.core.Requests.Orders;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Orders
{
    public partial class CheckoutPage : ComponentBase
    {
        #region Parameters

        [Parameter]
        public string ProductSlug { get; set; } = string.Empty;

        [SupplyParameterFromQuery(Name = "voucher")]
        public string? VoucherNumber { get; set; }

        #endregion

        #region Properties

        public PatternMask Maskara = new("####-####")
        {
            MaskChars = [new MaskChar('#', @"[0-9a-fA-F]")],
            Placeholder = '_',
            CleanDelimiters = true,
            Transformation = AllUperCase
        };
        public bool IsBusy { get; set; }
        public bool IsValid { get; set; }
        public CreateOrderRequest InputModel { get; set; } = new();
        public Product? Product { get; set; }
        public Voucher? Voucher { get; set; }
        public decimal Total { get; set; }
        #endregion

        #region Services

        [Inject] public ISnackbar Snackbar { get; set; } = null!;
        [Inject] public IProductHandler ProductHandler { get; set; } = null!;
        [Inject] public IOrderHandler OrderHandler { get; set; } = null!;
        [Inject] public IVoucherHandler VoucherHandler { get; set; } = null!;
        [Inject] public NavigationManager NavigationManager { get; set; } = null!;
        #endregion

        #region Methods
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var result = await ProductHandler.GetBySlugAsync(new GetProductBySlugRequest { Slug = ProductSlug });

                if (result.IsSucess == false)
                {
                    Snackbar.Add("Não foi possível obter o produto", Severity.Error);
                    return;
                }

                Product = result.Data;

                if (Product is null)
                {
                    Snackbar.Add("Não foi possível obter o produto", Severity.Error);
                    IsValid = false;
                    return;
                }

                if (string.IsNullOrEmpty(VoucherNumber) == false)
                {
                    try
                    {
                        var resultVoucher = await VoucherHandler.GetByNumberAsync(new GetVoucherByNumberRequest { Number = VoucherNumber.Replace("-", "") });

                        if (resultVoucher.IsSucess == false || result.Data is null)
                        {
                            VoucherNumber = string.Empty;
                            Snackbar.Add("Não foi possível obter o voucher", Severity.Error);
                        }

                        Voucher = resultVoucher.Data;
                    }
                    catch
                    {
                        VoucherNumber = string.Empty;
                        Snackbar.Add("Não foi possível obter o voucher", Severity.Error);
                    }
                }
            }
            catch
            {
                Snackbar.Add("Não foi possível obter o produto", Severity.Error);
                IsValid = false;
                return;
            }
            IsValid = true;
            Total = Product.Price - (Voucher?.Amount ?? 0);
        }

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var request = new CreateOrderRequest { ProductId = Product!.Id, VoucherId = Voucher?.Id ?? null };
                var result = await OrderHandler.CreateAsync(request);
                if (result.IsSucess)
                    NavigationManager.NavigateTo($"/pedidos/{result.Data!.Number}");

                else
                    Snackbar.Add(result.Message, Severity.Error);

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
        private static char AllUperCase(char c) => c.ToString().ToUpperInvariant()[0];
        #endregion


    }
}

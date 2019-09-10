using PackageDelivery.Common;

namespace PackageDelivery.Delivery
{
    public class EditPackageViewModel : ViewModel
    {


        public Command ChangeProduct1Command { get; }
        public Command ChangeProduct2Command { get; }
        public Command ChangeProduct3Command { get; }
        public Command ChangeProduct4Command { get; }
        public Command RecalculateCostCommand { get; }

        public Command OkCommand { get; }
        public Command CancelCommand { get; }

        public override string Caption => "Edit Package";
        public override double Height => 410;


            CostEstimate = _delivery.ESTM_CLM;

            OkCommand = new Command(Save);
            CancelCommand = new Command(() => DialogResult = false);
            ChangeProduct1Command = new Command(() => ChangeProduct(ref _product1, nameof(Product1Name)));
            ChangeProduct2Command = new Command(() => ChangeProduct(ref _product2, nameof(Product2Name)));
            ChangeProduct3Command = new Command(() => ChangeProduct(ref _product3, nameof(Product3Name)));
            ChangeProduct4Command = new Command(() => ChangeProduct(ref _product4, nameof(Product4Name)));
            RecalculateCostCommand = new Command(RecalculateCost);
        }

        private void RecalculateCost()
        {
            CostEstimate = (Amount1 + Amount2 + Amount3 + Amount4) * 40;
            Notify(nameof(CostEstimate));
        }

        private void ChangeProduct(ref Prdct product, string propertyToNotify)
        {
            var viewModel = new ChangeProductViewModel();

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                product = viewModel.SelectedProduct;
                Notify(propertyToNotify);
            }
        }

        private void Save()
        {
            
            DialogResult = true;
        }
    }
}

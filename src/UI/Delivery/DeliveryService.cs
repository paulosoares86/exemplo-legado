namespace PackageDelivery.Delivery
{
    public class DeliveryService
    {
        private Cstm _customer;

        public string CustomerName => _customer == null ? string.Empty : _customer.NM_CLM;
        public string AddressLine { get; set; }
        public string CityState { get; set; }
        public string ZipCode { get; set; }
        
        private readonly Dlvr _delivery;

        private Prdct _product1;
        public string Product1Name => _product1 == null ? string.Empty : _product1.NM_CLM;
        public int Amount1 { get; set; }

        private Prdct _product2;
        public string Product2Name => _product2 == null ? string.Empty : _product2.NM_CLM;
        public int Amount2 { get; set; }

        private Prdct _product3;
        public string Product3Name => _product3 == null ? string.Empty : _product3.NM_CLM;
        public int Amount3 { get; set; }

        private Prdct _product4;
        public string Product4Name => _product4 == null ? string.Empty : _product4.NM_CLM;
        public int Amount4 { get; set; }

        public double CostEstimate { get; set; }

        public DeliveryService(Dlvr delivery)
        {
            _delivery = delivery;
            _product1 = _delivery.PRD_LN_1 == null ? null : DBHelper.GetProduct(_delivery.PRD_LN_1.Value);
            _product2 = _delivery.PRD_LN_2 == null ? null : DBHelper.GetProduct(_delivery.PRD_LN_2.Value);
            _product3 = _delivery.PRD_LN_3 == null ? null : DBHelper.GetProduct(_delivery.PRD_LN_3.Value);
            _product4 = _delivery.PRD_LN_4 == null ? null : DBHelper.GetProduct(_delivery.PRD_LN_4.Value);
            Amount1 = _delivery.PRD_LN_1_AMN == null ? 0 : int.Parse(_delivery.PRD_LN_1_AMN);
            Amount2 = _delivery.PRD_LN_2_AMN == null ? 0 : int.Parse(_delivery.PRD_LN_2_AMN);
            Amount3 = _delivery.PRD_LN_3_AMN == null ? 0 : int.Parse(_delivery.PRD_LN_3_AMN);
            Amount4 = _delivery.PRD_LN_4_AMN == null ? 0 : int.Parse(_delivery.PRD_LN_4_AMN);
        }

        private void MarkAsInProgress(Dlvr delivery)
        {
            DBHelper.UpdateStatus(delivery.NMB_CLM, "P");
        }
        
        public bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(CustomerName)
                && !string.IsNullOrWhiteSpace(AddressLine)
                && !string.IsNullOrWhiteSpace(CityState) && CityState.Trim().Contains(" ")
                && !string.IsNullOrWhiteSpace(ZipCode);
        }

        public void SaveDelivery()
        {
            DBHelper.SaveDelivery(_customer, AddressLine, CityState, ZipCode);
        }

        public void SaveProducts()
        {
            DBHelper.UpdateDelivery(_delivery.NMB_CLM, _product1, Amount1, _product2, Amount2, _product3, Amount3, _product4, Amount4, CostEstimate);
        }
    }
}

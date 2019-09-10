using System;
using System.Linq;
using PackageDelivery.Delivery;

namespace PackageDelivery
{
    public static class Program
    {
        private const string ConnectionString = @"Server=localhost;Database=PackageDelivery;User Id=sa;Password=P@ssw0rd;";

        public static void Main(string[] args)
        {
            DBHelper.Init(ConnectionString);
            var customer = DBHelper.GetAllCustomers().FirstOrDefault();
            var product = DBHelper.GetAllProducts().FirstOrDefault();
            const string addressLine = "Visconde de Nacar";
            const string cityState = "SJC - SP";
            const string zipCode = "12244";
            DBHelper.SaveDelivery(customer, addressLine, cityState, zipCode);

            var delivery = DBHelper.GetAllDeliveries().LastOrDefault();
            DBHelper.UpdateDelivery(
                delivery.NMB_CLM, product, 100, null, 0, 
                null, 0, null, 0, 150
                );
        }
    }
}
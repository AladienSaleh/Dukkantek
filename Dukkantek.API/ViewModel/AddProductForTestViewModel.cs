using Dukkantek.Shared.Enums;

namespace Dukkantek.API.ViewModel
{
    public class AddProductForTestViewModel
    { 
        public string ProductName { get; set; }

        public string Barcode { get; set; }

        public string ProductDescription { get; set; }

        public double Weight { get; set; }

        public Status Status { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

    }

    public class ChangeProductStatusAsyncViewModel
    {
        public int ProductId { get; set; }

        public Status NewStatus { get; set; }
    }
}

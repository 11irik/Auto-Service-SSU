namespace IAutoService.DAL.Entities
{
    public class CarPart
    {
        private long _id;
        private long _manufacturerId;
        private string _name;
        private int _stock;
        private double _price;

        public CarPart()
        {
            
        }

        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public long ManufacturerId
        {
            get => _manufacturerId;
            set => _manufacturerId = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Stock
        {
            get => _stock;
            set => _stock = value;
        }

        public double Price
        {
            get => _price;
            set => _price = value;
        }
    }
}
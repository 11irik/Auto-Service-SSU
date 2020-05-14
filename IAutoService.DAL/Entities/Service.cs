namespace IAutoService.DAL.Entities
{
    public class Service
    {
        private long _id;
        private string _name;
        private double _price;

        public Service()
        {
            
        }

        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public double Price
        {
            get => _price;
            set => _price = value;
        }
    }
}
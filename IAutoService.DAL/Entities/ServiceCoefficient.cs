namespace IAutoService.DAL.Entities
{
    public class ServiceCoefficient
    {
        private long _id;
        private string _name;
        private double _coefficient;

        public ServiceCoefficient()
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

        public double Coefficient
        {
            get => _coefficient;
            set => _coefficient = value;
        }
    }
}
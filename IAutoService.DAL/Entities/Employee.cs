namespace IAutoService.DAL.Entities
{
    public class Employee
    {
        private long _id;
        private string _name;
        private string _lastName;
        private double _salary;

        public Employee()
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

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public double Salary
        {
            get => _salary;
            set => _salary = value;
        }
    }
}
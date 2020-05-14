namespace IAutoService.DAL.Entities
{
    public class Client
    {
        private long _id;
        private string _name;
        private string _lastName;
        private string _phoneNumber;

        public Client()
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

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }
    }
}
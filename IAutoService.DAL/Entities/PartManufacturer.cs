namespace IAutoService.DAL.Entities
{
    public class PartManufacturer
    {
        private string _name;
        private long _id;
        private bool _active;

        public PartManufacturer()
        {
            
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public bool Active
        {
            get => _active;
            set => _active = value;
        }
    }
}
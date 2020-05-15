using System;

namespace IAutoService.DAL.Entities
{
    public class Car
    {
        private long _id;
        private long _clientId;
        private string _brand;
        private string _number;
        private Int16 _year;

        public Car()
        {
        }

        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public long ClientId
        {
            get => _clientId;
            set => _clientId = value;
        }

        public string Brand
        {
            get => _brand;
            set => _brand = value;
        }

        public string Number
        {
            get => _number;
            set => _number = value;
        }

        public Int16 Year
        {
            get => _year;
            set => _year = value;
        }
    }
}
using System;

namespace IAutoService.DAL.Entities
{
    public class Contract
    {
        private long _contractId;
        private long _carId;
        private DateTime _startDate;
        private DateTime _endDate;
        

        public Contract()
        {
        }

        public long ContractId
        {
            get => _contractId;
            set => _contractId = value;
        }

        public long CarId
        {
            get => _carId;
            set => _carId = value;
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => _endDate = value;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoService.BLL;
using AutoService.DAL;
using AutoService.PL.Models;
using IAutoService.BLL;
using IAutoService.DAL;
using IAutoService.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.PL.Controllers
{
    public class ContractController : Controller
    {
        private IContractBLL _contractBll;
        private IServiceBLL _serviceBll;
        private ICarBLL _carBll;
        private IClientBLL _clientBll;

        private List<ContractModel> _contracts;
        private IEnumerable _contractServices;

        public ContractController()
        {
            _contractBll = new ContractBLL();
            _serviceBll = new ServiceBLL();
            _carBll = new CarBLL();
            _clientBll = new ClientBLL();
            
        }

        [HttpGet]
        public IActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                _contracts = new List<ContractModel>();
                foreach (Contract contract in _contractBll.GetAllByPhone(searchString))
                {
                    ContractModel model = new ContractModel()
                    {
                        _startDate = contract.StartDate,
                        _endDate = contract.EndDate,
                        _id = contract.ContractId,
                        _carNumber = _carBll.Get(contract.CarId).Number,
                        _services = _contractBll.GetContractServices(contract.ContractId),
                        _carId = contract.CarId,
                        _clientLastName = _clientBll.Get(_carBll.Get(contract.CarId).ClientId).LastName,
                        _clientPhone = _clientBll.Get(_carBll.Get(contract.CarId).ClientId).PhoneNumber,
                        _clientName = _clientBll.Get(_carBll.Get(contract.CarId).ClientId).Name,
                        _sum = _contractBll.GetContractPrice(contract.ContractId)

                    };
                    _contracts.Add(model);
                }
                ViewData["Contracts"] = _contracts;
            }
            else
            {
                _contracts = new List<ContractModel>();
                foreach (Contract contract in _contractBll.GetAllOpened())
                {
                    ContractModel model = new ContractModel()
                    {
                        _startDate = contract.StartDate,
                        _endDate = contract.EndDate,
                        _id = contract.ContractId,
                        _carNumber = _carBll.Get(contract.CarId).Number,
                        _services = _contractBll.GetContractServices(contract.ContractId),
                        _carId = contract.CarId,
                        _clientLastName = _clientBll.Get(_carBll.Get(contract.CarId).ClientId).LastName,
                        _clientPhone = _clientBll.Get(_carBll.Get(contract.CarId).ClientId).PhoneNumber,
                        _clientName = _clientBll.Get(_carBll.Get(contract.CarId).ClientId).Name,
                        _sum = _contractBll.GetContractPrice(contract.ContractId)

                    };
                    _contracts.Add(model);
                }
                ViewData["Contracts"] = _contracts;
            }
            return View("Contract");
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ContractModel model = new ContractModel();
            Contract c = _contractBll.GetById(id.Value).FirstOrDefault();
            model._startDate = c.StartDate;
            model._carId = c.CarId;
            model._id = c.ContractId;
            model._sum = _contractBll.GetContractPrice(c.ContractId);
            model._clientLastName = _clientBll.Get(_carBll.Get(c.CarId).ClientId).LastName;
            model._clientPhone = _clientBll.Get(_carBll.Get(c.CarId).ClientId).PhoneNumber;
            model._clientName = _clientBll.Get(_carBll.Get(c.CarId).ClientId).Name;
            model._carNumber = _carBll.Get(c.CarId).Number;
            model._brandName = _carBll.Get(c.CarId).Brand;
            ViewData["Services"] = _serviceBll.GetAll();//todo
            model._services = _contractBll.GetContractServices(id.Value);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddService(string contractId, string serviceId)
        {
            long a = long.Parse(contractId);
            long b = long.Parse(serviceId);
            try
            {
                _contractBll.AddService(a, b, 1, DateTime.Now);
            }
            catch (Exception e)
            {
                // ignored
            }

            return RedirectToAction("Details", new {id = a});
        }
        
        [HttpPost]
        public IActionResult DeleteService(string contractId, string serviceId)
        {
            long a = long.Parse(contractId);
            long b = long.Parse(serviceId);
            _contractBll.DeleteContractService(a, b);
            return RedirectToAction("Details", new {id = a});
        }
        
        [HttpPost]
        public IActionResult CloseContract(string conId)
        {
            long a = long.Parse(conId);
            Contract c = _contractBll.GetById(a).FirstOrDefault();
            _contractBll.UpdateDate(c.ContractId, DateTime.Parse(c.StartDate.ToString()), DateTime.Now);
           
            return RedirectToAction("Index");
        }
    }
}
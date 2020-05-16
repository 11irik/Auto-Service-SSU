using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoService.BLL;
using IAutoService.BLL;
using IAutoService.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.PL.Controllers
{
    public class AdminController : Controller
    {
        private IClientBLL _ClientBll { get; set; }
        private ICarBLL _carBll { get; set; }
        private IContractBLL _contractBll { get; set; }
        private IEmployeeBLL _employeeBll { get; set; }
        private ServiceBLL _serviceBll { get; set; }
        
        private IEnumerable _clients { get; set; }
        private IEnumerable _cars { get; set; }
        private IEnumerable _contracts { get; set; }
        private IEnumerable _employees { get; set; }
        private IEnumerable _services { get; set; }
        
        public AdminController()
        {
            _ClientBll = new ClientBLL();
            _carBll = new CarBLL();
            _contractBll = new ContractBLL();
            _employeeBll = new EmployeeBLL();
            _serviceBll = new ServiceBLL();
            
            ViewData["Clients"] = _clients;
            ViewData["Cars"] = _cars;
            ViewData["Contracts"] = _contracts;
            ViewData["Employees"] = _employees;
            ViewData["Services"] = _services;
        }
     
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Client(string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                List<Client> l = new List<Client>();
                    l.Add(_ClientBll.Get(SearchString));
                    _clients = l;
            }
            else
            {
                _clients = _ClientBll.GetAll();
            }
            ViewData["Clients"] = _clients;

            return View();
        }
        
        public IActionResult Contract(string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                _contracts = _contractBll.GetAllByPhone(SearchString);
            }
            else
            {
                _contracts = _contractBll.GetAll();
            }
            ViewData["Contracts"] = _contracts;

            return View();
        }
        
        public IActionResult Car(string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                List<Client> l = new List<Client>();
                    l.Add(_ClientBll.Get(SearchString));
                    _clients = l;
                _cars = _ClientBll.GetClientCars(l[0].Id);
            }
            else
            {
                _cars = _carBll.GetAll();
            }
            ViewData["Cars"] = _cars;

            return View();
        } 
        
        public IActionResult Employee()
        {
            _employees = _employeeBll.GetAll();
            ViewData["Employees"] = _employees;

            return View();
        }
        
        public IActionResult Service()
        {
            _services = _serviceBll.GetAll();
            ViewData["Services"] = _services;

            return View();
        }
        
        public IActionResult UpdateClient(string upClientId, string upClientName, string upClientLastName, string upClientPhone)
        {
            long id = long.Parse(upClientId);
            _ClientBll.Update(id, upClientName, upClientLastName, upClientPhone);
            return RedirectToAction("Client");
        }


        public IActionResult DeleteClient(string clientId)
        {
            long id = long.Parse(clientId);
            _ClientBll.Delete(_ClientBll.Get(id).PhoneNumber);
            return RedirectToAction("Client");
        }

        public IActionResult UpdateCar(string upCarId, string upCarNumber, string upCarBrand, string upCarYear)
        {
            long id = long.Parse(upCarId);
            Int16 year = Int16.Parse(upCarYear);
            _carBll.Update(id, upCarNumber, upCarBrand, year);
            return RedirectToAction("Car");
        }


        public IActionResult DeleteCar(string carId)
        {
            long id = long.Parse(carId);
            _carBll.Delete(_carBll.Get(id).Number);
            return RedirectToAction("Car");
        }
        
        public IActionResult ExpandContract(string contractId)
        {
            long id = long.Parse(contractId);
            Contract c = _contractBll.GetById(id).FirstOrDefault();
            _contractBll.UpdateDate(c.ContractId, c.StartDate, DateTime.MinValue);
            return RedirectToAction("Contract");
        }
        
        public IActionResult DeleteContract(string cId)
        {
            long id = long.Parse(cId);
            _contractBll.Delete(id);
            return RedirectToAction("Contract");
        }
        
        public IActionResult AddEmployee(string empName, string empLastName, string empSalary)
        {
            double salary = double.Parse(empSalary);
            _employeeBll.Create(empName, empLastName, salary);
            return RedirectToAction("Employee");
        }
        
        public IActionResult DeleteEmployee(string empId)
        {
            long id = long.Parse(empId);
            _employeeBll.Delete(id);
            return RedirectToAction("Employee");
        }
        
        public IActionResult AddService(string servName, string servPrice)
        {
            double price = double.Parse(servPrice);
            _serviceBll.Create(servName, price);
            return RedirectToAction("Service");
        }
        
        public IActionResult DeleteService(string servId)
        {
            long id = long.Parse(servId);
            _serviceBll.Delete(id);
            return RedirectToAction("Service");
        }
        
        // public IActionResult WriteEmployee(string servId, string empId)
        // {
        //     long sId = long.Parse(servId);
        //     long eId = long.Parse(empId);
        //     _serviceBll.WriteEmployee(sId, eId);
        //     return RedirectToAction("Service");
        // }
        //
        // public IActionResult WriteOutEmployee(string servId, string empId)
        // {
        //     long sId = long.Parse(servId);
        //     long eId = long.Parse(empId);
        //     _serviceBll.WriteOutEmployee(sId, eId);
        //     return RedirectToAction("Service");
        // }
        //
        // public IActionResult GetServiceEmployees(string servId)
        // {
        //     long sId = long.Parse(servId);
        //     _serviceBll.GetAllByService(sId);
        //     return RedirectToAction("Service");
        // }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoService.BLL;
using AutoService.PL.Models;
using IAutoService.BLL;
using IAutoService.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoService.PL.Controllers
{
    public class ClientController : Controller
    {
        private IContractBLL _contractBll;
        private IClientBLL _clientBll;
        private IServiceBLL _serviceBll;
        private ICarBLL _carBll;

        private List<Client> _clients;
        private IEnumerable _contractServices;

        public ClientController()
        {
            _contractBll = new ContractBLL();
            _serviceBll = new ServiceBLL();
            _clientBll = new ClientBLL();
            _carBll = new CarBLL();
        }

        [HttpGet]
        public IActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                ClientModel client = new ClientModel();
                Client c = _clientBll.Get(searchString);
                client._id = c.Id;
                client._name = c.Name;
                client._phone = c.PhoneNumber;
                client._lastName = c.LastName;
                client._car = _clientBll.GetClientCars(client._id);
                _clients = new List<Client>();
                _clients.Add(c);
                ViewData["Clients"] = _clients;
            }
            else
            {
                _clients = _clientBll.GetAll().ToList();
                ViewData["Clients"] = _clients;
            }
            return View("Client");
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ClientModel client = new ClientModel();
            Client c = _clientBll.Get(id.Value);
            client._id = c.Id;
            client._name = c.Name;
            client._phone = c.PhoneNumber;
            client._lastName = c.LastName;
            client._car = _clientBll.GetClientCars(client._id);
            return View(client);
        }

        [HttpPost]
        public IActionResult AddCar(string brandName, string manufacturerYear, string number, string clientId)
        {
            long id = long.Parse(clientId);
            Int16 year = Int16.Parse(manufacturerYear);
            try
            {
                _carBll.Create(id, number, brandName, year);
            }
            catch (Exception e)
            {
                // ignored
            }

            return RedirectToAction("Details", new {id = id});
        }
        
        [HttpPost]
        public IActionResult AddClient(string name, string lastName, string phoneNumber)
        {
            _clientBll.Create(name, lastName, phoneNumber);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateContract(string carId)
        {
            long id = long.Parse(carId);
            Contract c = _contractBll.Create(id, DateTime.Now);
           
            return RedirectToAction("Details", "Contract", new {id = c.ContractId});
        }
    }
}
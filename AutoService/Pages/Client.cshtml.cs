using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoService.DAL;
using IAutoService.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoService.Pages
{
    public class ClientModel : PageModel
    {
        public void OnGet()
        {

        }

        public long Get()
        {
            ClientDao a = new ClientDao();
            Client client = a.Create("Test", "Test", "Test");
            return client.Id;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BorrowEquip.Models;
using Microsoft.AspNetCore.Mvc;


namespace BorrowEquip.Controllers
{
    public class RequestController : Controller
    {
        private static List<EquipmentRequest> _equipmentRequest;
        private static int nextId = 3; 

        [HttpPost]
        public IActionResult RequestForm(EquipmentRequest equipRequest) {
            
            if (ModelState.IsValid)
            {
                equipRequest.Id = nextId++;
                _equipmentRequest.Add(equipRequest);
                ModelState.Clear();
                
                return View(new EquipmentRequest());
            }
            return View(equipRequest);
        }

        static RequestController()
        {
            _equipmentRequest = new List<EquipmentRequest> {

                new EquipmentRequest { Id = 1, Name = "John Doe", Email = "JohnDoe@email.com", 
                    PhoneNumber = "123-456-7890", Role = UserRole.Student, 
                    EquipmentType = EquipmentType.Laptop, RequestDetails = "I need a laptop for my class", Duration = 7 },
                
                new EquipmentRequest { Id = 2, Name = "Joe Doe", Email = "JoeDoe@gmail.com",
                    PhoneNumber = "123-456-7890", Role = UserRole.Professor, 
                    EquipmentType = EquipmentType.Tablet, RequestDetails = "I need a Tablet for my Students", Duration = 31 },

            }; 
        }
        public void printRlist() {
            Console.WriteLine("Current Equipment Requests:");
            foreach (var request in _equipmentRequest)
            {
                Console.WriteLine($"ID: {request.Id}, Name: {request.Name}, Email: {request.Email}, " +
                                  $"Phone: {request.PhoneNumber}, Role: {request.Role}, " +
                                  $"Equipment: {request.EquipmentType}, Details: {request.RequestDetails}, " +
                                  $"Duration: {request.Duration}");
            }

        }

        public IActionResult RequestForm()
        {
            return View();
        }

        public IActionResult Requests()
        {   
            Console.WriteLine("--- Admin Page ---");
            printRlist();

            return View(_equipmentRequest);
        }

    }
}
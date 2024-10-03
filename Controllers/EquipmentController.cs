using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BorrowEquip.Models; 


namespace BorrowEquip.Controllers
{
    public class EquipmentController : Controller {
        private List<Equipment> _equipmentList;
        
        public EquipmentController()
        {
            _equipmentList = new List<Equipment> {
                new Equipment { Id = 1, Type = EquipmentType.Laptop, Description = "Dell XPS 13", IsAvailable = true },
                new Equipment { Id = 2, Type = EquipmentType.Phone, Description = "iPhone 13", IsAvailable = false },
                new Equipment { Id = 3, Type = EquipmentType.Tablet, Description = "iPad Pro", IsAvailable = true },
                new Equipment { Id = 4, Type = EquipmentType.Other, Description = "Projector", IsAvailable = true }
            };
        }

        public IActionResult AvailableEquipment() {
            return View(_equipmentList);
        }

        public IActionResult AllEquipment() {
            return View(_equipmentList);
        }
    
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BorrowEquip.Models
{

    public enum EquipmentType {
        Laptop,
        Phone,
        Tablet,
        Other
    }
    public enum UserRole {
        Student,
        Professor
    }

    public class EquipmentRequest {

        public int Id { get; set; }

        [Required (ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone, RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in the format xxx-xxx-xxxx")]
        public string PhoneNumber { get; set; }

        [Required (ErrorMessage = "Please select a Role")]
        [EnumDataType(typeof(UserRole), ErrorMessage = "Please select a valid Role")]
        public UserRole Role { get; set; }

        [Required (ErrorMessage = "Please select a equipment Type.")]
        [EnumDataType(typeof(EquipmentType), ErrorMessage = "Please select a valid Equipment Type")]
        public EquipmentType EquipmentType { get; set; }

        [Required]
        public string RequestDetails { get; set; }
        
        [Required, Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than zero")]
        public int Duration { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharjahMuseumTask.Core.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\+-]+(\\.[a-zA-Z0-9_\\+-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [AllowNull]
        public string? Photo { get; set; }
    }
}

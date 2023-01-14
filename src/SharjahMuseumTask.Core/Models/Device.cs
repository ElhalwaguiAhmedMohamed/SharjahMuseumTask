using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharjahMuseumTask.Core.Models
{
    public class Device
    {
        [Key]
        public int DevUid { get; set; }
        [Required, MaxLength(100)]
        public string DeviceType  { get; set; }
    }
}

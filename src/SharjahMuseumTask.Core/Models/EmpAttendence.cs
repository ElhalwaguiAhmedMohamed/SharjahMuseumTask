using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharjahMuseumTask.Core.Models
{
    public class EmpAttendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventLGUID { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime SRVDT { get; set; }
        [Required]
        public string DEVDT { get; set; }
        [ForeignKey("Device")]
        public int DevId { get; set; }
        [ForeignKey("Employee")]
        public int EmpId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Device Device { get; set; }
    }
}
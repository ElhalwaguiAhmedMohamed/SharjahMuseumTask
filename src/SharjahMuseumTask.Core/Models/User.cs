using System.ComponentModel.DataAnnotations;


namespace SharjahMuseumTask.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int RoleId  { get; set; }
        public string Photo { get; set; }
        public virtual Role Role { get; set; }
    }
}

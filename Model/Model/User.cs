using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    //Class ve propertyler oluşturularak Code First tekniği kullanıldı.
    public class User
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime LastLoginTime { get; set; }
        [Required]
        public int State { get; set; }
        [Required]
        public DateTime? LastUpdateTime { get; set; }
        [Required]
        public int RecordState { get; set; }
        public string HType { get; set; }
        
    }
}

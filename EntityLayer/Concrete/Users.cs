using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(100)]
        public string İsim{ get; set; }
        [StringLength(100)]
        public string Soyisim { get; set; }
        [StringLength(11)]
        public string TCKimlikNumarasi { get; set; }
        [StringLength(10)]
        public string OkulNumarasi { get; set; }
        [StringLength(10)]
        public string Sinif { get; set; }


        public ICollection<Users_Setler> Users_Setlers { get; set; }
    }
}

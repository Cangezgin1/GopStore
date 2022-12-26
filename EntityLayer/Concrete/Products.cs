using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Products
    {
        [Key]
        public int ÜrünID { get; set; }
        [StringLength(250)]
        public string ÜrünAdı { get; set; }
        public string ÜrünBilgisi { get; set; }
        public double Fiyat { get; set; }
        public string ÜrünImage { get; set; }
    }
}

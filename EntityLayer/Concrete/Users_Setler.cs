using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Users_Setler
    {
        [ForeignKey("Users")]
        public int UserID { get; set; }

        [ForeignKey("Setler")]
        public int SetID { get; set; }

        public Users Users { get; set; }
        public Setler Setler { get; set; }

    }
}

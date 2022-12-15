using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Students_Setler
    {
        [ForeignKey("Students")]
        public int StudentID { get; set; }

        [ForeignKey("Setler")]
        public int SetID { get; set; }

        public Students Students { get; set; }
        public Setler Setler { get; set; }

    }
}

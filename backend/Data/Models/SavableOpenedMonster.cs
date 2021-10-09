using Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SavableOpenedMonster : OpenedMonster
    {
        public bool Saved { get; set; } // onChange => false
    }
}

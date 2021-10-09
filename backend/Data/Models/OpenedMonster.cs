﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class OpenedMonster : FlatCreature
    {
        [Key]
        public int Id { get; set; }
        public int? SourceId { get; set; }
    }
}

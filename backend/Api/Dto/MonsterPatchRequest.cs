﻿using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dto
{
    public class MonsterPatchRequest : IMonsterPatchRequest
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}

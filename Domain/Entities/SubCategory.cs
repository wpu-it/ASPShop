﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubCategory : BaseEntity<int>
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

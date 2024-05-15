﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Persistence.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Story> Stories { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _IBS_VetPlus.Models
{
    public class PetViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }
    }
}
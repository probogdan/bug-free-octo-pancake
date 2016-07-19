using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _IBS_VetPlus.Models
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string[] Roles { get; set; }

        public byte[] ProfilePhoto { get; set; }

        public List<PetViewModel> Pets { get; set; }

        public List<OrderViewModel> OrderList { get; set; }

        public string ProfilePhotoMimeType { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }
    }
}
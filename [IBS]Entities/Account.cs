using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IBS_Entities
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string [] Roles { get; set; }

        public byte [] ProfilePhoto { get; set; }

        public List<Pet> Pets { get; set; }

        public List<Order> OrderList { get; set; }

        public string ProfilePhotoMimeType { get; set; }

        public DateTime DateOfBirth { get; set;  }

        public int Age { get; set; }

    }
}

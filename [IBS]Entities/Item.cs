using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IBS_Entities
{
    class Item
    {
        public Guid Id { get; set; }

        public int Price { get; set; }

        public byte [] ItemPhoto { get; set; }

        public string ItemPhotoMimeType { get; set; }
    }
}

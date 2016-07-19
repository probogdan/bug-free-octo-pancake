using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _IBS_VetPlus.Models
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }

        public int Price { get; set; }

        public byte[] ItemPhoto { get; set; }

        public string ItemPhotoMimeType { get; set; }
    }
}
using _IBS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IBS_InterfacesBLL
{
    public interface IInfoBLL
    {
        List<Post> GetNews();

        List<Account> GetTopSpecialists();


    }
}

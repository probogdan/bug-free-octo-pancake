using _IBS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IBS_InterfacesDAL
{
    public interface IInfoDAL
    {
        Order GetOrder(Guid orderId);

        List<Order> GetOrdersOfUser(Guid IdUser);

        Pet GetPet(Guid IdPet);

        List<Pet> GetPetsOfUser(Guid IdUser);
    }
}

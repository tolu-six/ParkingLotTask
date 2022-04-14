using System;
using System.Collections.Generic;
using UserPrivileges.Models;

namespace UserPrivileges.Repository.IRepository
{
    public interface IParkingManagerRepository
    {
        public int Solution(string E, string L);


        public List<PackingTickets> GetParkingTickets(string dateTime);

        //public List<PackingTickets> CreateParkingTicket(PackingTickets packingtickets);
    }
}

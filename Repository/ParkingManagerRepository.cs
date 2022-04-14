using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UserPrivileges.Data;
using UserPrivileges.Models;
using UserPrivileges.Models.DTOs;
using UserPrivileges.Repository.IRepository;

namespace UserPrivileges.Repository
{
    public class ParkingManagerRepository : IParkingManagerRepository
    {

        private decimal total_cost_of_the_parking_bill;

        private readonly ApplicationDbContext _db;

        

        public ParkingManagerRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public int Solution(string E, string L)
        {

            decimal EntraceFee = _db.PackingRules.Where(x => x.Id == 1).FirstOrDefault().Amount;
            decimal FirstHourFee = _db.PackingRules.Where(x => x.Id == 2).FirstOrDefault().Amount;
            decimal EveryHourAfterFirstFee = _db.PackingRules.Where(x => x.Id == 3).FirstOrDefault().Amount;


            var EntryTime = GetParkingTime(E);
            var ExitTime = GetParkingTime(L);

            decimal ETime = decimal.Parse(EntryTime, CultureInfo.InvariantCulture);
            decimal LTime = decimal.Parse(ExitTime, CultureInfo.InvariantCulture);

            decimal getTimespent = LTime - ETime;

            var dt = (int)Math.Ceiling(getTimespent);

            //Get the first hour
            if (getTimespent <= 1)
            {
                total_cost_of_the_parking_bill = EntraceFee + FirstHourFee;
            }

            if (getTimespent > 1)
            {
                total_cost_of_the_parking_bill = EntraceFee + FirstHourFee + ((dt - 1) * EveryHourAfterFirstFee);
            }

            this.CreateParkingTicket(E, L, (int)getTimespent, total_cost_of_the_parking_bill);

            return (int)total_cost_of_the_parking_bill;
        }


        private int CreateParkingTicket(string EntryTime, string ExitTime, int HoursSpent, decimal AmountToPay)
        {

            if (EntryTime == null || ExitTime == null)
            {
                throw new Exception("Request Data is Empty");
            }


            var createTicket = new PackingTickets
            {
                Name = "Ticket Name",
                EntryTime = EntryTime,
                ExitTime = ExitTime,
                HoursSpent = HoursSpent,
                AmountToPay = AmountToPay,
                Date =  DateTime.Now
            };

            _db.PackingTickets.Add(createTicket);
            return _db.SaveChanges();

        }

        public List<PackingTickets> GetParkingTickets(string dayDate)
        {
            return _db.PackingTickets.Where(x => x.Date.Date.ToString() == dayDate).ToList();
        }

        private string GetParkingTime(string time)
        {
            var now = DateTime.Parse(time);
            return string.Concat(now.Hour, ".", now.Minute);
        }
    }
}

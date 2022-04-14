﻿using System;
namespace UserPrivileges.Models
{
    public class PackingTickets
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EntryTime { get; set; }

        public string ExitTime { get; set; }

        public int HoursSpent { get; set; }

        public decimal AmountToPay { get; set; }

        public DateTime Date { get; set; }
    }
}

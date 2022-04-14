using System;
namespace UserPrivileges.Models
{
    public class PackingRule
    {
        public int Id { get; set; }

        public string RuleDescription { get; set; }

        public decimal Amount { get; set; }
    }
}

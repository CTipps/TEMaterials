using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulateDatabaseFromRescueGroupAPI.Models
{
    public class Agency
    {
        public int AgencyId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string About { get; set; }
        public string Url { get; set; }

        public Agency()
        {
            Street = "";
            City = "";
            State = "";
            PostalCode = "";
            Email = "";
            Phone = "";
            About = "";
            Url = "";
        }
        public override string ToString()
        {
            return $"AgencyId: {AgencyId}, Name: {Name}";
        }
    }
}

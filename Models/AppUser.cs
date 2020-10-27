using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
    }
}

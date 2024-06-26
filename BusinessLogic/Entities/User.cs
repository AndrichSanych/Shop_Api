﻿using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data.Entities
{
    public enum ClientType { None, Regular, Premium}
    public class User : IdentityUser
    {
        public DateTime Birthdate { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ClientType ClientType { get; set; }

    }
}

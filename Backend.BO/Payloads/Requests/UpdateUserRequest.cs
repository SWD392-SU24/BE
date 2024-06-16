﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BO.Payloads.Requests
{
    public class UpdateUserRequest
    {
        public required string FirstName { get; set; }

        public string? LastName { get; set; }

        public required string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Address { get; set; }

        public short Sex { get; set; }

        public required string Role { get; set; }
    }
}

﻿using System;
namespace CarManagementSystem.DTOs
{
    public class AuthResponseDTO
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public List<string> Roles { get; set; } // Add this line
    }
}


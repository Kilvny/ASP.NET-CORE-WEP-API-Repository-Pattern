﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static NKRY_API.Utilities.Constants;

namespace NKRY_API.Domain.Entities
{
    public class User
    {

        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage ="User Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "User Password is required")]
        public string? Password { get; set; }
        public UserRole Role { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt = DateTime.Now;
    }
}

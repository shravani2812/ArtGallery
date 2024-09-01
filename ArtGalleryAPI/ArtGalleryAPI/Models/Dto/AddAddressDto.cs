﻿using ArtGalleryAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGalleryAPI.Models.Dto
{
    public class AddAddressDto
    {
        [Required]
        [MaxLength(500, ErrorMessage = "Address line can have a maximum of 500 characters!")]
        public required string AddressLine { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "Address pin code can have a maximum of 12 characters!")]
        public required string PinCode { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "City in address can have a maximum of 100 characters!")]
        public required string City { get; set; }

        [MaxLength(100, ErrorMessage = "Landmark in address can have a maximum of 100 characters!")]
        public string? Landmark { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Country in address can have a maximum of 100 characters!")]
        public required string Country { get; set; }

        [Required]
        [MaxLength(6, ErrorMessage = "Country code in address can have a maximum of 6 characters!")]
        public required string CountryCode { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Phone number in address can have a maximum of 15 characters!")]
        public required string PhoneNumber { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email!")]
        public required string userEmail { get; set; }

    }
}

/*
 * Author: Johan Ahlqvist
 */

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTO
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace GringottsBankAPI2.DTO
{
    public class UserDTO
    {
        [Required]
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public decimal Balance { get; set; }
    }
}

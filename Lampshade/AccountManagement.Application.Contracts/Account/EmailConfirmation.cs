using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Account
{
    public class EmailConfirmation
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int Code { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace LawFirm.Application.Models.Authentication;

public class ChangePasswordRequest
{

    [Required]
    public string Id { get; set; }
    [Required]
    public string Password { get; set; }
}
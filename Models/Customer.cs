using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace crud_app.Models;

public class Customer
{
    public int Id { get; set; }
    [DisplayName("First name")]
    [Required, MaxLength(30), MinLength(3, ErrorMessage = "First name is too short")]
    public string? FirstName { get; set; }
    [DisplayName("Last name")]
    [Required, MaxLength(30), MinLength(3, ErrorMessage = "Last name is to short")]
    public string? LastName { get; set; }
    [DisplayName("E-mail")]
    [Required, MaxLength(30), MinLength(3)]
    public string? Email { get; set; }
}
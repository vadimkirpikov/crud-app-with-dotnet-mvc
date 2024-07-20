using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace crud_app.Models;

public class Editor
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string? Login { get; set; }
    [Required, MaxLength(100), PasswordPropertyText]
    public string? Password { get; set; }
}
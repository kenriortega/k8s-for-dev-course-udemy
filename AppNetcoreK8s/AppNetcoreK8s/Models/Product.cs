using System.ComponentModel.DataAnnotations;

namespace AppNetcoreK8s.Models;

public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name field is mandatory")]
    public string Name { get; set; } = string.Empty;
}
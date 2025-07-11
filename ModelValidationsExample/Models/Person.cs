using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models;

public class Person
{
    [Required]                   //Attribute used for validation can be used instead of IsNullorEmpty or any other method used for validation                                 
    public string? PersonName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public double? Price { get; set; }

    public override string ToString()
    {
        return $"Person Object- Person name: {PersonName}, Email: {Email}, Password: {Password}, ConfirmPassword: {ConfirmPassword}, Price: {Price}";
    }
}

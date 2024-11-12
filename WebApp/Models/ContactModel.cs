using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Musisz wpisac imię!")]
    [MaxLength(length: 20, ErrorMessage = "Imię nie może być dłuższe niż 20 znaków")]
    [MinLength(length: 2, ErrorMessage = "Imię musi miec co najmniej 2 znaki")]
    [Display(Name = "Imię", Order = 1)]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Musisz wpisac nazwisko!")]
    [MaxLength(length: 20, ErrorMessage = "Nazwisko nie może być dłuższe niż 20 znaków")]
    [MinLength(length: 2, ErrorMessage = "Nazwisko musi miec co najmniej 2 znaki")]
    [Display(Name = "Nazwisko", Order = 2)]
    public string LastName { get; set; }
    
    [EmailAddress]
    [Display(Name = "Adres e-mail", Order = 4)]
    public string Email { get; set; }
    
    [Phone]
    [Display(Name = "Telefon", Order = 3)]
    [RegularExpression(pattern:"\\d{3} \\d{3} \\d{3}", ErrorMessage = "Wpisz numer wedlug wzoru xxx xxx xxx")]
    public string PhoneNumber { get; set; }
    
    [DataType(DataType.Date)]
    [Display(Name = "Data urodzenia", Order = 5)]
    public DateOnly BirthDate { get; set; }
    [Display(Name = "Kategoria", Order = 6)]
    public Category Category { get; set; }
}
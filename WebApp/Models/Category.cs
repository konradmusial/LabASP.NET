using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public enum Category
{
    [Display(Name = "Rodzina", Order = 1)]
    Family,
    [Display(Name = "Znajomi", Order = 3)]
    Friend,
    [Display(Name = "Kontakt Zawodowy", Order = 2)]
    Business,
}
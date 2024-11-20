using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models;

[Table(name:"contacts")]
public class ContactEntity
{

    [HiddenInput]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(length: 20)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(length: 50)]
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    [Column(name:"phone")]
    public string PhoneNumber { get; set; }
    
    public DateOnly BirthDate { get; set; }
    
    [Display(Name = "Kategoria", Order = 6)]
    public Category Category { get; set; }

    public DateTime Created { get; set; }

    public int OrganizationId { get; set; }

    public OrganizationEntity? Organization { get; set; }
}

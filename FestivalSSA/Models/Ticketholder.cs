using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestivalSSA.Models
{
    public class Ticketholder
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "De naam is verplicht")]
        [Display(Name = "Naam")]
        [StringLength(50, ErrorMessage = "De naam mag maximaal 50 karakters bevatten")]
        public string Name { get; set; }

        [Required(ErrorMessage = "De voornaam is verplicht")]
        [Display(Name = "Voornaam")]
        [StringLength(50, ErrorMessage = "De voornaam mag maximaal 50 karakters bevatten")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Het emailadres is verplicht")]
        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "Het emailadres mag maximaal 50 karakters bevatten")]
        [EmailAddress(ErrorMessage = "Het emailadres is niet geldig")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Het aantal is verplicht")]
        [Display(Name = "Aantal")]
        [Range(1, 10, ErrorMessage = "Het aantal moet tussen 1 en 10 liggen")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Het type is verplicht")]
        public int TypeID { get; set; }

        public virtual Tickettype Type { get; set; }
    }
}
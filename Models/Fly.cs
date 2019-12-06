using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airways.Models
{
    public class Fly : IValidatableObject
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        [Display(Name = "Horaire")]
        public DateTime Time { get; set; }
        [Range(100, 300, ErrorMessage = "Le prix doit être compris entre 100 et 300")]
        [Display(Name = "Prix")]
        public int Price { get; set; }
        [Display(Name = "Réduction de 5% ?")]
        public bool Reduction { get; set; }
        [Range(0, 45, ErrorMessage = "Le nombre de places doit être inférieur à 45")]
        [Display(Name = "Place(s)")]
        public int Seat { get; set; }
        [Display(Name = "Départ")]
        public int Departure { get; set; }
        [Display(Name = "Arrivée")]
        public int Arrival { get; set; }
        [ForeignKey(nameof(Departure))]
        public City CityDeparture { get; set; }
        [ForeignKey(nameof(Arrival))]
        public City CityArrival { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Departure == Arrival )
            {
                yield return new ValidationResult(
                    $"Le départ et l'arrivée doivent être différents.",
                    new[] { nameof(Arrival) });
            }
        }
    }
}

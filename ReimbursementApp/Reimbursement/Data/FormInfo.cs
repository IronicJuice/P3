using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace Reimbursement.Data {
    public class FormInfo {
        [Required (ErrorMessage = "Navn skal udfyldes")]
        [RegularExpression(@"^[{\p{L}} ]+$", ErrorMessage = "Navn er ugyldigt.")]
        public string? Name { get; set; }

        [RegularExpression(@"^[0-9+-.() ]+$", ErrorMessage = "Telefonnummeret er ugyldigt.")]
        public string? Phone { get; set; }

        [Required (ErrorMessage = "Email skal udfyldes")]
        //Regex for emails is awful, perhaps consider alternatives? For reference: http://emailregex.com/
        public string? Email { get; set; }

        [Required (ErrorMessage = "Gruppe skal vælges")]
        public string? Group { get; set; }

        [Required (ErrorMessage = "Hvad pengene er brugt på skal udfyldes")]
        [RegularExpression(@"^[{\p{L}}0-9 ]+$", ErrorMessage = "Hvad pengene er brugt på er ugyldig.")] //Maybe more characters?
        public string? Purpose { get; set; }

        [RegularExpression(@"^[{\p{L}} ]+$", ErrorMessage = "Deltagere ved fortæring må ikke indeholde specielle tegn.")]
        public string? ConsumptionParty { get; set; }

        [Required (ErrorMessage = "Udgiftens størrelse skal udfyldes")]
        [RegularExpression(@"^[0-9,. ]+$", ErrorMessage = "Udgiftens størrelse må kun indeholde tal, punktummer og kommaer.")]
        public string? Amount { get; set; }

        [Required (ErrorMessage = "Kontant/bankoverførsel skal vælges")]
        public bool? Cash { get; set; }

        [Required (ErrorMessage = "Konto skal udfyldes")]
        public string? Account { get; set; }
    }
}

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

        [RegularExpression(@"^[{\p{L}}0-9 ]+$", ErrorMessage = "Deltagere ved fortæring må ikke indeholde specielle tegn.")]
        public string? ConsumptionParty { get; set; }

        [Required (ErrorMessage = "Udgiftens størrelse skal udfyldes")]
        [RegularExpression(@"^[0-9,. ]+$", ErrorMessage = "Udgiftens størrelse må kun indeholde tal, punktummer og kommaer.")]
        public string? Amount { get; set; }

        [Required (ErrorMessage = "Kontant/bankoverførsel skal vælges")]
        public bool? Cash { get; set; }

        [Required (ErrorMessage = "Konto skal udfyldes")]
        [RegularExpression(@"^[\p{L}0-9 ]+: ([0-9]+)$", ErrorMessage = "Den indtastede konto er ugyldig")]
        public string? Account { get; set; }

        [Required (ErrorMessage = "Registreringsnummer skal udfyldes")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Registreringsnummer må kun indeholde tal")]
        public string? RegNr { get; set; }

        [Required (ErrorMessage = "Kontonummer skal udfyldes")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Kontonummer må kun indeholde tal")]
        public string? AccountNumber { get; set; }

        public void PopulateTextFields(FormInfo formInfo) {
            formInfo.Name = "John Doe";
            formInfo.Phone = "112";
            formInfo.Email = "JohnDoe@gmail.com";
        }
        
        public List<string> accountList = new List<string>();
        public void PopulateACcounts() {
            accountList.Add("Et navn: 1255033");
            accountList.Add("To navn: 4520513");
            accountList.Add("Tre navn: 6412233");
        }

        public List<string> testList = new List<string>();
        public void PopulateGroups() {
            testList.Add("Test");
            testList.Add("Test2");
            testList.Add("Test3");
        }
    }
}

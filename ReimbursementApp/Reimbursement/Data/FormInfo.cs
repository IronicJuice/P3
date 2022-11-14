using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Reimbursement.Data {
    public class FormInfo {

        [Required (ErrorMessage = "Navn skal udfyldes")]
        [RegularExpression(@"^[\p{L} ]+$", ErrorMessage = "Navn er ugyldigt.")]
        public string? Name { get; set; }

        [RegularExpression(@"^[0-9+-.() ]+$", ErrorMessage = "Telefonnummeret er ugyldigt.")]
        public string? Phone { get; set; }

        [Required (ErrorMessage = "Email skal udfyldes")]
        [RegularExpression(@"^.+@.+\.+.+$", ErrorMessage = "Den indtastede email er ugyldig")]
        public string? Email { get; set; }

        [Required (ErrorMessage = "Gruppe skal vælges")]
        public string? Group { get; set; }

        [Required (ErrorMessage = "Hvad pengene er brugt på skal udfyldes")]
        [RegularExpression(@"^[\p{L}0-9 ]+$", ErrorMessage = "Hvad pengene er brugt på er ugyldig.")] //Maybe more characters?
        public string? Purpose { get; set; }

        [RegularExpression(@"^[\p{L}0-9,.\n() ]+$", ErrorMessage = "Deltagere ved fortæring må ikke indeholde specielle tegn.")]
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

        public class AccountClass {
            public class InternalGroup
            {
                public string? Name { get; set; }
                public string[]? Accounts { get; set; }
            }
            public IList<InternalGroup>? Group { get; set; }
        }
        
        public List<string> accountList = new List<string>();
        public void PopulateAccounts() {
            string path = Directory.GetCurrentDirectory();
            string jsonString = File.ReadAllText(path + "/Data/accounts.json");
            Console.WriteLine(jsonString);
            AccountClass? testClass = JsonSerializer.Deserialize<AccountClass>(jsonString);
            /*Console.WriteLine($"{testClass?.Group[0].Name}: {testClass?.Group[0].Accounts[0]}");*/
            for (int i = 0; i < testClass.Group.Count; i++) {
                for (int j = 0; j < testClass.Group[i].Accounts.Length; j++)
                {
                    accountList.Add(testClass.Group[i].Accounts[j]);
                    Console.WriteLine(testClass.Group[i].Accounts[j]);
                }
            }
            
        }

        public List<string> testList = new List<string>();
        public void PopulateGroups() {
            testList.Add("Test");
            testList.Add("Test2");
            testList.Add("Test3");
        }
    }
}

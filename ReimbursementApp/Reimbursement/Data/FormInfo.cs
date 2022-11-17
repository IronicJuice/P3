using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Reimbursement.Data
{
    public class FormInfo
    {
        //The following variables are linked to each field in the form from Form.razor
        [Required(ErrorMessage = "Navn skal udfyldes")]
        [RegularExpression(@"^[\p{L} ]+$", ErrorMessage = "Navn er ugyldigt.")]
        public string? Name { get; set; }

        [RegularExpression(@"^[0-9+-.() ]+$", ErrorMessage = "Telefonnummeret er ugyldigt.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Email skal udfyldes")]
        [RegularExpression(@"^.+@.+\.+.+$", ErrorMessage = "Den indtastede email er ugyldig")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Gruppe skal vælges")]
        public string? GroupStr { get; set; }

        [Required(ErrorMessage = "Hvad pengene er brugt på skal udfyldes")]
        [RegularExpression(@"^[\p{L}0-9 ,.!@;:()[]]+$", ErrorMessage = "Hvad pengene er brugt på er ugyldig.")] //Maybe more characters?
        public string? Purpose { get; set; }

        [RegularExpression(@"^[\p{L}0-9,.\n() ]+$", ErrorMessage = "Deltagere ved fortæring må ikke indeholde specielle tegn.")]
        public string? ConsumptionParty { get; set; }

        [Required(ErrorMessage = "Udgiftens størrelse skal udfyldes")]
        [RegularExpression(@"^[0-9,. ]+$", ErrorMessage = "Udgiftens størrelse må kun indeholde tal, punktummer og kommaer.")]
        public string? Amount { get; set; }

        [Required(ErrorMessage = "Kontant/bankoverførsel skal vælges")]
        public bool? Cash { get; set; }

        [Required(ErrorMessage = "Konto skal udfyldes")]
        [RegularExpression(@"^[\p{L}0-9]+: ([0-9 -]+)+$", ErrorMessage = "Den indtastede konto er ugyldig")]
        public string? Account { get; set; }

        [Required(ErrorMessage = "Registreringsnummer skal udfyldes")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Registreringsnummer må kun indeholde tal")]
        public string? RegNr { get; set; }

        [Required(ErrorMessage = "Kontonummer skal udfyldes")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Kontonummer må kun indeholde tal")]
        public string? AccountNumber { get; set; }


        public void PopulateTextFields(FormInfo formInfo) //Autofill fields from data recieved from login
        {
            formInfo.Name = "John Doe";
            formInfo.Phone = "112";
            formInfo.Email = "JohnDoe@gmail.com";
        }

        public class AccountClass //This class is used to store the information from accounts.json
        {
            public class InternalGroup
            {
                public string? Name { get; set; }
                public string[]? Accounts { get; set; }
            }
            public IList<InternalGroup>? GroupList { get; set; }
        }

        public List<string> accountList = new List<string>(); //The list of accounts relevant to the chosen group
        public void PopulateAccounts() //Reads the group field and populates the account field with related accounts
        {
            accountList.Clear();
            //Read the JSON file containing the account information and save as string
            string path = Directory.GetCurrentDirectory();
            string jsonString = File.ReadAllText(path + "/Data/accounts.json");
            if (jsonString is null)
            {
                throw new Exception("JsonString is null");
            }
            else
            {
                AccountClass Account = JsonSerializer.Deserialize<AccountClass>(jsonString); //The JSON string is saved as an AccountClass object

                if (Account is not null)
                {
                    for (int i = 0; i < Account.GroupList.Count; i++) //Search through each group to add relevant accounts to accountList[]
                    {
                        if (Account.GroupList[i].Name == GroupStr)
                        {
                            for (int j = 0; j < Account.GroupList[i].Accounts.Length; j++)
                            {
                                accountList.Add(Account.GroupList[i].Accounts[j]);
                                Console.WriteLine(Account.GroupList[i].Accounts[j]);
                            }
                            break; //Stop looking through groups when the correct group has been found, and all accounts have been added
                        }
                    }
                }
                else
                {
                    throw new Exception("Account is null");
                }
            }

        }



        public List<string> GroupList = new List<string>();
        public void PopulateGroups()
        {
            GroupList.Add("EDB");
            GroupList.Add("Silly");
            GroupList.Add("Test3");
        }
    }
}

//https://www.e-iceblue.com/Tutorials/Spire.PDF/Spire.PDF-Program-Guide/C-/VB.NET-Create-FormField-in-PDF.html
using Microsoft.EntityFrameworkCore.Metadata;
using Spire;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;
using Reimbursement.Data;

namespace Reimbursement.PdfData
{
    public class PDF
    {
        public string PersonsName { get; set; }

        public void GenPdf(FormInfo userInput, bool isRedacted)
        {
            //Create Pdf object
            PdfDocument doc = new PdfDocument();

            //Direct to the approciate directory
            string path = Directory.GetCurrentDirectory();
            doc.LoadFromFile(@path + "/PdfData/PdfForm.pdf");

            PdfFormWidget form = (PdfFormWidget)doc.Form;

            PdfFormFieldWidgetCollection FormWidgetCollection = form.FieldsWidget;

            string[] splitAccount = userInput.Account.Split(": ");

            bool? invertedCash = !userInput.Cash;

            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string[] splitDate = date.Split("-");

            //Adds every field from the form to a dictionary
            IDictionary<int, string?> userInputDictionary = new Dictionary<int, string>();
            userInputDictionary.Add(0, userInput.Name);
            userInputDictionary.Add(1, userInput.Phone);
            userInputDictionary.Add(2, userInput.Email);
            userInputDictionary.Add(3, userInput.GroupStr);
            userInputDictionary.Add(4, userInput.Purpose);
            userInputDictionary.Add(5, userInput.ConsumptionParty);
            userInputDictionary.Add(6, userInput.Amount);
            userInputDictionary.Add(7, splitAccount[0]);
            userInputDictionary.Add(8, splitAccount[1]);
            userInputDictionary.Add(9, userInput.RegNr);
            userInputDictionary.Add(10, userInput.AccountNumber);
            userInputDictionary.Add(11, userInput.Cash.ToString());
            userInputDictionary.Add(12, invertedCash.ToString());
            userInputDictionary.Add(13, splitDate[0]);
            userInputDictionary.Add(14, splitDate[1]);
            userInputDictionary.Add(15, splitDate[2]);

            for (int i = 0; i < FormWidgetCollection.Count; i++) {
                PdfField field = FormWidgetCollection[i];
                if (field is PdfCheckBoxWidgetFieldWidget) {
                    PdfCheckBoxWidgetFieldWidget checkBox = (PdfCheckBoxWidgetFieldWidget)FormWidgetCollection[i];
                    bool boolValue = bool.Parse(userInputDictionary[i]);
                    checkBox.Checked = boolValue;
                }
                else {
                    PdfTextBoxFieldWidget textBox = (PdfTextBoxFieldWidget)FormWidgetCollection[i];
                    if (userInputDictionary[i] == null) {
                        textBox.Text = "";
                    }
                    else if (i == 9 && isRedacted) {
                        textBox.Text = "";
                    }
                    else if (i == 10 && isRedacted)
                    {
                        textBox.Text = "";
                    }
                    else {
                        textBox.Text = userInputDictionary[i];
                    }
                }
            }
            PersonsName = userInput.Name;
            if (isRedacted)
            {
                doc.SaveToFile($"PdfData/GeneratedPdf/{PersonsName} - Redacted.pdf", FileFormat.PDF);
            }
            else
            {
                doc.SaveToFile($"PdfData/GeneratedPdf/{PersonsName}.pdf", FileFormat.PDF);
            }
            Task.Factory.StartNew(() => {
            Thread.Sleep(60000);
            File.Delete($"PdfData/GeneratedPdf/{PersonsName}.pdf");
            File.Delete($"PdfData/GeneratedPdf/{PersonsName} - Redacted.pdf");
            });
        }
    }
}

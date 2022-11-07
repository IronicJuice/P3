//https://www.e-iceblue.com/Tutorials/Spire.PDF/Spire.PDF-Program-Guide/C-/VB.NET-Create-FormField-in-PDF.html
using Spire;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;
using Reimbursement.Data;

namespace Reimbursement.PdfData
{
    public class PDF
    {
        public void GenPdf(FormInfo userInput)
        {
            //Create Pdf object
            PdfDocument doc = new PdfDocument();

            //Dirrect to the approciate directory
            string path = Directory.GetCurrentDirectory();
            doc.LoadFromFile(@path + "/PdfData/PdfForm.pdf");


            PdfFormWidget form = (PdfFormWidget)doc.Form;

            PdfFormFieldWidgetCollection FormWidgetCollection = form.FieldsWidget;

            for (int i = 0; i < FormWidgetCollection.Count; i++)
            {
                PdfField field = FormWidgetCollection[i];

                if (field is PdfTextBoxFieldWidget)
                {
                    if (field.Name == "Name")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = userInput.Name;
                    }
                    if (field.Name == "TelefonNumber")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = userInput.Phone;
                    }
                    if (field.Name == "Email")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = userInput.Email;
                    }
                    if (field.Name == "Group")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = userInput.Group;
                    }
                    if (field.Name == "MoneyUsagePurpose")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = userInput.Purpose;
                    }
                    if (field.Name == "ConsumptionParticipats")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = userInput.ConsumptionParty;
                    }
                    if (field.Name == "ExpenseAmount")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = userInput.Amount;
                    }
                    if (field.Name == "PostingAccuntName")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "PlaceHolder";
                    }
                    if (field.Name == "PostingAccuntNumber")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "PlaceHolder";
                    }
                    if (field.Name == "TransferRegNumber")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "PlaceHolder";
                    }
                    if (field.Name == "AccountNumber")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "PlaceHolder";
                    }
                    if (field.Name == "Day")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "PH";
                    }
                    if (field.Name == "Month")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "PH";
                    }
                    if (field.Name == "Year")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "PH";
                    }

                }
                if (field is PdfCheckBoxWidgetFieldWidget)
                {
                    PdfCheckBoxWidgetFieldWidget checkBoxField = (PdfCheckBoxWidgetFieldWidget)field;
                    switch (checkBoxField.Name)
                    {
                        case "PayoutCash":
                            checkBoxField.Checked = true;
                            break;
                        case "PayoutTransfer":
                            checkBoxField.Checked = false;
                            break;
                    }
                }

            }
            string PersonsName = userInput.Name;
            doc.SaveToFile($"PdfData/{PersonsName}.pdf", FileFormat.PDF);
        }
    }
}

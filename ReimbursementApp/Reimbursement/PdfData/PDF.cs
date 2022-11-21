//https://www.e-iceblue.com/Tutorials/Spire.PDF/Spire.PDF-Program-Guide/C-/VB.NET-Create-FormField-in-PDF.html
using Microsoft.EntityFrameworkCore.Metadata;
using Spire;
using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;

namespace Reimbursement.PdfData
{
    public class PDF
    {
        public void GenPdf()
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
                        textBoxField.Text = "peter Weihe Magnussen";
                    }
                    if (field.Name == "TelefonNumber")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "23366707";
                    }
                    if (field.Name == "Email")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "pmtv@student.aau.dk";
                    }
                    if (field.Name == "Group")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "F-klubben";
                    }
                    if (field.Name == "MoneyUsagePurpose")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "spise ude";
                    }
                    if (field.Name == "ConsumptionParticipats")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "Markus, zoey, rasmus, christian";
                    }
                    if (field.Name == "ExpenseAmount")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "649";
                    }
                    if (field.Name == "PostingAccuntName")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "spise";
                    }
                    if (field.Name == "PostingAccuntNumber")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "91810005784";
                    }
                    if (field.Name == "TransferRegNumber")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "9181";
                    }
                    if (field.Name == "AccountNumber")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "00036784926";
                    }
                    if (field.Name == "Day")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "02";
                    }
                    if (field.Name == "Month")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "10";
                    }
                    if (field.Name == "Year")
                    {
                        PdfTextBoxFieldWidget textBoxField = (PdfTextBoxFieldWidget)field;
                        textBoxField.Text = "2022";
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
            string PersonsName = "PeterWeihe";
            doc.SaveToFile($"PdfData/{PersonsName}.pdf", FileFormat.PDF);
        }
    }
}

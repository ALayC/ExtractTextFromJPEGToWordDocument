using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class PDFService
{
    public void CreatePdfWithText(string text, string outputPath)
    {
        Document document = new Document();
        PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));
        document.Open();
        document.Add(new Paragraph(text));
        document.Close();
    }
}

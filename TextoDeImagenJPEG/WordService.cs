using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

public class WordService
{
    public void AddTextToWordDocument(string text, string outputPath)
    {
        // Abrir el documento existente, o crear uno nuevo si no existe
        if (File.Exists(outputPath))
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(outputPath, true))
            {
                AddTextToBody(wordDocument, text);
            }
        }
        else
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(outputPath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document(new Body());
                AddTextToBody(wordDocument, text);
            }
        }
    }

    private void AddTextToBody(WordprocessingDocument doc, string text)
    {
        Body body = doc.MainDocumentPart.Document.Body;
        body.AppendChild(new Paragraph(new Run(new Text(text))));
        body.AppendChild(new Paragraph(new Run(new Break()))); // Agrega un salto de línea después de cada texto
        doc.MainDocumentPart.Document.Save();
    }

}

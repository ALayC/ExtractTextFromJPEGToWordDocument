using System;
using System.Drawing;
using System.IO;
using System.Reflection.Metadata;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Tesseract;

namespace TextoDeImagenJPEG
{
    class Program
    {
        static void Main(string[] args)
        {
            var ocrService = new OCRService();
            var wordService = new WordService(); // Cambiado de PDFService a WordService

            string imagesFolderPath = @"C:\Users\alay\Desktop\General\FreeLance\Traducciones\THe History of Animals\history-of-animals";
            string outputPath = @"C:\Users\alay\Desktop\General\FreeLance\Traducciones\THe History of Animals\Transleted - history of animals\TheHistoryOfAnimalesTranslated.docx";

            string[] imageFiles = Directory.GetFiles(imagesFolderPath, "*.jpeg");
            foreach (var imageFile in imageFiles)
            {
                string extractedText = ocrService.ExtractTextFromImage(imageFile);
                wordService.AddTextToWordDocument(extractedText, outputPath); // Usar el nuevo método
            }

        }
    }
}
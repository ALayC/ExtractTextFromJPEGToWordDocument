using Tesseract;
using System.IO;

public class OCRService
{
    public string ExtractTextFromImage(string imagePath)
    {
        
        using var engine = new TesseractEngine(@"C:\Users\alay\source\repos\TextoDeImagenJPEG\tessdata", "eng", EngineMode.Default);

        using var img = Pix.LoadFromFile(imagePath);
        using var page = engine.Process(img);
        return page.GetText();
    }
}

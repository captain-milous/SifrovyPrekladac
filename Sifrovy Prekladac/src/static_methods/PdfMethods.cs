using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Sifrovy_Prekladac.src.conf;
using Sifrovy_Prekladac.src.logs;

namespace Sifrovy_Prekladac.src.static_methods
{
    /// <summary>
    /// Třída obsahující metody pro zápis textových dat do PDF souborů.
    /// </summary>
    public static class PdfMethods
    {
        /// <summary>
        /// Zapíše zadaný text do PDF souboru.
        /// </summary>
        /// <param name="fileName">Název souboru, do kterého se má zapisovat text.</param>
        /// <param name="text">Text, který se má zapsat do souboru.</param>
        /// <exception cref="Exception">Výjimka, která může být vyvolána při chybě při zápisu do souboru.</exception>
        public static void SaveToPDF(string fileName, string text)
        {
            try
            {
                if (!fileName.EndsWith(".pdf"))
                {
                    fileName += ".pdf";
                }

                string filePath = ConfigHandler.Config.OutputFile + "\\" + fileName;
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();
                document.Add(new Paragraph(text));
                document.Close();
            }
            catch (Exception ex) 
            {
                LogHandler.Write($"Chyba při zápisu do souboru: {ex.Message}");
                throw new Exception($"Chyba při zápisu do souboru: {ex.Message}");
            }        
        }
    }
}

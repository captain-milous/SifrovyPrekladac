using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sifrovy_Prekladac.src.conf
{
    /// <summary>
    /// Statická třída obsahující metody pro načítání konfigurace z XML souboru do objektu třídy Config.
    /// </summary>
    public static class ConfigLoader
    {
        /// <summary>
        /// Výchozí cesta k XML souboru s konfigurací.
        /// </summary>
        private static string filePath = "config.xml";

        /// <summary>
        /// Načte konfiguraci z XML souboru a vrátí ji jako objekt třídy Config.
        /// </summary>
        /// <returns>Objekt třídy Config obsahující načtenou konfiguraci.</returns>
        public static Config Load()
        {
            Config newConfig = new Config();
            try
            {
                XDocument doc = XDocument.Load(filePath);
                newConfig.LogFilePath = GetValueFromXml(doc, "LogFilePath");
                newConfig.ListOfUsersFilePath = GetValueFromXml(doc, "ListOfUsersFilePath");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při načítání konfigurace: {ex.Message}");
                Environment.Exit(0);
            }
            return newConfig;
        }

        /// <summary>
        /// Získá hodnotu elementu z XML dokumentu.
        /// </summary>
        /// <param name="doc">XML dokument.</param>
        /// <param name="elementName">Název hledaného elementu.</param>
        /// <returns>Hodnota elementu nebo prázdný řetězec, pokud není nalezen.</returns>
        private static string GetValueFromXml(XDocument doc, string elementName)
        {
            XElement element = doc.Element("Configuration")?.Element(elementName);
            return element?.Value ?? string.Empty;
        }
    }
}

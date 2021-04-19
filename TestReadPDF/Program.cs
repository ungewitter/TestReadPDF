using System;
using System.Collections.Generic;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace TestReadPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdfLink;
            string rakning = "Kan inte hämtas." ; 
            string betalaSenast = "Kan inte hämtas.";
            string bankgiro = "Kan inte hämtas.";
            string OCR = "Kan inte hämtas.";
            List<string> listOfWords = new List<string>();

            Console.WriteLine("Hej! Skriv in sökväg till PDF-fakturan.");

            pdfLink = Console.ReadLine();

            using (PdfDocument document = PdfDocument.Open(@""+pdfLink))
                foreach (Page page in document.GetPages())
                {
                    string pageText = page.Text;

                    foreach (Word word in page.GetWords())
                    {
                        listOfWords.Add(word.Text);
                    }
                }
            
            foreach (string word in listOfWords)
            {
                if (word == "betala:")
                {
                    rakning = listOfWords[listOfWords.IndexOf(word) + 1];
                }
                if (word == "senast:")
                {
                    betalaSenast = listOfWords[listOfWords.IndexOf(word) + 1];
                }
                if (word == "Bankgiro:")
                {
                    bankgiro = listOfWords[listOfWords.IndexOf(word) + 1];
                }
                if (word == "OCR-nummer:")
                {
                    OCR = listOfWords[listOfWords.IndexOf(word) + 1];
                }
            }

            Console.WriteLine("Att betala: " + rakning);
            Console.WriteLine("Betala senast: " + betalaSenast);
            Console.WriteLine("Bankgiro: " + bankgiro);
            Console.WriteLine("OCR-nummer: " + OCR);
        }
    }
}

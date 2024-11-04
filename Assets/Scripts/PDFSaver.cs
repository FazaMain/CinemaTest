using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class PDFSaver : MonoBehaviour
{
    int Number;
    public void CreatePDF(string s)
    {
        Number += 1;
        string parentPath = Directory.GetParent(Application.persistentDataPath).FullName;
        string path = Path.Combine(parentPath, "PriceSummary" + Number + ".pdf");
        Debug.Log("—охран€ю PDF в " + path);
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            Document pdfDoc = new Document();
            PdfWriter.GetInstance(pdfDoc, stream);
            pdfDoc.Open();
            pdfDoc.Add(new Paragraph(s));
            pdfDoc.Close();
        }
    }
}

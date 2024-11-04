using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class PriceManager : MonoBehaviour
{
    int TotalPrice;
    public int[] CategoriesPriceArray;
    public string[] CategoryString;
    public TextMeshProUGUI[] CategoryText;
    public TextMeshProUGUI TotalPriceText;

    [Header("Ссылки")]
    public PDFSaver PDF;

    [Header("Текстовка")]
    //Сборка для сохранения в pdf
    public string[] CompleteCategoryStrings;
    [SerializeField]
    private string SummaryString;

    private void OnEnable()
    {
        CategoryScript.CategoryPriceChange += CategoryPriceChange;
        TotalPriceCount();
    }
    private void OnDisable()
    {
        CategoryScript.CategoryPriceChange -= CategoryPriceChange;
    }
    void CategoryPriceChange(int Category, int Amount)
    {
        CategoriesPriceArray[Category] = Amount;
        CategoryText[Category].text = CategoryString[Category] + ": " + Amount + " USD";
        if(Amount > 0)
        {
            CompleteCategoryStrings[Category] = CategoryText[Category].text;
        }
        else
        {
            CompleteCategoryStrings[Category] = CategoryString[Category] + " None";
        }  
        TotalPriceCount();
    }

    void TotalPriceCount()
    {
        TotalPrice = 0;
        for(int i = 0; i < CategoriesPriceArray.Length; i++)
        {
            TotalPrice += CategoriesPriceArray[i];
        }
        TotalPriceText.text = "Total: " + TotalPrice + " USD";
        PriceSummary();
    }
    void PriceSummary()
    {
        SummaryString = "";
        for(int i = 0; i < CompleteCategoryStrings.Length; i++)
        {
            SummaryString += CompleteCategoryStrings[i] + "\n";
        }
        SummaryString += TotalPriceText.text;
    }
    public void SaveToPDF()
    {
        PDF.CreatePDF(SummaryString);
    }



}

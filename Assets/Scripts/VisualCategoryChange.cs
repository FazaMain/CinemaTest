using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCategoryChange : MonoBehaviour
{
    public GameObject[] ObjectsArray;

    public int CategoryInt;
    private void OnEnable()
    {
        CategoryScript.CategoryVisualChange += Change;
    }
    private void OnDisable()
    {
        CategoryScript.CategoryVisualChange -= Change;
    }
    private void Change(int Category, int Type)
    {
        if (Category == CategoryInt)
        {
            foreach (GameObject obj in ObjectsArray)
            {
                obj.SetActive(false);
            }
            ObjectsArray[Type].SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CategoryScript : MonoBehaviour
{
    public static event Action<int,int> CategoryPriceChange;
    public static event Action<int, int> CategoryVisualChange;
    public int Category;
    public int[] ItemPrice;
    int ItemType;
    public void PriceUpdate(int i)
    {
        CategoryPriceChange?.Invoke(Category, ItemPrice[i]);
        CategoryVisualChange?.Invoke(Category, i);
    }
}

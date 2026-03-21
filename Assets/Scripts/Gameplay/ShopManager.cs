using Nithin.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static event Action<int> OnAmountUpdated;
    [SerializeField] private int _currentAmount;

    public bool TryPurchase(ShopItem shopItem)
    {
        if(_currentAmount > shopItem.price)
        {
            _currentAmount -= shopItem.price;
            DeliverItem();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DeliverItem()
    {
        Debug.Log("item purchase successful");
        OnAmountUpdated?.Invoke(_currentAmount);
    }
}

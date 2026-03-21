using Nithin.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopSlotUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Image _itemImage;

    private ShopManager _shopManager;
    private ShopItem _item;

    public void Setup(ShopItem shopItemValues, ShopManager shopManager)
    {
        _shopManager = shopManager;
        _item = shopItemValues;
        _priceText.text = shopItemValues.price.ToString();
        _itemImage.sprite = shopItemValues.icon;
    }

    public void OnBuyClicked()
    {
        _shopManager.TryPurchase(_item);
    }
}

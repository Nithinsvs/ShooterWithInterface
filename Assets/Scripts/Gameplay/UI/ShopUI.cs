using Nithin.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private ShopManager _shopManager;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Transform _scrollView;

    [SerializeField] private List<ShopItem> _items;
    [SerializeField] private List<ShopSlotUI> _shopItems;

    [SerializeField] private Text _currentAmount;

    // Start is called before the first frame update
    void Start()
    {
        PopulateItemsIntoUIPanel();
    }

    private void PopulateItemsIntoUIPanel()
    {
        foreach (ShopItem item in _items)
        {
            GameObject go = Instantiate(_itemPrefab, _scrollView);
            if (go.TryGetComponent(out ShopSlotUI shopItemData))
            {
                shopItemData.Setup(item, _shopManager);
            }
        }
    }

    private void OnEnable()
    {
        ShopManager.OnAmountUpdated += ShowAmount;
    }

    private void OnDisable()
    {
        ShopManager.OnAmountUpdated -= ShowAmount;
    }

    private void ShowAmount(int value)
    {
        _currentAmount.text = value.ToString();
    }
}

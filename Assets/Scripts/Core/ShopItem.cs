using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nithin.Core
{
    [CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop/Item")]
    public class ShopItem : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
        public int price;
        public GameObject prefabToSpawn;
    }
}
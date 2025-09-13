using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductA : MonoBehaviour, ISharedFunctionality
{
    [SerializeField] private int healthValue;
    public int health { get => healthValue; set => healthValue = value; }

}

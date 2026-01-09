using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductA : MonoBehaviour, IHealth
{
    [SerializeField] private int healthValue;
    public int health { get => healthValue; set => healthValue = value; }

}

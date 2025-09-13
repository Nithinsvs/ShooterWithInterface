using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductB : MonoBehaviour, ISharedFunctionality
{
    [SerializeField] private int healthValue;
    public int health { get => healthValue; set => healthValue = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductASpawner : EnemySpawner
{
    public override ISharedFunctionality CreateEnemy()
    {
        return new ProductA();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductBSpawner : EnemySpawner
{
    public override ISharedFunctionality CreateEnemy()
    {
        return new ProductB();
    }
}

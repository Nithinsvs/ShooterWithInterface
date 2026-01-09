using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductBSpawner : EnemySpawner
{
    public override IHealth CreateEnemy()
    {
        return new ProductB();
    }
}

using Enemy;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : PoolingService<EnemyController>
{
    private EnemyView enemyPrefab;
    private EnemyModel enemyModel;

    public EnemyController GetEnemy(EnemyView enemyPrefab, EnemyModel enemyModel)
    {
        this.enemyPrefab = enemyPrefab;
        this.enemyModel = enemyModel;
        return GetItem();
    }
    protected override EnemyController CreateItem()
    {
        EnemyView enemyViewInstance = GameObject.Instantiate<EnemyView>(enemyPrefab);
        EnemyController enemyController = new EnemyController(enemyViewInstance, enemyModel, EnemyColor.GOLDEN);
        return enemyController;
    }
}

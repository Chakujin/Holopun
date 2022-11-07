using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawnedManager : MonoBehaviour
{
    private int totalEnemiesSpawned = 0;
    private int totalEnemiesKilled = 0;

    public void UpdateEnemiesKilled()
    {
        totalEnemiesKilled++;
        if (totalEnemiesKilled == totalEnemiesSpawned)
        {
            //Termina ronda endender boyon pata la sigueinte ronda
        }
    }

    public void UpdateEnemiesSpawned(int calledAddEnemeies)
    {
        totalEnemiesSpawned += calledAddEnemeies;
    }
}

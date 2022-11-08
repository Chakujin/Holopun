using UnityEngine;

public class EnemiesSpawnedManager : MonoBehaviour
{
    private int totalEnemiesSpawned = 0;
    private int totalEnemiesKilled = 0;

    [SerializeField] private CrossbowGameManager crossbowGameManager;
    public void UpdateEnemiesKilled()
    {
        totalEnemiesKilled++;
        if (totalEnemiesKilled == totalEnemiesSpawned)
        {
            crossbowGameManager.EndRoundCrossbowGame();
        }
    }

    public void UpdateEnemiesSpawned(int calledAddEnemeies)
    {
        totalEnemiesSpawned += calledAddEnemeies;
    }
}

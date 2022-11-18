using UnityEngine;

public class EnemiesSpawnedManager : MonoBehaviour
{
    [SerializeField] private int totalEnemiesSpawned = 0;
    [SerializeField] private int totalEnemiesKilled = 0;

    [SerializeField] private CrossbowGameManager crossbowGameManager;
    public void UpdateEnemiesKilled()
    {
        totalEnemiesKilled++;
        if (totalEnemiesKilled == totalEnemiesSpawned)
        {
            Debug.Log("End Round");
            crossbowGameManager.EndRoundCrossbowGame();
        }
    }

    public void UpdateEnemiesSpawned(int calledAddEnemeies)
    {
        totalEnemiesSpawned += calledAddEnemeies;
    }
}

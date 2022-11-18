using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private EnemiesSpawnedManager m_enemiesSpawnManager;

    [SerializeField] private int enemiesSpawn;

    // Start is called before the first frame update
    void Start()
    {
        CrossbowGameManager.StartGameCallback += StartSpawnEnemies;
        m_enemiesSpawnManager = GameObject.FindGameObjectWithTag("CrossbowGameManager").GetComponent<EnemiesSpawnedManager>();
        StartSpawnEnemies();
    }


    private void StartSpawnEnemies()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < enemiesSpawn; i++)
        {
            Instantiate(enemyPrefab, transform.localPosition, transform.localRotation);
            m_enemiesSpawnManager.UpdateEnemiesSpawned(enemiesSpawn); //Update total enemies have spawned
            yield return new WaitForSeconds(1f);
        }
    }


    public Color color = Color.red;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}

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
    }


    private void StartSpawnEnemies()
    {
        for (int i = 0; i < enemiesSpawn; i++)
        {
            int randomPosX = Random.Range(0,3);
            int randomPosY = Random.Range(0, 3);
            int randomPosZ = Random.Range(0, 3);

            Vector3 positionSpawn = new Vector3(transform.localPosition.x + randomPosX, transform.localPosition.y + randomPosY, transform.localPosition.z + randomPosZ);

            Instantiate(enemyPrefab,positionSpawn,transform.localRotation);
        }
        m_enemiesSpawnManager.UpdateEnemiesSpawned(enemiesSpawn); //Update total enemies have spawned
    }

    public Color color = Color.red;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}

using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    private SelectedPlayerManager m_selectedPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        m_selectedPlayer = GameObject.FindGameObjectWithTag("SelectedPlayer").GetComponent<SelectedPlayerManager>();
        InstantiatePlayer();
    }

    private void InstantiatePlayer()
    {
        Instantiate(m_selectedPlayer.playerSpawn, transform);
    }

    [SerializeField]private Color color = Color.blue;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}

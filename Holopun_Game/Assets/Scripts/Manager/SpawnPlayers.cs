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
        GameObject player = Instantiate(m_selectedPlayer.playerSpawn, transform);
        player.transform.parent = null;
    }

    [SerializeField]private Color color = Color.blue;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}

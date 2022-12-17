using UnityEngine;

public class PlayerCorsbowGame : MonoBehaviour
{
    public bool alive = true; // Used by enemy for track  the player
    public int totalKilled; //Used by countPoints manager

    [SerializeField] private int i_hp;
    private const int i_maxHp = 3;

    [SerializeField] private Collider[] controllersCol;
    private CrossbowGameManager m_crossbowGameManager;

    [SerializeField] private GameObject m_playerMesh;

    //Delegates
    public delegate void PlayerDie();
    public event PlayerDie PlayerDieCallback;

    // Start is called before the first frame update
    void Start()
    {
        CrossbowGameManager.FinishGameCallback += RevivePlayer; // Subscribe to finish game event
        m_crossbowGameManager = GameObject.FindGameObjectWithTag("CrossbowGameManager").GetComponent<CrossbowGameManager>();

        i_hp = i_maxHp;
    }
    
    public void TakeDamage(int dmg)
    {
        //Sound
        i_hp -= dmg;
        if (i_hp <= 0)
        {
            DiePlayer();
        }
    }

    private void DiePlayer()
    {
        if (PlayerDieCallback != null)
        {
            PlayerDieCallback.Invoke(); //Send call to enemyes for change the target follows
        }

        alive = false; //Used by enemy to find players alive

        m_playerMesh.SetActive(false); //Desactive mesh player
        
        foreach (Collider col in controllersCol) // Enable false grab colliders
        {
            col.enabled = false;
        }

        m_crossbowGameManager.UpdatePlayersDied(); //Send manager rest one player
    }

    private void RevivePlayer()//Event Delegate
    {
        Debug.Log("Revive Player");
        i_hp = i_maxHp;
        alive = true; //Used by enemy to find players alive
        m_playerMesh.SetActive(true);
        foreach (Collider col in controllersCol) // Enable true grab colliders
        {
            col.enabled = true;
        }
    }
}

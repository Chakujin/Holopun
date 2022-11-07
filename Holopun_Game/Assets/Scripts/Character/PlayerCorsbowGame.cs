using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCorsbowGame : MonoBehaviour
{
    public bool Alive = true;
    public int totalKilled;

    [SerializeField] private int i_hp;
    private int i_maxHp;

    [SerializeField] private Collider[] controllersCol;
    private CrossbowGameManager m_crossbowGameManager;

    [SerializeField] private GameObject m_playerMesh;

    // Start is called before the first frame update
    void Start()
    {
        CrossbowGameManager.FinishGameCallback += RevivePlayer; // Subscribe to finish game event
        m_crossbowGameManager = GameObject.FindGameObjectWithTag("CrossbowGameManager").GetComponent<CrossbowGameManager>();

        i_maxHp = i_hp;
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
        Alive = false;
        m_crossbowGameManager.UpdatePlayersAlive(); //Send manager rest one player
        m_playerMesh.SetActive(false);
        foreach (Collider col in controllersCol) // Enable false grab colliders
        {
            col.enabled = false;
        }
    }

    private void RevivePlayer()
    {
        i_hp = i_maxHp;
        m_playerMesh.SetActive(true);
        foreach (Collider col in controllersCol) // Enable true grab colliders
        {
            col.enabled = true;
        }
    }
}

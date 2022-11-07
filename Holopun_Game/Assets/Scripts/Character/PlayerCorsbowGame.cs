using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCorsbowGame : MonoBehaviour
{
    public bool Alive = true;
    [SerializeField] private int i_hp;

    [SerializeField] private Collider[] controllersCol;
    private CrossbowGameManager m_crossbowGameManager;
    // Start is called before the first frame update
    void Start()
    {
        CrossbowGameManager.FinishGameCallback += RevivePlayer; // Subscribe to finish game event
        m_crossbowGameManager = GameObject.FindGameObjectWithTag("CrossbowGameManager").GetComponent<CrossbowGameManager>();
    }
    
    public void TakeDamage(int dmg)
    {
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
        foreach (Collider col in controllersCol) // Enable false grab colliders
        {
            col.enabled = false;
        }
    }

    private void RevivePlayer()
    {
        foreach (Collider col in controllersCol) // Enable true grab colliders
        {
            col.enabled = true;
        }
    }
}

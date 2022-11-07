using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowGameManager : MonoBehaviour
{
    //Delegates
    public delegate void FinishGame();
    public static event FinishGame FinishGameCallback;

    public delegate void StartGame();
    public static event StartGame StartGameCallback;
    //

    //Players
    private List<GameObject> playersList = new List<GameObject>();
    private int i_playersTotal;

    //Rounds
    [SerializeField] private int i_MaxRounds;
    private int i_CurrentRound = 0;

    // Start is called before the first frame update
    void Start()
    {
        playersList.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        i_playersTotal = playersList.Count;
    }

    public void StartRoundCrossbowGame()
    {
        if (StartGameCallback != null)
        {
            i_CurrentRound++; //Update current round
            if (i_CurrentRound < i_MaxRounds)//If is not the last start round
            {
                StartGameCallback.Invoke();
            }
        }
    }

    public void UpdatePlayersAlive()
    {
        i_playersTotal--;
        if (i_playersTotal == 0)
        {
            GameFinish();
        }
    }

    private void GameFinish()
    {
        if (FinishGameCallback != null)
        {
            FinishGameCallback.Invoke();
        }
        i_playersTotal = playersList.Count;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowGameManager : MonoBehaviour
{
    public delegate void FinishGame();
    public static event FinishGame FinishGameCallback;

    private List<GameObject> playersList = new List<GameObject>();
    private int i_playersTotal;

    // Start is called before the first frame update
    void Start()
    {
        playersList.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        i_playersTotal = playersList.Count;
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

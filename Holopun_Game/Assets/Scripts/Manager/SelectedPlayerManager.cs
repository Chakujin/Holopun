using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectedPlayerManager : MonoBehaviour
{
    public static SelectedPlayerManager instance;
    private int levelLoad;
    public GameObject playerSpawn;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetLevel(int level)
    {
        levelLoad = level;
    }

    public void SetCharacter(GameObject player)
    {
        playerSpawn = player;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelLoad);
    }
}

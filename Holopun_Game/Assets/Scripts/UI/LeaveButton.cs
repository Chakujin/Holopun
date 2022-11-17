using UnityEngine.SceneManagement;
using UnityEngine;

public class LeaveButton : MonoBehaviour
{
    public void PressMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PressExit()
    {
        Application.Quit();
    }
}

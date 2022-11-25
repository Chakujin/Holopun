using UnityEngine;

public class PlungerGameReset : MonoBehaviour
{
    //Event
    public delegate void RestartGame();
    public static event RestartGame RestartGameCallback;

    public void PressRestart() //Called when press restart, send msg to targetCylinder
    {
        if (RestartGameCallback != null)
        {
            RestartGameCallback.Invoke();
        }
    }
}

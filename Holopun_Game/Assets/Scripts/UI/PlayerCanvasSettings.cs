using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCanvasSettings : MonoBehaviour
{
    [SerializeField] private GameObject m_settingsCanvas;
    [SerializeField] private GameObject m_faceCanvas;
    public void PressSettings()
    {
        m_settingsCanvas.SetActive(true);
        m_faceCanvas.SetActive(false);
    }
    public void PressFace()
    {
        m_settingsCanvas.SetActive(false);
        m_faceCanvas.SetActive(true);
    }

    public void PressQuit()
    {
        SceneManager.LoadScene(0);
    }
}

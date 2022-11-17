using UnityEngine;

public class PlayerCanvasSettings : MonoBehaviour
{
    [SerializeField] private GameObject m_settingsCanvas;
    [SerializeField] private GameObject m_faceCanvas;
    [SerializeField] private GameObject m_exitCanvas;
    public void PressSettings()
    {
        m_settingsCanvas.SetActive(true);
        m_faceCanvas.SetActive(false);
        m_exitCanvas.SetActive(false);
    }
    public void PressFace()
    {
        m_settingsCanvas.SetActive(false);
        m_exitCanvas.SetActive(false);
        m_faceCanvas.SetActive(true);
    }

    public void PressQuit()
    {
        m_settingsCanvas.SetActive(false);
        m_exitCanvas.SetActive(true);
        m_faceCanvas.SetActive(false);
    }
}

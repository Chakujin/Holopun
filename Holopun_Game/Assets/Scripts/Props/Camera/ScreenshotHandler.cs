using UnityEngine;

public class ScreenshotHandler : MonoBehaviour {

    [SerializeField] private Camera m_camera;
    [SerializeField] private AudioSource m_audioSnap;

    private int resWidth = 256;
    private int resHeight = 256;

    private void Awake()
    {
        if (m_camera.targetTexture == null)
        {
            m_camera.targetTexture = new RenderTexture(resWidth,resHeight,24);
        }
        else
        {
            resWidth = m_camera.targetTexture.width;
            resHeight = m_camera.targetTexture.height;
        }
    }

    public void TakePhoto()
    {
        //m_audioSnap.Play();

        Texture2D screenshotTexture = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        m_camera.Render();
        RenderTexture.active = m_camera.targetTexture;
        screenshotTexture.ReadPixels(new Rect(0,0,resWidth,resHeight), 0, 0);

        byte[] byteArray = screenshotTexture.EncodeToPNG();

        string fileName = SnapshotName();

        System.IO.File.WriteAllBytes(fileName, byteArray);
        //Debug.Log("Photo");
    }

    private string SnapshotName()
    {
        return string.Format("{0}/Snapshots/snap_{1}x{2}_{3}.png",
            Application.dataPath,
            resWidth,
            resHeight,
            System.DateTime.Now.ToString("yyyy-MM,dd_HH-mm-ss"));
    }
}

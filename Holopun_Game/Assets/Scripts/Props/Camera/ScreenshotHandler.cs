using UnityEngine;

public class ScreenshotHandler : MonoBehaviour {

    [SerializeField] private Camera myCamera;
    [SerializeField] private int i_width;
    [SerializeField] private int i_height;
    private bool takeScreenshotOnNextFrame;

    private void OnPostRender() {
        if (takeScreenshotOnNextFrame) {
            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenshot.png", byteArray);
            Debug.Log("Saved CameraScreenshot.png");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }

    public void TakeScreenshot() {
        myCamera.targetTexture = RenderTexture.GetTemporary(i_width, i_height, 16);
        takeScreenshotOnNextFrame = true;
    }
}

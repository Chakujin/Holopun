using UnityEngine;
using DG.Tweening;

public class CanvasAnimation : MonoBehaviour
{
    public static void CanvasMainAnimIn(GameObject canvas, float scale,float duration)
    {
        canvas.transform.localScale = Vector3.zero;
        canvas.transform.DOScale(scale, duration).SetEase(Ease.OutElastic);
    }
    public static void CanvasMainAnimOut(GameObject canvas, float scale, float duration)
    {
        canvas.transform.DOScale(scale, duration).SetEase(Ease.OutCubic);
    }
    public static void CanvasSingleplayerIn(RectTransform canvasTransform)
    {
        Vector3 safeScale = canvasTransform.localScale;

        canvasTransform.localScale = Vector3.zero;
        canvasTransform.DOScale(safeScale, 3).SetEase(Ease.OutElastic);
    }
}

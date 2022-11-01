using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendshapeController : MonoBehaviour
{
    public SkinnedMeshRenderer myrenderer;
    public int indexBlendshape;

    public void SetCatMouth(float sliderValue)
    {
        Debug.Log("PAso Slider");
        Debug.Log(sliderValue);
        Debug.Log(myrenderer.sharedMesh.blendShapeCount);
        myrenderer.SetBlendShapeWeight(indexBlendshape, sliderValue);
    }

    public void DebugSlider()
    {
        Debug.Log("a");
    }
}

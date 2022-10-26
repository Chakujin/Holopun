using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendshapeController : MonoBehaviour
{
    public SkinnedMeshRenderer myrenderer;
    public int indexBlendshape;

    public void SetCatMouth(float sliderValue)
    {
        myrenderer.SetBlendShapeWeight(indexBlendshape, sliderValue);
    }
}

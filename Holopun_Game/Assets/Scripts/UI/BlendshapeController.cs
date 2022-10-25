using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendshapeController : MonoBehaviour
{
    public SkinnedMeshRenderer myrenderer;
    private float f_time = 0;

    public void SetCatMouth(float sliderValue)
    {
        myrenderer.SetBlendShapeWeight(1, sliderValue);
    }

    //private void Update()
    //{
    //    f_time += Time.deltaTime;
    //    myrenderer.SetBlendShapeWeight(1, f_time);
    //}
}

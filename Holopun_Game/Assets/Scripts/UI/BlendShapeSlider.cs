using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapeSlider : MonoBehaviour
{
    public BlendshapeController controller;
    public int numBlendShapeEdit;

    public void ChangeBlendshapeValue(float sliderValue)
    {
        if (controller.indexBlendshape.ContainsKey(numBlendShapeEdit))
        {
            controller.indexBlendshape[numBlendShapeEdit] = sliderValue;
        }
        else
        {
            controller.indexBlendshape.Add(numBlendShapeEdit, sliderValue);
        }
    }
}

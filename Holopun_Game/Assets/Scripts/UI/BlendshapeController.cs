using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendshapeController : MonoBehaviour
{
    public SkinnedMeshRenderer myrenderer;
    public Dictionary<int ,float> indexBlendshape;

    private void Update()
    {
        if(indexBlendshape != null)
        {
            foreach (KeyValuePair<int, float> kvp in indexBlendshape)
            {
                myrenderer.SetBlendShapeWeight(kvp.Key, kvp.Value);
            }
        }
    }
}

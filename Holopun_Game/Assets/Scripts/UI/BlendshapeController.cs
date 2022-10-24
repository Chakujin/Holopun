using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendshapeController : MonoBehaviour
{
    public SkinnedMeshRenderer myrenderer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(myrenderer.sharedMesh.blendShapeCount);
        myrenderer.SetBlendShapeWeight(1,100);
    }
}

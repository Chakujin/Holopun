using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBlendShape : MonoBehaviour
{
    public int blendShapeCount;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Mesh skinnedMesh;
    float blendOne = 0f;
    float blendTwo = 0f;
    float blendSpeed = 1f;
    bool blendOneFinished = false;

    //void Awake()
    //{
    //    skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    //    skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
    //}

    void Start()
    {
        skinnedMesh = skinnedMeshRenderer.sharedMesh;
        blendShapeCount = skinnedMesh.blendShapeCount;
        Debug.Log(skinnedMesh.GetBlendShapeName(1));

        //skinnedMeshRenderer.GetBlendShapeWeight(skinnedMesh.GetBlendShapeIndex("eyesLeft"));
    }

    void Update()
    {
        if (blendShapeCount > 2)
        {

            if (blendOne < 100f)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(skinnedMesh.GetBlendShapeIndex("eyesLeft"), blendOne);
                blendOne += blendSpeed;
            }
            else
            {
                blendOneFinished = true;
            }

            if (blendOneFinished == true && blendTwo < 100f)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(1, blendTwo);
                Debug.Log(skinnedMeshRenderer.GetBlendShapeWeight(1));
                blendTwo += blendSpeed;
            }

        }
    }
}

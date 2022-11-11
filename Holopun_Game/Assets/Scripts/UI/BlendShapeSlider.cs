using UnityEngine;

public class BlendShapeSlider : MonoBehaviour
{
    [SerializeField] private BlendshapeController controller;
    private int i_numBlendShapeEdit;
    [SerializeField] private string NameBlendShape;

    private void Awake()
    {   
        for(int i = 0; i < controller.myrenderer.sharedMesh.blendShapeCount; i++)
        {
            if(controller.myrenderer.sharedMesh.GetBlendShapeName(i) == NameBlendShape) //Find name on the array blendhspaes
            {
                i_numBlendShapeEdit = controller.myrenderer.sharedMesh.GetBlendShapeIndex(NameBlendShape); // Get the num index on the List
               controller.indexBlendshape.Add(i_numBlendShapeEdit, 0); // Create and add shape and hes value to a dicctionary
            }
        }
    }

    public void ChangeBlendshapeValue(float sliderValue)
    {
        if (controller.indexBlendshape.ContainsKey(i_numBlendShapeEdit) == true) //Contains this index on Dictionary?
        {
            controller.indexBlendshape[i_numBlendShapeEdit] = sliderValue; // Pass new value
        }
    }
}

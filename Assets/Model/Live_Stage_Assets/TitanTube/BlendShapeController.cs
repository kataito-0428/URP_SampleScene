using UnityEngine;

[ExecuteInEditMode]
public class BlendShapeController : MonoBehaviour
{
    public SkinnedMeshRenderer parentMeshRenderer;
    public SkinnedMeshRenderer childMeshRenderer;

    [System.Serializable]
    public class BlendShapeInfo
    {
        public string name;
        public float value;
    }

    public BlendShapeInfo[] sliderBlendShapes;
    public BlendShapeInfo[] buttonBlendShapes;

    void Update()
    {
        // エディタモードで実行
        if (!Application.isPlaying)
        {
            UpdateBlendShapes();
        }
    }

    public void UpdateBlendShapes()
    {
        if (sliderBlendShapes != null)
        {
            foreach (BlendShapeInfo blendShape in sliderBlendShapes)
            {
                int parentBlendShapeIndex = parentMeshRenderer.sharedMesh.GetBlendShapeIndex(blendShape.name);
                int childBlendShapeIndex = childMeshRenderer.sharedMesh.GetBlendShapeIndex(blendShape.name);

                if (parentBlendShapeIndex >= 0)
                {
                    parentMeshRenderer.SetBlendShapeWeight(parentBlendShapeIndex, blendShape.value);
                }
                if (childBlendShapeIndex >= 0)
                {
                    childMeshRenderer.SetBlendShapeWeight(childBlendShapeIndex, blendShape.value);
                }
            }
        }

        if (buttonBlendShapes != null)
        {
            foreach (BlendShapeInfo blendShape in buttonBlendShapes)
            {
                int parentBlendShapeIndex = parentMeshRenderer.sharedMesh.GetBlendShapeIndex(blendShape.name);
                int childBlendShapeIndex = childMeshRenderer.sharedMesh.GetBlendShapeIndex(blendShape.name);

                if (parentBlendShapeIndex >= 0)
                {
                    parentMeshRenderer.SetBlendShapeWeight(parentBlendShapeIndex, blendShape.value);
                }
                if (childBlendShapeIndex >= 0)
                {
                    childMeshRenderer.SetBlendShapeWeight(childBlendShapeIndex, blendShape.value);
                }
            }
        }
    }

    public void SetBlendShapeValue(string blendShapeName)
    {
        foreach (BlendShapeInfo blendShape in buttonBlendShapes)
        {
            blendShape.value = blendShape.name == blendShapeName ? 100f : 0f;
        }
        UpdateBlendShapes();
    }

    public void ResetBlendShapes()
    {
        foreach (BlendShapeInfo blendShape in sliderBlendShapes)
        {
            blendShape.value = 0f;
        }
        foreach (BlendShapeInfo blendShape in buttonBlendShapes)
        {
            blendShape.value = 0f;
        }
        UpdateBlendShapes();
    }
}
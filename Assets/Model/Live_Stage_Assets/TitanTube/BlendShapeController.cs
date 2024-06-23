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

    public BlendShapeInfo[] blendShapes;

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
        if (blendShapes == null) return;

        foreach (BlendShapeInfo blendShape in blendShapes)
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

    public void SetBlendShapeValue(string blendShapeName)
    {
        foreach (BlendShapeInfo blendShape in blendShapes)
        {
            blendShape.value = blendShape.name == blendShapeName ? 100f : 0f;
        }
        UpdateBlendShapes();
    }

    public void ResetBlendShapes()
    {
        foreach (BlendShapeInfo blendShape in blendShapes)
        {
            blendShape.value = 0f;
        }
        UpdateBlendShapes();
    }
}
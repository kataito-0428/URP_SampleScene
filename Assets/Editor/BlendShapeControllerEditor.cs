using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BlendShapeController))]
public class BlendShapeControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BlendShapeController controller = (BlendShapeController)target;

        if (GUILayout.Button("Reset"))
        {
            controller.ResetBlendShapes();
        }

        if (controller.blendShapes != null)
        {
            foreach (var blendShape in controller.blendShapes)
            {
                if (GUILayout.Button(blendShape.name))
                {
                    controller.SetBlendShapeValue(blendShape.name);
                }
            }
        }

        if (GUI.changed)
        {
            controller.UpdateBlendShapes();
        }
    }
}
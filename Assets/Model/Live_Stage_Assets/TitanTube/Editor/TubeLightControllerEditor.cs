using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TubeLightController))]
public class BlendShapeControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TubeLightController controller = (TubeLightController)target;

        EditorGUILayout.LabelField("Slider Controlled BlendShapes", EditorStyles.boldLabel);

        if (controller.sliderBlendShapes != null)
        {
            foreach (var blendShape in controller.sliderBlendShapes)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(blendShape.name, GUILayout.Width(150));
                blendShape.value = EditorGUILayout.Slider(blendShape.value, 0f, 100f);
                EditorGUILayout.EndHorizontal();
            }
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Button Controlled BlendShapes", EditorStyles.boldLabel);

        if (controller.buttonBlendShapes != null)
        {
            foreach (var blendShape in controller.buttonBlendShapes)
            {
                if (GUILayout.Button(blendShape.name))
                {
                    controller.SetBlendShapeValue(blendShape.name);
                }
            }
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Reset Button Bllendshape"))
        {
            controller.ResetButtonBlendShapes();
        }

        // BlendShape値の変更があったときに自動的に更新を行う
        if (GUI.changed)
        {
            controller.UpdateBlendShapes();
        }
    }
}

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Therapy))]
public class TherapyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Therapy myScript = (Therapy)target;

        if (GUILayout.Button("Initialize"))
        {
            myScript.Initialize();
        }

        DrawDefaultInspector();
    }
}
#endif
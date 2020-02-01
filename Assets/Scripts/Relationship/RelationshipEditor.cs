#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Relationship))]
public class Relationship : Editor
{
    public override void OnInspectorGUI()
    {
        Relationship myScript = (Relationship)target;

        if (GUILayout.Button("CALCULATE CONFLICT"))
        {
            myScript.calculateConflict();
        }

        DrawDefaultInspector();
    }
}
#endif
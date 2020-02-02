#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Relationship))]
public class RelationshipEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Relationship myScript = (Relationship)target;

        if (GUILayout.Button("CALCULATE CONFLICT"))
        {
            myScript.calculateConflict();
        }
        if (GUILayout.Button("CALCULATE DESTINY"))
        {
            myScript.calculateDestiny();
        }

        DrawDefaultInspector();
    }
}
#endif
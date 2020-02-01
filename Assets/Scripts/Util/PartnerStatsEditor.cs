#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PartnerStats))]
public class PartnerStatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PartnerStats myScript = (PartnerStats)target;

        if (GUILayout.Button("SYNC"))
        {
            myScript.Resize(myScript.StatCount);
            myScript.Sync();
        }
        if (GUILayout.Button("RANDOMIZE"))
        {
            myScript.Resize(myScript.StatCount);
            myScript.Randomize();
        }

        DrawDefaultInspector();
    }
}
#endif
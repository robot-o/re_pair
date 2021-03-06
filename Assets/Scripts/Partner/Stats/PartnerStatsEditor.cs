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
            myScript.SyncStatSize(myScript.StatCount);
            myScript.SyncStatNames();
        }
        if (GUILayout.Button("RANDOMIZE"))
        {
            myScript.SyncStatSize(myScript.StatCount);
            myScript.ApplyRandomize();
        }

        DrawDefaultInspector();
    }
}
#endif
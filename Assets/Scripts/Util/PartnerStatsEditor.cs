#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PartnerStats))]
public class PartnerStatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PartnerStats myScript = (PartnerStats)target;

        if (GUILayout.Button("Resize/Sync"))
        {
            myScript.Resize(myScript.StatCount);
            myScript.Sync();
        }

        DrawDefaultInspector();
    }
}
#endif
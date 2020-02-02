#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Session))]
public class Sessionditor : Editor
{
    public override void OnInspectorGUI()
    {
        Session myScript = (Session)target;

        // if (GUILayout.Button("deltaA"))
        // {
        //     myScript.recordDeltaA();
        // }
        // if (GUILayout.Button("deltaB"))
        // {
        //     myScript.recordDeltaB();
        // }
        if (GUILayout.Button("revealHA"))
        {
            foreach (string s in myScript.relationship.partnerA.stats.statNames)
            {
                Debug.Log($"revealing HAVE: {s} on A: {myScript.revealHaveA(s).val}");
            }
        }
        if (GUILayout.Button("revealWA"))
        {
            foreach (string s in myScript.relationship.partnerA.stats.statNames)
            {
                Util.FloatRange val = myScript.revealWantA(s).val;
                Debug.Log($"revealing WANT: {s} on A: {val.min} - {val.max}");
            }
        }
        if (GUILayout.Button("revealHB"))
        {
            foreach (string s in myScript.relationship.partnerB.stats.statNames)
            {
                Debug.Log($"revealing HAVE: {s} on B {myScript.revealHaveB(s).val}");
            }
        }
        if (GUILayout.Button("revealWB"))
        {
            foreach (string s in myScript.relationship.partnerB.stats.statNames)
            {
                Util.FloatRange val = myScript.revealWantB(s).val;
                Debug.Log($"revealing WANT: {s} on B: {val.min} - {val.max}");
            }
        }
        

        DrawDefaultInspector();
    }
}
#endif
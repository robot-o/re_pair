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

        if (GUILayout.Button("Next Session"))
        {
            if (!myScript.NextSession())
                Debug.Log("reached last Session");
        }


        DrawDefaultInspector();
    }
}
#endif
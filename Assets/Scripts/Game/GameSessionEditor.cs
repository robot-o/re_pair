#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameSession))]
public class GameSessionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameSession myScript = (GameSession)target;

        if (GUILayout.Button("Initialize"))
        {
            myScript.Initialize();
        }

        if (GUILayout.Button("Next Therapy"))
        {
            if (!myScript.NextTherapySession())
                Debug.Log("reached last therapy");
        }

        DrawDefaultInspector();
    }
}
#endif
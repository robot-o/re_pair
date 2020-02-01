using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu(menuName = "REPAIR/Therapy", order = 1)]
public class Therapy : ScriptableObject
{
    public Relationship relationship;
    public int budget;
    public List<Session> sessions;
}
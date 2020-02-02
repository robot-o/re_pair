using UnityEngine;
using System.Collections.Generic;
public class GameSession : MonoBehaviour
{
    public int relationshipCount = 1;
    public List<TherapySettings> therapySettings;
    public List<Therapy> therapies;


    public void Initialize()
    {
        therapySettings = new List<TherapySettings>(relationshipCount);
    }

    public void StartSession()
    {
        
    }

}
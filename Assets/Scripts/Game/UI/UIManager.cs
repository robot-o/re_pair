using UnityEngine;
using TMPro; 
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public GameSessionManager gsMgr;
    public GameSession gameSession;

    public TMP_Text a;
    public TMP_Text b;


    public void RegisterGameSession(ref GameSession _session)
    {
        gameSession = _session;

        gameSession.NextTherapySession();
        a.text = $"<sprite name=\"{gameSession.GetActiveTherapy().relationship.partnerA.displayName}\">";
        b.text = $"<sprite name=\"{gameSession.GetActiveTherapy().relationship.partnerB.displayName}\">";
    }

    public void SpawnUIElement(GameObject prefab)
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.parent = transform;
    }

}
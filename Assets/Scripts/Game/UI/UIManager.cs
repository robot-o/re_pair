using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public GameSessionManager gsMgr;
    public GameSession gameSession;

    public TMP_Text a;
    public TMP_Text b;

    public List<Slider> leftsliders = new List<Slider>(5);
    public List<Slider> rightsliders = new List<Slider>(5);
    private Therapy act;
    private PartnerStats pa;
    private PartnerStats pb;
    private bool isleftactive;
    public void SetActiveSide(bool left)
    {
        isleftactive = left;
    }

    public void RevealRight(int num)
    {
        if (isleftactive)
        {
            gameSession.GetActiveTherapy().GetActiveSession().revealWantA(num);
        }
        else
        {
            gameSession.GetActiveTherapy().GetActiveSession().revealHaveB(num);
            
        }
    }
    public void RevealLeft(int num)
    {
        if (isleftactive)
        {
            gameSession.GetActiveTherapy().GetActiveSession().revealHaveA(num);
        }
        else
        {
            gameSession.GetActiveTherapy().GetActiveSession().revealWantB(num);
            
        }
    }

    public void RegisterGameSession(ref GameSession _session)
    {
        gameSession = _session;

        gameSession.NextTherapySession();
        a.text = $"<sprite name=\"{gameSession.GetActiveTherapy().relationship.partnerA.displayName}\">";
        b.text = $"<sprite name=\"{gameSession.GetActiveTherapy().relationship.partnerB.displayName}\">";
        act = gameSession.GetActiveTherapy();
        pa = act.relationship.partnerA.stats;
        pb = act.relationship.partnerB.stats;
        act.NextSession();
    }

    public void SpawnUIElement(GameObject prefab)
    {
        GameObject instance = Instantiate(prefab);
        instance.transform.parent = transform;
    }

    private void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            leftsliders[i].gameObject.SetActive(pa.have[i].isRevealed);
            leftsliders[i].value = pa.have[i].val;

            rightsliders[i].gameObject.SetActive(pb.have[i].isRevealed);
            rightsliders[i].value = pb.have[i].val;
        }
    }
}
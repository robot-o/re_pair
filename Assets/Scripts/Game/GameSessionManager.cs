using UnityEngine;
using System.Collections.Generic;

public class GameSessionManager : MonoBehaviour
{
    public GameSession gameSession;
    public GameObject uiManagerPrefab;
    public UIManager uiManager;

    public List<TherapySettings> therapySettings;

    private void Start()
    {
        SpawnGameSession();
    }

    private void SpawnGameSession()
    {
        if (gameSession != null)
        {
            DestroyGameSession();
        }

        gameSession = new GameObject("GameSession").AddComponent<GameSession>();
        uiManager = Instantiate(uiManagerPrefab).GetComponent<UIManager>();
        uiManager.gsMgr = this;

        if (therapySettings == null)
        {
            Debug.Log("initialized with generated therapy settings");
            gameSession.Initialize();
        }
        else
        {
            Debug.Log("initialized with custom set therapy settings");
            gameSession.Initialize(therapySettings);
        }
        uiManager.RegisterGameSession(ref gameSession);
    }


    public void DestroyGameSession()
    {
        GameObject ui = uiManager.gameObject;
        Destroy(uiManager);
        Destroy(ui);
        GameObject gs = gameSession.gameObject;
        Destroy(gameSession);
        Destroy(gs);

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGamesServicesUIController : MonoBehaviour
{
    public static PlayGamesServicesUIController Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void ShowLeaderboard()
    {
        PlayGameServices.ShowLeaderboardsUI();
    }
}

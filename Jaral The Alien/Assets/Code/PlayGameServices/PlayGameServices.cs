using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayGameServices : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SignIn();
    }

    private void SignIn()
    {
        Social.localUser.Authenticate(success => { });
    }

    #region Achievements
    //public static void UnlockAchievement(string id)
    //{
    //    Social.ReportProgress(id, 100, sucess => { });
    //}

    //public static void IncrementAchievement(string id, int stepsToIncrement)
    //{
    //    PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
    //}

    //public static void ShowAchievement()
    //{
    //    Social.ShowAchievementsUI();
    //}
    #endregion

    #region Leaderboard
    public static void AddScoreToLeaderboard(string leaderBoardId, long score)
    {
        Social.ReportScore(score, leaderBoardId, success => { });
    }

    public static void ShowLeaderboardsUI()
    {
        Social.ShowLeaderboardUI();
    }
    #endregion
}

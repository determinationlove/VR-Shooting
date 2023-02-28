using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<RectTransform> UI;
    public GameStart gameStart;
    public ScoreSurvey scoreSurvey;
    public Rank rank;

    public GameManager gameManager;
    public GameSet gameSet;


    void Start()
    {
        Init();
    }

    void Update()
    {
        if (gameManager.gameover == true)
        {
            GameOver();
            gameManager.gameover = false;
        }

        if (scoreSurvey.survey == true)
            scoreSurvey.ScoreSurvey_Update();
        
        if (scoreSurvey.surveyEnd == true)
        {
            UI_In(UI[3]);
            scoreSurvey.surveyEnd = false;
        }
    }

    public void Init()
    {
        gameSet = new GameSet();

        UI_In(UI[0]);

        gameStart.startgame.onClick.AddListener(PlayGame);
        rank.again.onClick.AddListener(PlayAgain);
    }

    public void UI_In(RectTransform ui)
    {
        UI_Out();
        ui.localPosition = new Vector3(0, 0, 0);
    }

    public void UI_Out()
    {
        for (int i = 0; i < UI.Count; i++)
        {
            UI[i].localPosition = new Vector3(0, 5000, 0);
        }
    }

    public void PlayGame()
    {
        gameStart.slider1.interactable = false;
        gameStart.slider2.interactable = false;

        gameSet.Num = gameStart.slider1.value;
        gameSet.Speed = gameStart.slider2.value;

        gameManager.Init();
        Get_GameSet();
        gameManager.GameManager_Start();
        gameManager.Init_Instant();
        gameManager.ready = true;

        UI_Out();
    }

    public void Get_GameSet()
    {
        gameManager.ThisGameSet = gameSet;
    }

    public void GameOver()
    {
        rank.newScore = gameManager.worldScore.total;
        rank.Rank_Start();
        scoreSurvey.survey = true;
        scoreSurvey.ScoreSurvey_Start();
        UI_In(UI[2]);
    }

    public void PlayAgain()
    {
        gameManager.worldScore.total = 0;
        UI_In(UI[0]);
        gameStart.slider1.interactable = true;
        gameStart.slider2.interactable = true;
    }
}

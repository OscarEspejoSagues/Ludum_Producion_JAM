using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerScore
{
    public int BestScore;
    public int BestSurvivedTraps;
}

public class ScoreManager : MonoBehaviour
{
    [Header("Score Manager")]
    public int Inc = 5;
    public int Score
    {
        get
        {
            return _score;
        }
    }
    public Text ScoreNum;

    [Header("Score Screen")]
    public GameObject ScoreScreen;
    public Text YourScore;
    public Text SurvivedTraps;
    public Text BestScore;
    public Text BestSurvivedTraps;


    //[SerializeField]
    private int _score;


    private void Start()
    {
        
    }

    private void Update()
    {
        ScoreNum.text = _score.ToString();
    }

    //Increase score by certain amount
    public void AddScore()
    {
        _score += Inc;
    }

    //Save current score
    public void SaveScore()
    {
        //File.WriteAllText()
    }

    //Get all saved scores
    private void GetScores()
    {

    }

    public void ShowScoreScreen()
    {
        ScoreScreen.SetActive(true);
    }

    public void SetUpScoreScreen(int survivedTraps)
    {
        YourScore.text = _score.ToString();
        SurvivedTraps.text = survivedTraps.ToString();
    }
}

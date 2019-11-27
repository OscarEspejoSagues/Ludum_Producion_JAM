using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int Inc = 5;
    public int Score
    {
        get
        {
            return _score;
        }
    }
    public Text ScoreNum;

    [SerializeField]
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

    }

    //Get all saved scores
    private void GetScores()
    {

    }
}

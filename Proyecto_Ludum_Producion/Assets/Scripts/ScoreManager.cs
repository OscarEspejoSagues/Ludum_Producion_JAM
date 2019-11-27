using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int _score;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    //Increase score by certain amount
    public void AddScore(int inc)
    {
        _score += inc;
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

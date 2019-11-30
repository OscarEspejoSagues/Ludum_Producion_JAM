using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PersistentData
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

    [SerializeField]
    private int _score;
    private PersistentData SavedData;


    private void Start()
    {
        SavedData = new PersistentData();
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

    //Save data if appropiate
    public void SaveData(int survivedTraps)
    {
        //Get data from file
        GetSavedData();

        //Compare saved data to current data
        if (survivedTraps > SavedData.BestSurvivedTraps)
            SavedData.BestSurvivedTraps = survivedTraps;
        if (_score > SavedData.BestScore)
            SavedData.BestScore = _score;

        //Save data
        string data = JsonUtility.ToJson(SavedData);
        File.WriteAllText(Application.persistentDataPath + "/SavedData.txt", data);
    }

    //Get saved data
    private void GetSavedData()
    {
        if (File.Exists(Application.persistentDataPath + "/SavedData.txt"))
        {
            SavedData = JsonUtility.FromJson<PersistentData>(File.ReadAllText(Application.persistentDataPath + "/SavedData.txt"));
        }
        else
        {
            SavedData.BestScore = 0;
            SavedData.BestSurvivedTraps = 0;
        }
    }

    public void ShowScoreScreen()
    {
        ScoreScreen.SetActive(true);
    }

    public void SetUpScoreScreen(int survivedTraps)
    {
        YourScore.text = _score.ToString();
        SurvivedTraps.text = survivedTraps.ToString();
        BestSurvivedTraps.text = SavedData.BestSurvivedTraps.ToString();
        BestScore.text = SavedData.BestScore.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [Header("References")]
    public ScoreManager ScoreManager;
    public EventUI EventUI;
    public Text Description;
    public PlayerController PlayerController;
    public PlayerEventManagerScript PlayerEventManager;

    [Header("Levels")]
    public float LevelThreshold = 30f;
    public int MaxLevel = 3;
    public List<ScriptableEvent> Level1Traps;
    public List<ScriptableEvent> Level2Traps;
    public List<ScriptableEvent> Level3Traps;

    [Header("Events")]
    public float EventTime = 5f;
    //public Text GlobalTime;

    //[SerializeField]
    private ScriptableEvent _currentTrap;
    //[SerializeField]
    private List<GameObject> _activeTraps;
    //[SerializeField]
    private bool _gameFreezed;
    //[SerializeField]
    private float _globalTimer;
    //[SerializeField]
    private float _newEventTimer;
    //[SerializeField]
    private float _scoreTimer;
    //[SerializeField]
    private float _levelTimer;
    //[SerializeField]
    private int _currentLevel;

    //Start
    private void Start()
    {
        Time.timeScale = 1f;

        _gameFreezed = true;
        _activeTraps = new List<GameObject>();

        _globalTimer = 0f;
        _newEventTimer = 0f;
        _scoreTimer = 0f;
        _levelTimer = 0f;

        _currentLevel = 1;

        FreezeGame();
    }

    //Update
    private void Update()
    {
        if (!_gameFreezed)
        {
            _globalTimer += Time.deltaTime;
            _newEventTimer += Time.deltaTime;
            _levelTimer += Time.deltaTime;

            if (_newEventTimer >= 5f)
            {
                FreezeGame();
                _newEventTimer = 0f;
            }

            if (_globalTimer - _scoreTimer > 1f && !PlayerController.death)
            {
                //Reset timer and add score
                _scoreTimer = _globalTimer;
                ScoreManager.AddScore();
            }

            if (_levelTimer >= LevelThreshold && _currentLevel < MaxLevel)
            {
                _currentLevel++;
                _levelTimer = 0;
            }
        }
    }

    //Freezes game
    private void FreezeGame()
    {
        //Debug.Log("game freezed");
        _gameFreezed = true;
        PlayerController.freezed = true;

        FinishEvent();

        InitializeEvent();

        //Activate text animation (show text)
        AnimIn();
    }

    //Unfreezes game
    public void UnfreezeGame()
    {
        _gameFreezed = false;
        PlayerController.freezed = false;

        StartEvent();
    }

    //Selects random event (trap) based on current level
    private void InitializeEvent()
    {
        //Initialize event
        int rand = 0;
        switch (_currentLevel)
        {
            case 1:
                rand = Random.Range(0, Level1Traps.Count);
                _currentTrap = Level1Traps[rand];
                break;

            case 2:
                rand = Random.Range(0, Level2Traps.Count);
                _currentTrap = Level2Traps[rand];
                break;

            case 3:
                rand = Random.Range(0, Level3Traps.Count);
                _currentTrap = Level3Traps[rand];
                break;
        }
    }

    //Start event. Instantiates traps
    private void StartEvent()
    {
        //Activate Debuff
        PlayerEventManager.CurrentEvent = _currentTrap.Debuff;
        PlayerEventManager.enableEvent = true;

        //Spawn all traps
        foreach (TrapEvent trap in _currentTrap.Traps)
        {
            GameObject newTrap = Instantiate(trap.TrapPrefab, Vector3.zero, Quaternion.identity);
            //Setup trap configuration
            switch (trap.TrapType)
            {
                case TrapType.LASER:
                    newTrap.GetComponent<TrapLaserScript>().InitializeTrap(trap.NumberOfLasers, trap.Speed, trap.MoveX, trap.NegativeX, trap.MoveY, trap.NegativeY);
                    break;

                case TrapType.KNIFES:
                    newTrap.GetComponent<KnifeSpawner>().InitializeTrap(trap.Rate, trap.Speed, trap.NegativeX, trap.GoUp);
                    break;

                case TrapType.SPIKES:
                    //To do
                    break;
            }

            newTrap.transform.position = trap.InitialPosition;
            newTrap.transform.localEulerAngles = trap.InitialRotation;

            _activeTraps.Add(newTrap);
        }
    }

    //Destroy all traps and freeze everything
    private void FinishEvent()
    {
        //Destroy all traps and reset event
        foreach (GameObject gameObject in _activeTraps)
        {
            Destroy(gameObject);
        }

        PlayerEventManager.enableEvent = false;
    }

    //Write score in disk
    private void SaveScore()
    {
        //Call SaveScore() in ScoreManager
        ScoreManager.SaveScore();
    }

    //Start description animation
    private void AnimIn()
    {
        Description.text = _currentTrap.Description;
        EventUI.AnimationIn();
    }
}

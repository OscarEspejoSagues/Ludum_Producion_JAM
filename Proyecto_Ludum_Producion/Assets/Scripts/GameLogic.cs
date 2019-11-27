using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public ScoreManager ScoreManager;
    public List<ScriptableEvent> PossibleTraps;
    public EventUI EventUI;
    public Text Description;
    public float EventTime = 5f;
    public PlayerController PlayerController;
    //public Text GlobalTime;

    [SerializeField]
    private ScriptableEvent _currentTrap;
    [SerializeField]
    private List<GameObject> _activeTraps;
    [SerializeField]
    private bool _gameFreezed;
    [SerializeField]
    private float _globalTimer;
    [SerializeField]
    private float _newEventTimer;
    [SerializeField]
    private float _scoreTimer;


    private void Start()
    {
        _gameFreezed = true;
        _activeTraps = new List<GameObject>();

        _globalTimer = 0f;
        _newEventTimer = 0f;
        _scoreTimer = 0f;

        FreezeGame();
    }

    private void Update()
    {
        if (!_gameFreezed)
        {
            _globalTimer += Time.deltaTime;
            _newEventTimer += Time.deltaTime;

            if (_newEventTimer >= 5f)
            {
                FreezeGame();
                _newEventTimer = 0f;
            }

            if(_globalTimer - _scoreTimer > 1f && !PlayerController.death)
            {
                //Reset timer and add score
                _scoreTimer = _globalTimer;
                ScoreManager.AddScore();
            }
        }
    }

    private void FreezeGame()
    {
        Debug.Log("game freezed");
        _gameFreezed = true;
        PlayerController.freezed = true;

        FinishEvent();

        InitializeEvent();

        //Activate text animation (show text)
        AnimIn();
    }

    public void UnfreezeGame()
    {
        _gameFreezed = false;
        PlayerController.freezed = false;

        StartEvent();
    }

    private void InitializeEvent()
    {
        //Initialize event
        int rand = Random.Range(0, PossibleTraps.Count);
        _currentTrap = PossibleTraps[rand];
    }

    private void StartEvent()
    {
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
    }

    //Write score in disk
    private void SaveScore()
    {
        //Call SaveScore() in ScoreManager
        ScoreManager.SaveScore();
    }

    private void AnimIn()
    {
        Description.text = _currentTrap.Description;
        EventUI.AnimationIn();
    }
}

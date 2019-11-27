using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrapType { LASER, PINCHOS};

[CreateAssetMenu(menuName = "ScriptableObjects/Events", order = 1)]
public class ScriptableEvent : ScriptableObject
{
    [Header("General")]
    public TrapType TrapType;
    public string Description;
    public List<TrapEvent> Traps;

    //[Header("Laser")]
    //public GameObject LaserTrapPrefab;
    //public List<LaserEvent> LaserTraps;

    //[Header("Pinchos")]
    //public GameObject PinchosTrapPrefab;
    //public List<PinchosEvent> PinchosTraps;
}

[System.Serializable]
public class TrapEvent
{
    public int NumberOfLasers = 10;
    public GameObject TrapPrefab;

    public float Speed = 5.0f;
    public bool MoveX = false;
    public bool NegativeX = false;
    public bool MoveY = false;
    public bool NegativeY = false;

    public Vector2 InitialPosition;
    public Vector3 InitialRotation;
}

[System.Serializable]
public class LaserEvent:TrapEvent
{
    //public int NumberOfLasers = 10;
    //public GameObject myLaserPrefab;

    //public float Speed = 5.0f;
    //public bool MoveX = false;
    //public bool NegativeX = false;
    //public bool MoveY = false;
    //public bool NegativeY = false;

    //public Vector2 InitialPosition;
}


[System.Serializable]
public class PinchosEvent:TrapEvent
{
    //TODO
}
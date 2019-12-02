using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrapType { LASER, KNIFES, SPIKES, SHURIKEN};

[CreateAssetMenu(menuName = "ScriptableObjects/Events", order = 1)]
public class ScriptableEvent : ScriptableObject
{
    [Header("General")]
    public string Description;
    public events Debuff;
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
    [Header("Shared")]
    public TrapType TrapType;
    public GameObject TrapPrefab;
    public float Speed = 5.0f;
    public bool NegativeX = false;
    public Vector2 InitialPosition;
    public Vector3 InitialRotation;

    [Header("Laser")]
    public int LaserLength = 10;
    public bool MoveX = false;
    public bool MoveY = false;
    public bool NegativeY = false;

    [Header("Cuchillas")]
    public float Rate;
    public bool GoUp = false;

    [Header("Shuriken")]
    public int RotationSpeed;
 

    //[Header("Pinchos")]

}

//[System.Serializable]
//public class LaserEvent:TrapEvent
//{
//    //public int NumberOfLasers = 10;
//    //public GameObject myLaserPrefab;

//    //public float Speed = 5.0f;
//    //public bool MoveX = false;
//    //public bool NegativeX = false;
//    //public bool MoveY = false;
//    //public bool NegativeY = false;

//    //public Vector2 InitialPosition;
//}


//[System.Serializable]
//public class PinchosEvent:TrapEvent
//{
//    //TODO
//}
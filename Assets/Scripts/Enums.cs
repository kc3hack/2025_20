using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idling,
    Waiting,
    Hovering,
    Dipping,
    GameOver
}

public enum ShopKeeperState
{
    Idling,
    LookingAtPlayer,
    Turning,
    LookingAtKitchen
}

public enum GameState
{
    Idling,
    Playing,
    GameOver,
    TimeOver,
    Result
}
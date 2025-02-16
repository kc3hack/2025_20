using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idoling,
    Waiting,
    Hovering,
    Dipping
}

public enum ShopKeeperState
{
    Idoling,
    LookingAtPlayer,
    Turning,
    LookingAtKitchen
}

public enum GameState
{
    Idoling,
    Playing,
    GameOver,
    Result
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static Action BossHitEvent;
    public static Action PlayerHitEvent;
    public static Action HeartPlayerHitEvent;
    public static Action EndGameEvent;

    public static void BossHit()
    {
        BossHitEvent?.Invoke();
    }

    public static void PlayerHit()
    {
        PlayerHitEvent?.Invoke();
    }
    
    public static void HeartPlayerHit()
    {
        HeartPlayerHitEvent?.Invoke();
    }

    public static void EndGame()
    {
        EndGameEvent?.Invoke();
    }

}
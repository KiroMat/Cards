using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum StateGame
{
    StartGame,
    BeginRound,
    PlayPlayer,
    PlayChallenger,
    EndRound,
    EndGame
}

public class ManagerGame : MonoBehaviour
{
    public List<Player> players;
    public AreaFields Area;
    public GameObject HandPlayerOne;
    public GameObject HandPlayerTwo;




    private StateGame currentState;
    public StateGame CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;
        }
    }



    // Tymczasowe właściwości
    int actualPlayer = 2;

    // Use this for initialization
    void Start()
    {
        currentState = StateGame.StartGame;
    }

    void ChangeState()
    {
        switch (currentState)
        {
            case StateGame.StartGame:
                FillHandPlayers();
                break;
            case StateGame.BeginRound:
                break;
            case StateGame.PlayPlayer:
                break;
            case StateGame.PlayChallenger:
                break;
            case StateGame.EndRound:
                break;
            case StateGame.EndGame:
                break;
            default:
                break;
        }
    }

    private void FillHandPlayers()
    {
        // Do zastanowienia się czy graczy bedzie tylko 2 czy bedziemy brać pod uwagę wiecej niż dwóch
    }
}

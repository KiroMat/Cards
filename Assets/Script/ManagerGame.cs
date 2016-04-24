using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum StateGame
{
    Non,
    PrepareRound,
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
    public GeneratorCards GenerateCards { get; set; }


    private StateGame oldState;
    private StateGame currentState;
    public StateGame CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            if(value != oldState)
            {
                currentState = value;
                ChangeState();
                oldState = currentState;
            }
                
        }
    }

    // zmienne pomocnicze
    int numberOfPlayers = 2;

    // Use this for initialization
    void Start()
    {
        CurrentState = StateGame.PrepareRound;
        GenerateCards = GameObject.FindGameObjectWithTag("CardGenerator").GetComponent<GeneratorCards>();


    }

    void ChangeState()
    {
        switch (currentState)
        {
            case StateGame.PrepareRound:
                MockCreatePlayers();
                FillHandPlayers();
                break;
            case StateGame.StartGame:
                break;
            // ******** Ta część bedzie wydzielona do innej funkcji
            case StateGame.BeginRound:
                break;
            case StateGame.PlayPlayer:
                break;
            case StateGame.PlayChallenger:
                break;
            case StateGame.EndRound:
                break;
            //*********************
            case StateGame.EndGame:
                break;
            default:
                break;
        }
    }

    private void FillHandPlayers()
    {
        // Do zastanowienia się czy graczy bedzie tylko 2 czy bedziemy brać pod uwagę wiecej niż dwóch
        // wówczas trzeba w jakiś sposób ustawiach obiekty Hand na scenie

        HandPlayerOne.GetComponent<Hand>().SetCartsInHand(players[0].Cards);
        HandPlayerTwo.GetComponent<Hand>().SetCartsInHand(players[1].Cards);

    }

    private void MockCreatePlayers()
    {
        players = new List<Player>();
        for (int i = 0; i < numberOfPlayers; i++)
        {
            players.Add(new Player());
        }
    }
}

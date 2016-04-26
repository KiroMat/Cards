using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

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
    public GameObject WindowsMessage;

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

    public void EndMovePlayer()
    {
        if (Area.IsFullArea())
            CurrentState = StateGame.EndGame;

        if (CurrentState == StateGame.PlayPlayer)
            CurrentState = StateGame.PlayChallenger;
        else if(CurrentState == StateGame.PlayChallenger)
            CurrentState = StateGame.EndRound;
    }


    public void ShowMessage(string text)
    {
        if (WindowsMessage != null)
            WindowsMessage.GetComponent<WindowMessage>().ShowMessage(text, 80);
        else
            Debug.Log("Okno dla wiadomości nie zostało podpięte go GameManager");
    }

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
                SelectTheFirstPlayer();

                CurrentState = StateGame.StartGame;
                break;
            case StateGame.StartGame:
                ShowMessage("Start game");

                CurrentState = StateGame.BeginRound;
                break;
            // ******** Ta część bedzie wydzielona do innej funkcji
            case StateGame.BeginRound:
                // zawsze pierwszy w tablicy jest graczem
                if (players[0].IsActive)
                    CurrentState = StateGame.PlayPlayer;
                else
                    CurrentState = StateGame.PlayChallenger;
                    
                break;
            case StateGame.PlayPlayer:
                players[0].IsActive = true;
                players[1].IsActive = false;
                break;
            case StateGame.PlayChallenger:
                players[0].IsActive = false;
                players[1].IsActive = true;
                break;
            case StateGame.EndRound:
                //TODO: Jakieś obliczenia, zliczanie czegoś 

                CurrentState = StateGame.PlayPlayer;
                break;
            //*********************
            case StateGame.EndGame:
                ShowMessage("Koniec gry");
                SceneManager.LoadScene("Menu");
                break;
            default:
                break;
        }
    }

    private void SelectTheFirstPlayer()
    {
        bool flg = UnityEngine.Random.Range(0, 10) % 2 == 0 ? true : false;
        if (flg)
            players[0].IsActive = true;
        else
            players[1].IsActive = true;

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

        players[0].Color = Color.green;
        players[1].Color = Color.red;
    }
}

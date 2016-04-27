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
    public ScoreBoard scoreBoard;
    public WindowMessage windowMessage;

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
        Area.UpdateScoreForPlayers();
        scoreBoard.updateScoreBoard();

        if (Area.IsFullArea())
            CurrentState = StateGame.EndGame;

        if (CurrentState == StateGame.PlayPlayer)
            CurrentState = StateGame.PlayChallenger;
        else if(CurrentState == StateGame.PlayChallenger)
            CurrentState = StateGame.EndRound;
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
                scoreBoard.initializeScoreBoard(ref players);
                SelectTheFirstPlayer();
                Area.InitializePlayers(ref players);

                CurrentState = StateGame.StartGame;
                break;
            case StateGame.StartGame:
                windowMessage.ShowMessage("Start game", 50);

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
                players[0].Score++;//linia dodana tylko aby sprawdzic dzialanie ScoreBoard - usun ja 
                break;
            case StateGame.PlayChallenger:
                players[0].IsActive = false;
                players[1].IsActive = true;
                players[1].Score++;//linia dodana tylko aby sprawdzic dzialanie ScoreBoard - usun ja 
                break;
            case StateGame.EndRound:
                //TODO: Jakieś obliczenia, zliczanie czegoś 

                CurrentState = StateGame.PlayPlayer;
                break;
            //*********************
            case StateGame.EndGame:
                windowMessage.ShowMessage("Koniec gry", 50, GoToManu);
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

    private void GoToManu()
    {
        SceneManager.LoadScene("Menu");
    }
}

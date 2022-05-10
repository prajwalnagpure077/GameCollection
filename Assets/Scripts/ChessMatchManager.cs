using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ChessGameState
{
    lose,
    draw,
    won,
}


public class ChessMatchManager : MonoBehaviour
{
    [SerializeField] GameObject PopUp;
    [SerializeField] Text message,timings;

    bool done = false;
    double time;

    public static ChessMatchManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(done == false)
            time += Time.deltaTime;
    }
    public void GameDone(ChessGameState state)
    {
        var _time = System.TimeSpan.FromSeconds(time);
        timings.text = string.Format("{0:D2}:{1:D2}", _time.Minutes, _time.Seconds, _time.Milliseconds.ToString().Substring(0, 1));
        switch (state)
        {
            case ChessGameState.lose:
                message.text = "You lose";
                break;
            case ChessGameState.draw:
                message.text = "You won";
                break;
            case ChessGameState.won:
                message.text = "draw";
                break;
        }
        done = true;
        PopUp.SetActive(true);
    }
}

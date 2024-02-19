using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NineMensMorris;
using System.IO;
using System;
using System.Threading.Tasks;
using UnityEngine.UI;

public class AIBehaviour : MonoBehaviour
{
    public int player;
    public GameObject TextPanel;

    private enum State
    {
        WaitForTurn,
        WaitForResult,
        ApplyMove
    }

    private object locker = new object();
    private State state;
    private Board board;
    private Game game;
    private Move move;
    private Queue<GameObject> stones = new Queue<GameObject>();

    public bool ResultAvailable { get { lock (locker) { return move != null; } } }

    private void Start()
    {
        TextPanel.SetActive(true);
        TextPanel.GetComponent<Text>().text = "Turn: Player";
        
        board = GameObject.Find("Board").GetComponent<Board>();
        game = GameObject.Find("GameManager").GetComponent<GameManager>().Game;

        foreach (var obj in FindObjectsOfType<GameObject>())
        {
            if (obj.name.Contains("StoneBlack"))
                stones.Enqueue(obj);
        }
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitForTurn:
                if (game.CurrentPlayer == player && !game.IsGameOver)
                {
                    TextPanel.GetComponent<Text>().text = "Turn: Ai\nThinking...";
                    CalculateMove();
                    state = State.WaitForResult;
                }
                break;

            case State.WaitForResult:
                if (ResultAvailable)
                {
                    TextPanel.GetComponent<Text>().text = "Turn: Ai\nMoving...";
                    state = State.ApplyMove;
                    StartCoroutine(ApplyMove());
                }
                break;

            case State.ApplyMove:
                break;
        }
    }

    private IEnumerator ApplyMove()
    {
        // 1. Move the stone
        var stone = move.From == -1 ? stones.Dequeue() : board.Stones[move.From];

        var startPos = stone.transform.position;
        var targetPos = board.Positions[move.To];

        var startTime = Time.time;
        var duration = 0.5f;

        while (Time.time - startTime < duration)
        {
            var t = (Time.time - startTime) / duration;
            stone.transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        stone.transform.position = targetPos;
        board.MoveStone(move.From, move.To, stone);

        // 2. Remove other player stone
        if (move.Remove != -1){
            TextPanel.GetComponent<Text>().text = "Turn: Ai\nRemoving Stone...";
            yield return new WaitForSeconds(1);
            board.RemoveStone(move.Remove);
        }
        // 3. Update game state
        game.Move(move);

        // 4. Wait for next turn
        move = null;
        TextPanel.GetComponent<Text>().text = "Turn: Player";
        state = State.WaitForTurn;
    }

    private void CalculateMove()
    {
        move = null;

        Task.Run(() =>
        {
            var ai = new AI();
            var move = ai.CalculateMove(game);

            lock (locker)
            {
                this.move = move;
            }
        });
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper: MonoBehaviour
{
    public static ScoreKeeper Instance { get; private set; }

    // Events for Player 1 and Player 2 scores
    public event Action<int> Player1ScoreChanged;
    public event Action<int> Player2ScoreChanged;

    private int player1Score;
    private int player2Score;

    public int Player1Score
    {
        get { return player1Score; }
        private set
        {
            player1Score = value;
            Debug.Log("Player 1 Score updated to: " + player1Score);
            Player1ScoreChanged?.Invoke(player1Score);
        }
    }

    public int Player2Score
    {
        get { return player2Score; }
        private set
        {
            player2Score = value;
            Debug.Log("Player 2 Score updated to: " + player2Score);
            Player2ScoreChanged?.Invoke(player2Score);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to update Player 1's score
    public void OnPlayer1Pickup(int points)
    {
        Player1Score += points;
    }

    // Method to update Player 2's score
    public void OnPlayer2Pickup(int points)
    {
        Player2Score += points;
    }

    /// Code Review by Dev B 
    // Since there’s already a public property (CurrentScore), having an additional GetScore() method is redundant.
    // It’s better to keep just the property to reduce confusion and maintain a single way of accessing the score.

    // Add null-checks before invoking the event to prevent potential runtime errors if there are no subscribers.
    // While the use of events is good, consider whether to make them public.
    // If the event is intended to be consumed only internally (e.g., by the UIManager), consider making it protected or private.

    // Add Unit Tests: If possible, add unit tests to verify the behavior of OnPickup(int points) and event invocation.
    // Consider Making CurrentScore Observable: Using C# properties with backing fields can make score changes more observable:

    // Overall, The ScoreKeeper class is well-written and functional but could benefit from improved validation, more detailed documentation, and better event handling.
    // With a few minor improvements, it will be robust and scalable.
}

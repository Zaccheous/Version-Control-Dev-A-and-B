using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper: MonoBehaviour
{
    public static ScoreKeeper Instance { get; private set; }
    public event Action<int> ScoreChanged;

    private int currentScore;

    public int CurrentScore
    {
        get { return currentScore; }
        private set
        {
            currentScore = value;
            ScoreChanged?.Invoke(currentScore);
            // Add null-checks before invoking the event to prevent potential runtime errors if there are no subscribers.
            // While the use of events is good, consider whether to make them public.
            // If the event is intended to be consumed only internally (e.g., by the UIManager), consider making it protected or private.
        }

        // Add Unit Tests: If possible, add unit tests to verify the behavior of OnPickup(int points) and event invocation.
        // Consider Making CurrentScore Observable: Using C# properties with backing fields can make score changes more observable:
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

    public void OnPickup(int points)
    {
        CurrentScore += points;
    }

    // New GetScore() method
    public int GetScore()
    {
        return CurrentScore;
    }

    // Since there’s already a public property (CurrentScore), having an additional GetScore() method is redundant.
    // It’s better to keep just the property to reduce confusion and maintain a single way of accessing the score.

    // Overall, The ScoreKeeper class is well-written and functional but could benefit from improved validation, more detailed documentation, and better event handling.
    // With a few minor improvements, it will be robust and scalable.
}

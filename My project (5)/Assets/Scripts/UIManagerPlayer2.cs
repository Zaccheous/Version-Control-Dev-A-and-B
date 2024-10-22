using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagerPlayer2 : MonoBehaviour
{
    public static UIManagerPlayer2 Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI player2ScoreText;

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


    // Update Player 1's score in the UI
    void Update()
    {
        player2ScoreText.text = "Player 2 Score: " + ScoreKeeper.Instance.Player2Score;
    }

}

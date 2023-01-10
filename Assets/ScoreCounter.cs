using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int score;
    private TextMeshPro scoreboard;
    void Start()
    {
        score = 0;
        scoreboard = GetComponent<TextMeshPro>();
        scoreboard.SetText(score.ToString());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Barrier")
        {
            score++;
            scoreboard.SetText(score.ToString());
        }
    }
}

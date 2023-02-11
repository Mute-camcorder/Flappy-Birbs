using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Barrier barrierPrefab;
    private int barrierSpawnDelay = 4;
    private float timer = 0.0f;
    private int score;
    private TextMeshPro scoreboard;

    void Start()
    {
        score = 0;
        scoreboard = GetComponent<TextMeshPro>();
        scoreboard.SetText(score.ToString());
        timer = float.MaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= barrierSpawnDelay)
        {
            SpawnBarrier();
            timer = 0.0f;
        } else
        {
            timer += Time.deltaTime;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Restart();
    }

    [ContextMenu("Restart")]
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrier"))
        {
            IncrementScore();
        }
    }

    [ContextMenu("SpawnBarrier")]
    private void SpawnBarrier()
    {
        Instantiate(
                barrierPrefab,
                position: new Vector3(-11, 0, 0),
                rotation: Quaternion.identity
        );
    }

    [ContextMenu("IncrementScore")]
    private void IncrementScore()
    {
        score++;
        scoreboard.SetText(score.ToString());
    }
}

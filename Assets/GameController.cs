using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Barrier barrierPrefab;
    public GameObject gameOverScreen;
    private bool isPlaying = true;
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

    void Update()
    {
        if (timer >= barrierSpawnDelay && isPlaying)
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
        isPlaying = false;
        var movingBarriers = GameObject.FindGameObjectsWithTag("BarrierFloating");
        movingBarriers.ToList<GameObject>().ForEach(
            go => go.GetComponent<Rigidbody2D>().simulated = false
        );

        gameOverScreen.SetActive(true);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> obstacles;
    public GameObject healthPrefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI gameOverText;
    private int score;
    private int damage;
    private int lives;
    private float spawnInterval = 1.5f;
    private float healthSpawnInterval;
    public bool isGameActive;
    public Button restartButton;
    public GameObject player;
    public GameObject titleScreen;


    // Starts game 
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnObstacle());
        spawnInterval /= difficulty;
        StartCoroutine(SpawnHealth());
        score = 0;
        lives = 3;
        UpdateScore(0);
        UpdateLives(0);
        player.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }

    //Stops game if player runs out of lives
    private void Update()
    {
        if(lives == -1)
        {
            GameOver();
        }
    }

    //Spawns random obstacles at a set interval
    IEnumerator SpawnObstacle()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[index]);
        }
    }

    //Spawns a health object every 25 seconds
    IEnumerator SpawnHealth()
    {
        while (isGameActive)
        {
            healthSpawnInterval = 25f;
            yield return new WaitForSeconds(healthSpawnInterval);
            Instantiate(healthPrefab);
        }
    }

    //Updates the score on screen
    public void UpdateScore(int scoreToAdd)
    {
        scoreText.text = "Score: " + score;
        score += scoreToAdd;
    }

    //Updates health on screen
    public void UpdateLives(int lifeMod)
    {
        lifeText.text = "Lives: " + lives;
        lives += lifeMod;
        Debug.Log("Updated health by" + lifeMod);
    }

    //Game ends and restart option shows up
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        Destroy(GameObject.Find("Player"));
        restartButton.gameObject.SetActive(true);
    }

    //Restarts the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
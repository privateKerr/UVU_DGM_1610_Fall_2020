using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject>targets;
    private float spawnRate = 1;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;
    private int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    //Spawns random targets at a set rate
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    //Updates score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }

    //Game over text and restart button appear when game is over
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
    }

    //Loads active scene to restart game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        //Starts coroutine to start spawning targets
        StartCoroutine(SpawnTarget());

        //Makes difficulty harder based on button pressed
        spawnRate /= difficulty;

        //Sets score as 0 on screen at start of game
        score = 0;
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }
}

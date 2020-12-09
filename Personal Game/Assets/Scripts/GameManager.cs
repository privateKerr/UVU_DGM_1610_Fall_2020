using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> obstacles;
    public GameObject healthPrefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    private int score;
    private int damage;
    public int lives;
    private float spawnInterval;
    private float healthSpawnInterval;
    public bool isGameActive;


    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnObstacle());
        StartCoroutine(SpawnHealth());
        score = 0;
        lives = 3;
        UpdateScore(0);
        UpdateLives(0);
    }


    IEnumerator SpawnObstacle()
    {
        while (isGameActive)
        {
            spawnInterval = Random.Range(1f, 2f);
            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[index]);
        }
    }

    IEnumerator SpawnHealth()
    {
        while (isGameActive)
        {
            healthSpawnInterval = 25f;
            yield return new WaitForSeconds(healthSpawnInterval);
            Instantiate(healthPrefab);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        scoreText.text = "Score: " + score;
        score += scoreToAdd;
    }

    public void UpdateLives(int lifeMod)
    {
        lifeText.text = "Lives: " + lives;
        lives += lifeMod;
        Debug.Log("Updated health by" + lifeMod);
    }

}

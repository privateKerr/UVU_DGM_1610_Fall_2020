using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> obstacles;
    public GameObject healthPrefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    private int score;
    private int damage;
    private int health;
    private float spawnInterval;
    public bool isGameActive;


    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnObstacle());
        score = 0;
        health = 100;
        UpdateScore(0);
        UpdateHealth(100);
    }


    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            spawnInterval = Random.Range(1f, 2f);
            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[index]);
        }
    }

    IEnumerator SpawnHealth()
    {
        yield return new WaitForSeconds(25);
    }

    public void UpdateScore(int scoreToAdd)
    {
        scoreText.text = "Score: " + score;
        score += scoreToAdd;
    }

    public void UpdateHealth(int healthTotal)
    {
        healthText.text = "Health: " + health;
        health -= healthTotal;
    }

}

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
    private int health;
    private float spawnInterval;
    public bool isGameActive;


    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnObstacle());
        UpdateScore(0);
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

    void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    void UpdateHealth(int healthTotal)
    {
        health += healthTotal;
    }

}

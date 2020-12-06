using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject>targets;
    private float spawnRate = 1;
    public TextMeshProUGUI scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        //Starts coroutine to start spawning targets
        StartCoroutine(SpawnTarget());

        //Sets score as 0 on screen at start of game
        score = 0;
        UpdateScore(0);
    }

    //Spawns random targets at a set rate
    IEnumerator SpawnTarget()
    {
        while (true)
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
}

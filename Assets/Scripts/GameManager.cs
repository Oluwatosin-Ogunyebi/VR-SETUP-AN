using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    private float timer = 0;
    private bool isGameRunning = false;

    public GameObject[] foodItems;
    public BoxCollider foodSpawnArea;
    public float gameTime = 60;
    public TMP_Text scoreText;
    public TMP_Text timerText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //StartGame();
        timerText.text = "Timer: " + getTime();
    }

    public bool checkIsGameRunning()
    {
        return isGameRunning;
    }

    public int getScore()
    {
        return score;
    }

    public int getTime()
    {
        return Mathf.FloorToInt(timer);
    }
    //AddSScore
    public void AddScore()
    {
        score++;
    }
    //Spawn Food Items
    public void SpawnFoodItem()
    {
        int randomValue = Random.Range(0, foodItems.Length);
        GameObject randomFoodItem = foodItems[randomValue];

        float x = Random.Range(foodSpawnArea.bounds.min.x, foodSpawnArea.bounds.max.x);
        float y = Random.Range(foodSpawnArea.bounds.min.y, foodSpawnArea.bounds.max.y);
        float z = Random.Range(foodSpawnArea.bounds.min.z, foodSpawnArea.bounds.max.z);

        Vector3 randomPosition = new Vector3(x, y, z);

        Instantiate(randomFoodItem, randomPosition, Quaternion.identity);
    }

    // Restart or Start Game 
    public void StartGame()
    {
        timer = gameTime;
        isGameRunning = true;
    }
    void GameOver()
    {
        isGameRunning = false;
    }

    private void Update()
    {
        if (timer > 0 && isGameRunning)
        {
            timer -= Time.deltaTime;
            timerText.text = "Timer: " + getTime();
            Debug.LogWarning(timer);
        }
        else
        {
            GameOver();
        }
    }
}

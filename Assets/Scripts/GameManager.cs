using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseOverlay;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject TitleUI;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int maxHealth;
    int currentHealth;
    [SerializeField] List<Image> health;
    [SerializeField] GameObject ballPrefab;
    public float score { get; private set; }

    float spawnTimer;
    [SerializeField]float spawnTime;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            GameOver();
        }

        spawnTimer += Time.deltaTime;

        if(spawnTimer > spawnTime)
        {
            AddBall();
            spawnTimer = 0;
        }
        score += Time.deltaTime;
    }

    public void LoseHealth()
    {
        currentHealth--;
        Debug.Log(currentHealth);
    }

    void PauseGame()
    {
        pauseOverlay.SetActive(true);
        pauseUI.SetActive(true);
    }

    void GameOver()
    {
        pauseOverlay.SetActive(true);
        gameOverUI.SetActive(true);
    }

    void AddBall()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position,Quaternion.identity);
        if(ball.TryGetComponent<ballBehavior>(out ballBehavior newBall))
        {
            newBall.ballDropped.AddListener(LoseHealth);
        }
    }
}

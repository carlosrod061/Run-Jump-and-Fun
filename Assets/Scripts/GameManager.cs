using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class GameManager : MonoBehaviour
{
    //CREADO POR CARLOS RODRIGUEZ - GDGS1101-E
    public bool isGameActive;
    private float spawnRate = 1.0f;
    private int score = 0;
    private int time = 60;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI levelCompleteText;
    public List<GameObject> targets;
    public Button restartButton;
    public Button playAgainButton;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score:" + score;
        timerText.text = "Time Left:" + time;
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        time = 60;

        StartCoroutine(SpawnTarget());
        StartCoroutine(Timer());
        UpdateScore(0);
        UpdateTimer(0);
        titleScreen.gameObject.SetActive(false);
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            int positionZ = Random.Range(-7, 7);
            Instantiate(targets[index], new Vector3(40, 0, positionZ), targets[index].transform.rotation);
        }
    }

    IEnumerator Timer()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            UpdateTimer(1);
        }
    }
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void GameSuccess()
    {
        isGameActive = false;
        levelCompleteText.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    public void UpdateTimer(int timeToReduce)
    {
        if (time == 0)
        {
            GameSuccess();
        }
        else
        {
            time -= timeToReduce;
            timerText.text = "Time Left:" + time;
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}

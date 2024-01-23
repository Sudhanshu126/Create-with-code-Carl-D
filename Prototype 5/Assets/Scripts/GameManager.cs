using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    private float spawnRate = 1f;
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText, livesText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    public bool isGameActive;
    [SerializeField] private GameObject titleScreen;
    public static int life;
    private AudioSource audioSource;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject pauseMenu, mouseTrail;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        SetAudioVolume(slider.value);
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = Time.timeScale == 0f ? 1f : 0f;
            pauseMenu.SetActive(Time.timeScale == 0 ? true : false);
        }
    }

    public void StartGame(int difficulty)
    {
        gameOverText.gameObject.SetActive(false);
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        life = 3;
        titleScreen.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(targets[Random.Range(0, targets.Count)]);
            spawnRate += 0.1f;
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLife()
    {
        livesText.text = "Lives: " + life;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        titleScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SetAudioVolume(float volume)
    {
        audioSource.volume = volume;
    }
}

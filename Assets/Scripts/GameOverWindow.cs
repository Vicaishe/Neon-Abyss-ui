using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    public GameObject gameOverPanel;
    int check = 0;

    void Update()
    {
        if (check == 0)
        { 
            if (GameObject.FindWithTag("Player") == null)
            {
                PlayerDied();
                check = 1;
            }
        }
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void PlayerDied()
    {
        Invoke("GameOverCanvas", 2f);
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("script for restart");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ReturnToMenu()
    {
        Debug.Log("script for load menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("hub");
    }
}


/*public GameObject gameOverWindowPrefab;
public Transform player;
public GameObject gameOverUI;

private void Awake()
{
    player = GameObject.FindWithTag("Player").transform;
}

private void Start()
{
    // Запускаем таймер на 2 секунды
    Invoke("ShowGameOverWindow", 2f);
}

private void ShowGameOverWindow()
{
    // Создаем экземпляр префаба окна проигрыша
    GameObject gameOverWindow = Instantiate(gameOverWindowPrefab, transform);

    // Получаем ссылки на кнопки в окне проигрыша
    Button restartButton = gameOverWindow.transform.Find("RestartButton").GetComponent<Button>();
    Button menuButton = gameOverWindow.transform.Find("MenuButton").GetComponent<Button>();

    // Добавляем обработчики событий на кнопки
    restartButton.onClick.AddListener(Restart);
    menuButton.onClick.AddListener(LoadMenu);
    *//*
            // Получаем ссылку на текстовое поле для отображения количества собранных звезд
            Text starsText = gameOverWindow.transform.Find("StarsText").GetComponent<Text>();

            // Получаем количество собранных звезд на уровне
            int starsCount = player.starsCurrent;

            // Отображаем количество собранных звезд на уровне в текстовом поле
            starsText.text = "Собрано звезд: " + starsCount.ToString();*//*
}

void Pause()
{
    gameOverUI.SetActive(true);
    Time.timeScale = 0f;
}

public void Restart()
{
    Debug.Log("script for restart");
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Time.timeScale = 1f;
}

public void LoadMenu()
{
    Debug.Log("script for load menu");
    Time.timeScale = 1f;
    SceneManager.LoadScene("hub");
}*/
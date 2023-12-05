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
    // ��������� ������ �� 2 �������
    Invoke("ShowGameOverWindow", 2f);
}

private void ShowGameOverWindow()
{
    // ������� ��������� ������� ���� ���������
    GameObject gameOverWindow = Instantiate(gameOverWindowPrefab, transform);

    // �������� ������ �� ������ � ���� ���������
    Button restartButton = gameOverWindow.transform.Find("RestartButton").GetComponent<Button>();
    Button menuButton = gameOverWindow.transform.Find("MenuButton").GetComponent<Button>();

    // ��������� ����������� ������� �� ������
    restartButton.onClick.AddListener(Restart);
    menuButton.onClick.AddListener(LoadMenu);
    *//*
            // �������� ������ �� ��������� ���� ��� ����������� ���������� ��������� �����
            Text starsText = gameOverWindow.transform.Find("StarsText").GetComponent<Text>();

            // �������� ���������� ��������� ����� �� ������
            int starsCount = player.starsCurrent;

            // ���������� ���������� ��������� ����� �� ������ � ��������� ����
            starsText.text = "������� �����: " + starsCount.ToString();*//*
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
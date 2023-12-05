using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject buttonSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Instantiate(buttonSound, transform.position, Quaternion.identity);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Restart()
    {
        Instantiate(buttonSound, transform.position, Quaternion.identity);
        Debug.Log("script for restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void LoadMenu()
    {
        Instantiate(buttonSound, transform.position, Quaternion.identity);
        Debug.Log("script for load menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("hub");
    }
    public void QuitGame()
    {
        Instantiate(buttonSound, transform.position, Quaternion.identity);
        Debug.Log("script for quiting");
        Application.Quit();
    }
}

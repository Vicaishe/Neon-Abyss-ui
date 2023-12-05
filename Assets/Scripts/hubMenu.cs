using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hubMenu : MonoBehaviour
{
    public GameObject buttonSound;
    //public LoadSceneOnClick levelLoader;
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadLevelButton()
    {
        Instantiate(buttonSound, transform.position, Quaternion.identity);
        Debug.Log("script for load level");
        //Time.timeScale = 1f;
        //SceneManager.LoadScene("SampleScene");
        //levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex - 1);
        //StartCoroutine(LoadSceneWithTransition("SampleScene"));
        LoadNextLevelExtra();
    }
    public void QuitGame()
    {
        Instantiate(buttonSound, transform.position, Quaternion.identity);
        Debug.Log("script for quiting");
        Application.Quit();
    }
    private IEnumerator LoadSceneWithTransition(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevelExtra()
    {
        StartCoroutine(LoadLevelExtra(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevelExtra(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}

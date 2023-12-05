using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject buttonSound;
    public void OnClick()
    {
        Instantiate(buttonSound, transform.position, Quaternion.identity);
        Debug.Log("script for load menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}

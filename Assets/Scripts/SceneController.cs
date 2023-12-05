using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject[] characters;

    private void Start()
    {
        characters = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject character in characters)
            {
                SelectCharacterOnClick controller = character.GetComponent<SelectCharacterOnClick>();
                if (controller.isSelected)
                {
                    PlayerPrefs.SetString("SelectedCharacter", character.name);
                    SceneManager.LoadScene("GameScene");
                }
            }
        }
    }
}

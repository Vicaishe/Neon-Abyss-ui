using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacterOnClick : MonoBehaviour
{
    public bool isSelected = false;
    public GameObject effect;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "hub")
        {
            // Выключаем скрипты, которые не нужны на сцене меню
            GetComponent<RotateToTarget>().enabled = false;
            GetComponent<MoveToMouse>().enabled = false;
            GetComponent<Player>().enabled = false;
            GetComponent<RandomMovement>().enabled = true;
            GetComponent<RotateRandom>().enabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "Sample Scene")
        {
            // Включаем скрипты, которые нужны на основной игровой сцене
            GetComponent<RotateToTarget>().enabled = true;
            GetComponent<MoveToMouse>().enabled = true;
            GetComponent<Player>().enabled = true;
            GetComponent<RandomMovement>().enabled = false;
            GetComponent<RotateRandom>().enabled = false;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDown()
    {
        isSelected = true;
        PlayerPrefs.SetString("SelectedCharacter", gameObject.name);
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}


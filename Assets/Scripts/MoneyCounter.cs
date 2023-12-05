using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    public Text starsText;
    public int AllStars;
    private void Awake()
    {
        starsText = GetComponent<Text>();
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("AllStars"))
        {
            AllStars = PlayerPrefs.GetInt("AllStars");
        }
        else
        {
            AllStars = 0;
            PlayerPrefs.SetInt("AllStars", AllStars);
        }
    }

    private void Update()
    {
        AllStars = PlayerPrefs.GetInt("AllStars");
        starsText.text = AllStars.ToString();
    }
}

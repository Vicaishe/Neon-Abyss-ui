using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPlayer : MonoBehaviour
{
    public Text healthDisplay;
    public Text starsDisplay;
    public Text starsDisplayTotal;
    public GameObject player;
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        Player player = GetComponent<Player>();
    }

    void Update()
    {

    }
}

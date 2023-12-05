using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class StarCollect : MonoBehaviour
{
    private int stars = 0;
    public int AllStars;

    public GameObject effect;
    //public GameObject player;
    //[SerializeField] private Text StarText;

    void Start()
    {
        if (PlayerPrefs.HasKey("AllStars"))
        {
            AllStars = PlayerPrefs.GetInt("AllStars");
        }
        else
        {
            AllStars = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            AllStars += 1;

            PlayerPrefs.SetInt("AllStars", AllStars);
            PlayerPrefs.Save();

            Debug.Log("Stars: " +  AllStars);
            //StarText.text = " " + stars;
        }
    }
}

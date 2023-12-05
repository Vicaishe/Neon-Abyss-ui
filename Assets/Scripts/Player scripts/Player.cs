using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health;
    public int starsCurrent;
    public GameObject effect;
    public Text healthDisplay;
    public Text starsDisplay;
    public Text starsDisplayTotal;

    public GameObject gameOver;
    public GameObject starSound;
    public GameObject obstacleSound;
    public GameObject dieSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            starsCurrent += 1;
            Instantiate(starSound, transform.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(obstacleSound, transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        starsDisplay.text = starsCurrent.ToString();
        healthDisplay.text = health.ToString();
        if (health <= 0)
        {
            Instantiate(dieSound, transform.position, Quaternion.identity);
            gameOver.SetActive(true);
            healthDisplay.text = "";
            starsDisplay.text = "";
            starsDisplayTotal.text = "stars " + starsCurrent.ToString();
            Instantiate(effect, transform.position, Quaternion.identity);
            //PlayerDied();
            Destroy(gameObject);
        }
    }
    public int GetStars()
    {
        return starsCurrent;
    }
    public int GetHP()
    {
        return health;
    }
}

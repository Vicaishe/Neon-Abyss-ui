using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float speed;
    public float distanceThreshold;

    private void Update()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        GameObject character = GameObject.Find(selectedCharacter);

        if (character == null)
        {
            Debug.LogError("Selected character not found!");
            return;
        }

        float distance = Mathf.Abs(transform.position.x - character.transform.position.x);

        if (distance >= distanceThreshold)
        {
            float targetX = character.transform.position.x;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime * 2f);
        }
        else
        {
            float targetX = character.transform.position.x;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        GameObject character = GameObject.Find(selectedCharacter);

        if (character == null)
        {
            Debug.LogError("Selected character not found!");
            return;
        }

        if (other.gameObject == character)
        {
            float targetX = transform.position.x - distanceThreshold;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        GameObject character = GameObject.Find(selectedCharacter);

        if (character == null)
        {
            Debug.LogError("Selected character not found!");
            return;
        }

        if (other.gameObject == character)
        {
            float targetX = transform.position.x + distanceThreshold;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }
}

/*public Transform player;
public float speed;
public float distanceThreshold;

private void Awake()
{
    GameObject player = GameObject.FindWithTag("Player");
}

private void Update()
{
    float distance = Mathf.Abs(transform.position.x - player.position.x);

    if (distance >= distanceThreshold)
    {
        float targetX = player.position.x;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime * 2f);
    }
    else if (distance < distanceThreshold)
    {
        float targetX = player.position.x;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime);
        *//*           float targetX = player.position.x;
                   transform.position = new Vector3(targetX - distanceThreshold + 1, transform.position.y, transform.position.z);*//*
        // transform.position.x = player.position.x - distanceThreshold;
    }
}*/
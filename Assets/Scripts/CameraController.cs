using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void SetCameraTarget()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");

        foreach (GameObject character in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (character != null && character.name == selectedCharacter)
            {
                player = character;
                break;
            }
        }

        if (player != null)
        {
            CinemachineVirtualCamera virtualCamera = GetComponent<CinemachineVirtualCamera>();
            virtualCamera.Follow = player.transform;
        }
        else
        {
            Debug.LogError("Character not found: " + selectedCharacter);
        }
    }
}


/*public string characterName;

private void Start()
{
    GameObject character = GameObject.Find(characterName);

    if (character != null)
    {
        CinemachineVirtualCamera virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = character.transform;
    }
    else
    {
        Debug.LogError("Character not found: " + characterName);
    }
}*/
using UnityEngine;
using Cinemachine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject[] characters;
    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        bool foundCharacter = false;

        foreach (GameObject character in characters)
        {
            if (character != null && character.name == selectedCharacter)
            {
                character.SetActive(true);
                foundCharacter = true;

                if (virtualCamera != null)
                {
                    virtualCamera.Follow = character.transform;
                }
            }
            else
            {
                if (character != null)
                {
                    character.SetActive(false);
                }
            }
        }

        if (!foundCharacter)
        {
            Debug.LogError("Selected character not found!");
        }

        CameraController cameraController = FindObjectOfType<CameraController>();
        if (cameraController != null)
        {
            cameraController.SetCameraTarget();
        }
    }
}
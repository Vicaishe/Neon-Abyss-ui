using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameGenerator : MonoBehaviour
{
    private const float playerSpawnLevelPart = 50f;

    [SerializeField] public Transform FrameStart;
    [SerializeField] private List<Transform> FrameOctoList;
    [SerializeField] private List<Transform> FrameCoralList;
    [SerializeField] private List<Transform> FrameCrystalList;
    [SerializeField] private List<Transform> FrameBoulderList;
    //[SerializeField] private GameObject player;

    public int vectorX;
    private Vector3 lastEndPosition;
    public int firstSpawn;
    private int levelFramesSpawned;
    private enum Location
    { Octo = 0, Coral = 1, Crystal = 2, Boulder = 3, }
    private void Awake()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        GameObject player = GameObject.Find(selectedCharacter);
        lastEndPosition = FrameStart.Find("EndPosition").position;
        for (int i = 0; i < firstSpawn; i++)
        {
            SpawnLevelPart();
        }
    }
    private void Update()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        GameObject player = GameObject.Find(selectedCharacter);
        if (Vector3.Distance(player.transform.position, lastEndPosition) < playerSpawnLevelPart){ SpawnLevelPart(); }
    }
    private void SpawnLevelPart()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");
        GameObject player = GameObject.Find(selectedCharacter);
        Transform choseFrame;
        List<Transform> loca = GetLocation();
        choseFrame = loca[Random.Range(0, loca.Count)];
        if (levelFramesSpawned > 6)
        {
            levelFramesSpawned = 0;
        }
        Transform lastLevelPartTransform = SpawnLevelPart(choseFrame, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        levelFramesSpawned++;
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }
    private Transform SpawnLevelPart(Transform Frame, Vector3 spawnPosition)
    {
        levelFramesSpawned = 0;
        Transform levelPartTransform = Instantiate(Frame, spawnPosition + new Vector3(vectorX, 0), Quaternion.identity);
        return levelPartTransform;
    }
    private List<Transform> GetLocation()
    {
        int rnd = Random.Range(0, 4);
        if (rnd == 0) return FrameOctoList;
        if (rnd == 1) return FrameCoralList;
        if (rnd == 2) return FrameCrystalList;
        if (rnd == 3) return FrameBoulderList;
        else return FrameCoralList;
    }
}

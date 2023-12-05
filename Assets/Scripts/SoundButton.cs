using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public GameObject sound;
    private void OnMouseDown()
    {
        Instantiate(sound, transform.position, Quaternion.identity);
    }
 }

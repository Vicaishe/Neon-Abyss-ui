using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    private float delay = 30f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Kill", delay);
    }

    // Update is called once per frame
    void Kill()
    {
        Destroy(gameObject);
    }
}

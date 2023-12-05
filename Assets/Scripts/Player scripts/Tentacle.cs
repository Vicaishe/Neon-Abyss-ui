using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public int lenght;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;
    public int numSegmentPoses;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;

    public float trailSpeed;

    void Start()
    {
        lineRend.positionCount = lenght;
        segmentPoses = new Vector3[lenght];
        segmentV= new Vector3[lenght];
    }

    void Update()
    {
        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < numSegmentPoses; i++)
        {
              segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }

        /*for (int i = 1; i < segmentPoses.Lenght; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }*/

        lineRend.SetPositions(segmentPoses);
    }
}

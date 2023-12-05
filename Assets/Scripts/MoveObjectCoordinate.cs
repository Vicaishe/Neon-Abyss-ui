using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectCoordinate : MonoBehaviour
{
    public Transform[] waypoints; // ������ �����, �� ������� ����� ������������ ������
    public float speed = 5f; // �������� ����������� �������

    private int currentWaypointIndex = 0; // ������ ������� �����
    private void Update()
    {
        // ���������, ������ �� ������ ������� ����� � ��������� ���������� �������
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) <= 0.1f)
        {
            // ���� ������, ����������� ������ ������� �����
            currentWaypointIndex++;

            // ���� ������ ������� �� ������� �������, ���������� ��� � ������
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        // ��������� ����������� � ��������� �����
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;

        // ����������� �����������, ����� �������� ������ ��������� �����
        direction.Normalize();

        // ���������� ������ � ����������� ��������� ����� � �������� ���������
        transform.Translate(direction * speed * Time.deltaTime);
    }
}

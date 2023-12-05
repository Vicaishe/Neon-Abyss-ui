using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandom : MonoBehaviour
{
    public float rotationSpeed;
    private Vector2 direction;
    private Vector3 lastDirection; // ���������� ��� ���������� ���������� ����������� ��������
    private Vector3 currentPosition; // ���������� ��� ���������� ������� ������� �������
    private bool isMoving; // ����, ����������� �� ��, �������� �� ������

    void Start()
    {
        currentPosition = transform.position; // ��������� ��������� ������� �������
        isMoving = false;
    }

    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // ���������, �������� �� ������
        if (currentPosition != transform.position)
        {
            isMoving = true;
            lastDirection = (transform.position - currentPosition).normalized; // ��������� ����������� ��������
        }
        else
        {
            isMoving = false;
        }

        // ��������� ������� ������� �������
        currentPosition = transform.position;

        if (lastDirection != Vector3.zero)
        { // ���� ���� ����������� ����������� ��������
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(lastDirection.y, lastDirection.x) * Mathf.Rad2Deg, Vector3.forward); // ������������ ������ � ������� ���������� ��������
        }
    }
}

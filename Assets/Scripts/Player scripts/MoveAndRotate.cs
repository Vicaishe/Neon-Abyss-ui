using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
        public float rotationSpeed;
        private Vector2 direction;
        private Vector3 lastDirection; // ���������� ��� ���������� ���������� ����������� ��������
        private Vector3 currentPosition; // ���������� ��� ���������� ������� ������� �������
        private bool isMoving; // ����, ����������� �� ��, �������� �� ������

        // Start is called before the first frame update
        void Start()
        {
            currentPosition = transform.position; // ��������� ��������� ������� �������
            isMoving = false;
        }

        // Update is called once per frame
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
        }

        private void LateUpdate()
        { // ���������� LateUpdate ��� ���� ����� ������� ���������� ����� ����������� �������
            if (!isMoving)
            { // ���� ������ �����������
                if (lastDirection != Vector3.zero)
                { // ���� ���� ����������� ����������� ��������
                    transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(lastDirection.y, lastDirection.x) * Mathf.Rad2Deg, Vector3.forward); // ������������ ������ � ������� ���������� ��������
                }
            }
        }

        public void RotateTowards(Vector3 direction)
        {
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }


}

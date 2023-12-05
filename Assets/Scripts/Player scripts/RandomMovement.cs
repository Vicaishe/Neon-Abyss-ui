using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

        public float speed = 2f; // �������� �������� ���������
        public float acceleration = 0.1f; // ��������� �������� ���������
        public float maxSpeed = 5f; // ������������ �������� �������� ���������
        public float minPauseTime = 1f; // ����������� ����� ��������� ���������
        public float maxPauseTime = 3f; // ������������ ����� ��������� ���������
        private Vector2 destination; // ���������� �����, ���� ������ ������������� ��������
        private bool isMoving = true; // ����, ����������� �� ��, ��������� �� �������� � ������ ������
        private float currentSpeed = 0f; // ������� �������� �������� ���������
        private float currentPauseTime = 0f; // ������� ����� ��������� ���������

        void Start()
        {
            // ������ ��������� ����� ����������� ���������
            SetDestination();
        }

        void Update()
        {
            if (isMoving)
            {
                // ��������� ���������� �� ����� ����������
                float distance = Vector2.Distance(transform.position, destination);
                if (distance <= 0.1f)
                {
                    // ���� �������� ������ ����� ����������, �� ������������� ��� �� ��������� �����
                    isMoving = false;
                    currentPauseTime = Random.Range(minPauseTime, maxPauseTime);
                    currentSpeed = 0f;
                }
                else
                {
                    // ����� ���������� �������� � ������� ����� ����������
                    Vector2 direction = (destination - (Vector2)transform.position).normalized;
                    currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
                    transform.position += (Vector3)(direction * currentSpeed * Time.deltaTime);

                    // ������������ ��������� � ������� ��������
                    transform.LookAt(transform.position + new Vector3(0f, 0f, 0f));
                }
            }
            else
            {
                // ���� �������� ����������, �� ��������� ����� ���������
                currentPauseTime -= Time.deltaTime;
                if (currentPauseTime <= 0f)
                {
                    // ���� ����� ��������� �������, �� ������ ����� ����� ����������� � ���������� ��������
                    SetDestination();
                    isMoving = true;
                }
                else
                {
                    // ����� ������ ��������� �������� �� ����
                    currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime * 5f);
                    transform.position += (Vector3)(Vector2.right * currentSpeed * Time.deltaTime);

                    // ������������ ��������� � ������� ��������
                    Vector2 direction = (destination - (Vector2)transform.position).normalized;
                    transform.LookAt(transform.position + new Vector3(0, 0, 0));
                }
            }
        }

        void SetDestination()
        {
            // ������ ����� ��������� ����� � ������������� ����
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-3f, 3f);
            destination = new Vector2(x, y);
        }

      /*  public float speed = 2f; // �������� �������� ���������
        public float acceleration = 0.1f; // ��������� �������� ���������
        public float maxSpeed = 5f; // ������������ �������� �������� ���������
        public float minPauseTime = 1f; // ����������� ����� ��������� ���������
        public float maxPauseTime = 3f; // ������������ ����� ��������� ���������
        private Vector2 destination; // ���������� �����, ���� ������ ������������� ��������
        private bool isMoving = true; // ����, ����������� �� ��, ��������� �� �������� � ������ ������
        private float currentSpeed = 0f; // ������� �������� �������� ���������
        private float currentPauseTime = 0f; // ������� ����� ��������� ���������

        void Start()
        {
            // ������ ��������� ����� ����������� ���������
            SetDestination();
        }

        void Update()
        {
            if (isMoving)
            {
                // ��������� ���������� �� ����� ����������
                float distance = Vector2.Distance(transform.position, destination);
                if (distance <= 0.1f)
                {
                    // ���� �������� ������ ����� ����������, �� ������������� ��� �� ��������� �����
                    isMoving = false;
                    currentPauseTime = Random.Range(minPauseTime, maxPauseTime);
                    currentSpeed = 0f;
                }
                else
                {
                    // ����� ���������� �������� � ������� ����� ����������
                    Vector2 direction = (destination - (Vector2)transform.position).normalized;
                    currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
                    transform.position += (Vector3)(direction * currentSpeed * Time.deltaTime);
                }
            }
            else
            {
                // ���� �������� ����������, �� ��������� ����� ���������
                currentPauseTime -= Time.deltaTime;
                if (currentPauseTime <= 0f)
                {
                    // ���� ����� ��������� �������, �� ������ ����� ����� ����������� � ���������� ��������
                    SetDestination();
                    isMoving = true;
                }
                else
                {
                    // ����� ������ ��������� �������� �� ����
                    currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime * 5f);
                    transform.position += (Vector3)(Vector2.right * currentSpeed * Time.deltaTime);
                }
            }
        }

        void SetDestination()
        {
            // ������ ����� ��������� ����� � ������������� ����
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-3f, 3f);
            destination = new Vector2(x, y);
        }

*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

        public float speed = 2f; // Скорость движения персонажа
        public float acceleration = 0.1f; // Ускорение движения персонажа
        public float maxSpeed = 5f; // Максимальная скорость движения персонажа
        public float minPauseTime = 1f; // Минимальное время остановки персонажа
        public float maxPauseTime = 3f; // Максимальное время остановки персонажа
        private Vector2 destination; // Координаты точки, куда должен переместиться персонаж
        private bool isMoving = true; // Флаг, указывающий на то, двигается ли персонаж в данный момент
        private float currentSpeed = 0f; // Текущая скорость движения персонажа
        private float currentPauseTime = 0f; // Текущее время остановки персонажа

        void Start()
        {
            // Задаем начальную точку перемещения персонажа
            SetDestination();
        }

        void Update()
        {
            if (isMoving)
            {
                // Вычисляем расстояние до точки назначения
                float distance = Vector2.Distance(transform.position, destination);
                if (distance <= 0.1f)
                {
                    // Если персонаж достиг точки назначения, то останавливаем его на некоторое время
                    isMoving = false;
                    currentPauseTime = Random.Range(minPauseTime, maxPauseTime);
                    currentSpeed = 0f;
                }
                else
                {
                    // Иначе продолжаем движение в сторону точки назначения
                    Vector2 direction = (destination - (Vector2)transform.position).normalized;
                    currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
                    transform.position += (Vector3)(direction * currentSpeed * Time.deltaTime);

                    // Поворачиваем персонажа в сторону движения
                    transform.LookAt(transform.position + new Vector3(0f, 0f, 0f));
                }
            }
            else
            {
                // Если персонаж остановлен, то уменьшаем время остановки
                currentPauseTime -= Time.deltaTime;
                if (currentPauseTime <= 0f)
                {
                    // Если время остановки истекло, то задаем новую точку перемещения и продолжаем движение
                    SetDestination();
                    isMoving = true;
                }
                else
                {
                    // Иначе плавно уменьшаем скорость до нуля
                    currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime * 5f);
                    transform.position += (Vector3)(Vector2.right * currentSpeed * Time.deltaTime);

                    // Поворачиваем персонажа в сторону движения
                    Vector2 direction = (destination - (Vector2)transform.position).normalized;
                    transform.LookAt(transform.position + new Vector3(0, 0, 0));
                }
            }
        }

        void SetDestination()
        {
            // Задаем новую случайную точку в прямоугольной зоне
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-3f, 3f);
            destination = new Vector2(x, y);
        }

      /*  public float speed = 2f; // Скорость движения персонажа
        public float acceleration = 0.1f; // Ускорение движения персонажа
        public float maxSpeed = 5f; // Максимальная скорость движения персонажа
        public float minPauseTime = 1f; // Минимальное время остановки персонажа
        public float maxPauseTime = 3f; // Максимальное время остановки персонажа
        private Vector2 destination; // Координаты точки, куда должен переместиться персонаж
        private bool isMoving = true; // Флаг, указывающий на то, двигается ли персонаж в данный момент
        private float currentSpeed = 0f; // Текущая скорость движения персонажа
        private float currentPauseTime = 0f; // Текущее время остановки персонажа

        void Start()
        {
            // Задаем начальную точку перемещения персонажа
            SetDestination();
        }

        void Update()
        {
            if (isMoving)
            {
                // Вычисляем расстояние до точки назначения
                float distance = Vector2.Distance(transform.position, destination);
                if (distance <= 0.1f)
                {
                    // Если персонаж достиг точки назначения, то останавливаем его на некоторое время
                    isMoving = false;
                    currentPauseTime = Random.Range(minPauseTime, maxPauseTime);
                    currentSpeed = 0f;
                }
                else
                {
                    // Иначе продолжаем движение в сторону точки назначения
                    Vector2 direction = (destination - (Vector2)transform.position).normalized;
                    currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
                    transform.position += (Vector3)(direction * currentSpeed * Time.deltaTime);
                }
            }
            else
            {
                // Если персонаж остановлен, то уменьшаем время остановки
                currentPauseTime -= Time.deltaTime;
                if (currentPauseTime <= 0f)
                {
                    // Если время остановки истекло, то задаем новую точку перемещения и продолжаем движение
                    SetDestination();
                    isMoving = true;
                }
                else
                {
                    // Иначе плавно уменьшаем скорость до нуля
                    currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime * 5f);
                    transform.position += (Vector3)(Vector2.right * currentSpeed * Time.deltaTime);
                }
            }
        }

        void SetDestination()
        {
            // Задаем новую случайную точку в прямоугольной зоне
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-3f, 3f);
            destination = new Vector2(x, y);
        }

*/
}

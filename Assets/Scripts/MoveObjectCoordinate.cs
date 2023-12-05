using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectCoordinate : MonoBehaviour
{
    public Transform[] waypoints; // Массив точек, по которым будет перемещаться объект
    public float speed = 5f; // Скорость перемещения объекта

    private int currentWaypointIndex = 0; // Индекс текущей точки
    private void Update()
    {
        // Проверяем, достиг ли объект текущей точки с некоторым допустимым порогом
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) <= 0.1f)
        {
            // Если достиг, увеличиваем индекс текущей точки
            currentWaypointIndex++;

            // Если индекс выходит за пределы массива, возвращаем его в начало
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        // Вычисляем направление к следующей точке
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;

        // Нормализуем направление, чтобы получить вектор единичной длины
        direction.Normalize();

        // Перемещаем объект в направлении следующей точки с заданной скоростью
        transform.Translate(direction * speed * Time.deltaTime);
    }
}

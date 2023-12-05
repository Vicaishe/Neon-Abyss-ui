using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandom : MonoBehaviour
{
    public float rotationSpeed;
    private Vector2 direction;
    private Vector3 lastDirection; // переменная для сохранения последнего направления движения
    private Vector3 currentPosition; // переменная для сохранения текущей позиции объекта
    private bool isMoving; // флаг, указывающий на то, движется ли объект

    void Start()
    {
        currentPosition = transform.position; // сохраняем начальную позицию объекта
        isMoving = false;
    }

    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // проверяем, движется ли объект
        if (currentPosition != transform.position)
        {
            isMoving = true;
            lastDirection = (transform.position - currentPosition).normalized; // сохраняем направление движения
        }
        else
        {
            isMoving = false;
        }

        // сохраняем текущую позицию объекта
        currentPosition = transform.position;

        if (lastDirection != Vector3.zero)
        { // если есть сохраненное направление движения
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(lastDirection.y, lastDirection.x) * Mathf.Rad2Deg, Vector3.forward); // поворачиваем объект в сторону последнего движения
        }
    }
}

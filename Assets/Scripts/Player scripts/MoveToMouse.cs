using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, cursorPos - (Vector2)transform.position, moveSpeed * Time.deltaTime);

        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime);
    }
}
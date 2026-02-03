using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Coroutine : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 5f;
    public float _waitTime = 2f;

    private int currentIndex = 0;
    private bool canMove = true;
    
    void Start()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (canMove == true)
        {
            Transform target = waypoints[currentIndex];

            while (Vector3.Distance(transform.position, target.position) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }

            canMove = false;
            yield return null;
            
        }

        yield return new WaitForSeconds(_waitTime);

        currentIndex++;
        canMove = true;

        if (currentIndex >= waypoints.Length)
        {
            currentIndex = 0;
        }

    }
}

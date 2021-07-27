using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 1f;

    private Transform currentSelectedPoint;

    private void Awake() 
    {
        currentSelectedPoint = pointA;
    }

    private void Update() 
    {
        MoveToPoint(currentSelectedPoint);
    }

    private void MoveToPoint(Transform point)
    {
        Vector2 dir = point.position - transform.position;

        transform.Translate(dir * speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, point.position) < 0.4f)
        {
            ChangePoint();
        }
    }

    private void ChangePoint()
    {
        Debug.Log("true");

        if(currentSelectedPoint == pointA)
            currentSelectedPoint = pointB;
        else
            currentSelectedPoint = pointA;
    }

}

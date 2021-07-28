using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Ball : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] HitsTracker hitsTracker;
    [SerializeField] MMFeedbacks shootFeedback;
    [SerializeField] MMFeedbacks bounceFeedback;

    private LaunchPreview launchPreview;
    private Rigidbody2D rb2d;
    private Vector3 startDragPosition;
    private Vector3 endDragPosition;
    private Vector3 endDirection;
    private bool shooted = false;
    private bool canShootAgain = true;
    private bool ballStopped = true;
    private float dragDistance;

    private int hits = 0;
    public int Hits {get {return hits;} set{hits = value;}}


    private void Awake() 
    {
        launchPreview = GetComponent<LaunchPreview>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
     {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10;

        if(canShootAgain && Hits < hitsTracker.MaxHits && ballStopped)
        {
            if(Input.GetMouseButtonDown(0))
            {
                StartDrag(worldPosition);
            }
            else if(Input.GetMouseButton(0))
            {
                ContinueDrag(worldPosition);
            }
            else if(Input.GetMouseButtonUp(0))
            {
                EndDrag();
            }
        }

        if(BallStopped())
                canShootAgain = true;
            else
                canShootAgain = false;

        ChangeVelocityValue();
    }

    private void FixedUpdate() 
    {
        if(shooted && canShootAgain && Hits < hitsTracker.MaxHits)
        {
            ShootBall(-endDirection);     
        }
    }

    private void ShootBall(Vector3 dir)
    {
        shooted = false;
        Hits++;
        shootFeedback.PlayFeedbacks();
        rb2d.AddForce(dir * moveSpeed * dragDistance);
    }

    private void StartDrag(Vector3 position)
    {
        GetComponent<LineRenderer>().SetWidth(0.15f,0.15f);
        startDragPosition = position;
        launchPreview.SetStartPoint(transform.position);
    }

    private void ContinueDrag(Vector3 position)
    {
        endDragPosition = position;
        Vector3 direction = endDragPosition - startDragPosition;

        launchPreview.SetEndPoint(transform.position - direction);
    }

    private void EndDrag()
    {
        GetComponent<LineRenderer>().SetWidth(0,0);
        endDirection = endDragPosition - startDragPosition;
        endDirection.Normalize();

        dragDistance = Vector2.Distance(endDragPosition,startDragPosition);
        shooted = true;
    }

    private void ChangeVelocityValue()
    {
        if(Mathf.Abs(rb2d.velocity.magnitude) >= 0f)
        {
            if(Mathf.Abs(rb2d.velocity.magnitude) < 0.2f)
            {
                rb2d.velocity = Vector2.zero;
            }
        }        
    }

    public bool BallStopped()
    {
        if(rb2d.velocity == Vector2.zero)
            ballStopped = true;
        else
            ballStopped = false;
        
        return ballStopped;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        bounceFeedback.PlayFeedbacks();
    }

}
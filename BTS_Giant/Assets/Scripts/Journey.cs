using UnityEngine;

public class Journey
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed;
    private float startTime;
    public float journeyLength;
    public bool isComplete { get; private set; }

    public Journey(Vector3 startPosition, Vector3 endPosition, float speed)
    {
        this.startPosition = startPosition;
        this.endPosition = endPosition;
        this.speed = speed;
        journeyLength = Vector3.Distance(this.startPosition, this.endPosition);
        isComplete = false;
    }

    //starts the journey
    public void Start()
    {
        startTime = Time.time;
    }

    //returns the next position to move to  
    public Vector3 nextPositionToMoveTo()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        isComplete = distCovered >= journeyLength;

        if (isComplete) return endPosition;

        return Vector3.Lerp(this.startPosition, this.endPosition, fracJourney); ;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Journey activeJourney;
    private Queue<Journey> journeys;
    private System.Random rand;

    //TEMP HACK - GET THIS FROM EITHER PITCH OBJECT OR BY PASSING PARAMS IN TO MATCH
    int pitchSizeX = 60;
    int pitchSizeZ = 90;

    /* Use this for initialization
    */
    void Start()
    {

    }

    // Update is called once per frame - moves the ball along on its journeys
    void Update()
    {
        if (activeJourney == null || activeJourney.isComplete)
        {
            //active journey if finished, or we don't have one - start the next journey - if we have one
            if (journeys.Count > 0)
            {
                activeJourney = journeys.Dequeue();
                activeJourney.Start();
            }
        }

        if (!activeJourney.isComplete)
        {
            this.moveOnJourney();
        }
    }

    //Moves the ball along on his current journey
    void moveOnJourney()
    {
        transform.localPosition = activeJourney.nextPositionToMoveTo();
    }

    //Sets the in its initial place and generates random journeys (using random seed passed in)
    public void setBallInPlaceAndGenerateRandomJourneys(Vector3 initialPosInFormation, int randomSeed)
    {
        rand = new System.Random(randomSeed);
        this.journeys = GenerateRandomJourneys(initialPosInFormation);
    }

    //generates random journeys for the player
    Queue<Journey> GenerateRandomJourneys(Vector3 startingPosition)
    {
        Queue<Journey> ballJourneys = new Queue<Journey>();
        var numJourneys = 50;
        Vector3 lastEndVector = startingPosition;

        for (int i = 0; i < numJourneys; i++)
        {
            int pitchLimitX = pitchSizeX / 2;
            int pitchLimitZ = pitchSizeZ / 2;

            float randomX = (float)rand.Next(-pitchLimitX, pitchLimitX);
            int randomYInt = rand.Next(36, 180);
            float randomY = (float)randomYInt / 100;
            float randomZ = (float)rand.Next(-pitchLimitZ, pitchLimitZ);
            int randomSpeedInt = rand.Next(10, 80);
            float randomSpeed = (float)randomSpeedInt / 10;

            Vector3 newEndVector = new Vector3(randomX, randomY, randomZ);

            ballJourneys.Enqueue(
                new Journey(
                    lastEndVector,
                    newEndVector,
                    randomSpeed
                )
            );

            lastEndVector = newEndVector;
        }

        return ballJourneys;
    }
}

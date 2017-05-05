using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Journey activeJourney;
    private Queue<Journey> journeys;
    private System.Random rand;

    //TEMP HACK - GET THIS FROM EITHER PITCH OBJECT OR BY PASSING PARAMS IN TO MATCH
    int pitchSizeX = 60;
    int pitchSizeZ = 90;

    /* Use this for initialization
    */
    void Start () {
       
    }
	
	// Update is called once per frame - moves the player along on his journeys
	void Update () {
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
            this.movePlayerOnJourney();
        }
    }

    // Called when Player is clicked on - doubles it in size
    void OnSelect()
    {
        transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z * 2);
    }

    // Sets the strip colour of the player
    public void setStripColour(Color stripColour)
    {
        this.gameObject.GetComponent<Renderer>().material.color = stripColour;
    }

    // Sets the shirt number of the player
    public void setShirtNumber(int shirtNumber)
    {
        var shirtNumberGameObject = this.gameObject.transform.GetChild(0).gameObject;
        shirtNumberGameObject.GetComponent<TextMesh>().text = shirtNumber.ToString();  
    }

    //Moves the player along on his current journey
    void movePlayerOnJourney()
    {
        transform.localPosition = activeJourney.nextPositionToMoveTo();
    }

    //Sets the players initial place in the formation and generates random journeys (using random seed passed in)
    public void setPlaceInFormationAndGenerateRandomJourneys(Vector3 initialPosInFormation, int randomSeed)
    {
        rand = new System.Random(randomSeed);
        this.journeys = GenerateRandomJourneys(initialPosInFormation);        
    }

    //generates random journeys for the player
    Queue<Journey> GenerateRandomJourneys(Vector3 startingPosition)
    {
        Queue<Journey> playerJourneys = new Queue<Journey>();
        var numJourneys = 10;
        Vector3 lastEndVector = startingPosition;

        for (int i = 0; i < numJourneys; i++)
        {
            int pitchLimitX = pitchSizeX / 2;
            int pitchLimitZ = pitchSizeZ / 2;

            float randomX = (float)rand.Next(-pitchLimitX, pitchLimitX);
            float randomZ = (float)rand.Next(-pitchLimitZ, pitchLimitZ);
            int randomSpeedInt = rand.Next(10, 40);
            float randomSpeed = (float)randomSpeedInt / 10;

            Vector3 newEndVector = new Vector3(randomX, 1.3f, randomZ);

            playerJourneys.Enqueue(
                new Journey(
                    lastEndVector,
                    newEndVector,
                    randomSpeed
                )
            );

            lastEndVector = newEndVector;
        }

        return playerJourneys;
    }
}

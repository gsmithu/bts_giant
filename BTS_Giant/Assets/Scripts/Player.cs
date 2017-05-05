using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Journey activeJourney;
    private Queue<Journey> journeys;

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

    // Sets the journeys that the player will take
    public void setJourneys(Queue<Journey> journeys)
    {
        this.journeys = journeys;
    }

    //Moves the player along on his current journey
    void movePlayerOnJourney()
    {
        transform.localPosition = activeJourney.nextPositionToMoveTo();
    }
}

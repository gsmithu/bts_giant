using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //private Color red = new Color(255, 0, 0, 1);
    //private Color green = new Color(0, 255, 0, 1);
    //private Color blue = new Color(0, 0, 255, 1);
    //private Color yellow = new Color(255, 255, 0, 1);
    //private Color orange = new Color(255, 90, 0, 1);
    //private Color pink = new Color(255, 105, 150, 1);

    /* Use this for initialization
    *  Sets the initial position of the player, based on their position
    */
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

    // Sets the position of the player
    public void setPosition(float posX, float posY, float posZ)
    {
        transform.localPosition = new Vector3(posX, posY, posZ);
    }

    //void OnColourChangeRequested (string requestedColour)
    //{
    //    var colourToChangeTo = new Color();

    //    switch (requestedColour)
    //    {
    //        case "red":
    //            colourToChangeTo = red;
    //            break;
    //        case "green":
    //            colourToChangeTo = green;
    //            break;
    //        case "blue":
    //            colourToChangeTo = blue;
    //            break;
    //        case "yellow":
    //            colourToChangeTo = yellow;
    //            break;
    //        case "orange":
    //            colourToChangeTo = orange;
    //            break;
    //        case "pink":
    //            colourToChangeTo = pink;
    //            break;
    //    }

    //    this.gameObject.GetComponent<Renderer>().material.color = colourToChangeTo;
    //}

}

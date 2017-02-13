using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereModifier : MonoBehaviour {

    private Color red = new Color(255, 0, 0, 1);
    private Color green = new Color(0, 255, 0, 1);
    private Color blue = new Color(0, 0, 255, 1);
    private Color yellow = new Color(255, 255, 0, 1);
    private Color orange = new Color(255, 90, 0, 1);
    private Color pink = new Color(255, 105, 150, 1);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnSelect()
    {
        transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z * 2);
    }

    void OnColourChangeRequested (string requestedColour)
    {
        var colourToChangeTo = new Color();

        switch (requestedColour)
        {
            case "red":
                colourToChangeTo = red;
                break;
            case "green":
                colourToChangeTo = green;
                break;
            case "blue":
                colourToChangeTo = blue;
                break;
            case "yellow":
                colourToChangeTo = yellow;
                break;
            case "orange":
                colourToChangeTo = orange;
                break;
            case "pink":
                colourToChangeTo = pink;
                break;
        }

        this.gameObject.GetComponent<Renderer>().material.color = colourToChangeTo;
    }

}

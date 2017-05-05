using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour {

    public Transform pitchPrefab;
    public Transform ballPrefab;
    public Transform playerPrefab;
    public Transform matchScreenPrefab;

    private Color red = new Color(255, 0, 0, 1);
    private Color green = new Color(0, 255, 0, 1);
    private Color blue = new Color(0, 0, 255, 1);
    private Color yellow = new Color(255, 255, 0, 1);
    private Color orange = new Color(255, 90, 0, 1);
    private Color pink = new Color(255, 105, 150, 1);
    private Color white = new Color(255, 255, 255, 1);

    private Team homeTeam;
    private Team awayTeam;
    private Transform ball;

    /* Initialise the match
    *  Set up the pitch, ball and teams and makes a call to set formations
    */
    void Start () {
        Transform matchScreen = Instantiate(matchScreenPrefab);
        matchScreen.transform.SetParent(this.transform, false); //this makes the object keep its local orientation/scale rather than the global

        Transform pitch = Instantiate(pitchPrefab);
        pitch.transform.SetParent(this.transform, false);

        ball = Instantiate(ballPrefab);
        ball.transform.SetParent(this.transform, false); 
        
        homeTeam = ScriptableObject.CreateInstance("Team") as Team;
        homeTeam.init(playerPrefab, this.transform, white, true, 123456789);

        awayTeam = ScriptableObject.CreateInstance("Team") as Team;
        awayTeam.init(playerPrefab, this.transform, yellow, false, 987654321);

        SetFormations();
    }

    // Update is called once per frame - this is where we will update the player and ball positions, as well as the score etc.
    void Update () {
		
	}

    //Set the formations of the teams and the ball, which will then kick off the random movement
    void SetFormations()
    {
        //MatchParser matchParser = new MatchParser();
        //var formations = matchParser.ParseFormation();

        //homeTeam.setFormation(formations[0]);
        //awayTeam.setFormation(formations[1]);

        homeTeam.setFormation(2);
        awayTeam.setFormation(8);

        var ballComponent = ball.GetComponent<Ball>();
        ballComponent.setBallInPlaceAndGenerateRandomJourneys(new Vector3(0, 0.36f, 0), 57585301);
    }
}

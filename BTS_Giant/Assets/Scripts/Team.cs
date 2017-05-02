using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour {

    public string displayName { get; set; }
    public int score { get; set; }
    //private List<Transform> players;
    private Transform playerPrefab;
    public Transform parent;
    private Color stripColour;
    private bool atHome;

    public Team(Transform playerPrefab, Transform parent, Color stripColour, bool atHome)
    {
        this.playerPrefab = playerPrefab;
        this.parent = parent;
        this.stripColour = stripColour;
        this.atHome = atHome;
    }

    // Initialise the team
    void Start () {

    }

    // Draws the team - not done in start as we don't have access to prefab/parent at that point
    public void Draw()
    {
        //players = new List<Transform>();

        for (int i = 1; i <= 11; i++)
        {
            var playerPosX = atHome ? i : -i;
            var playerPosZ = atHome ? i : -i;
            var playerPos = new Vector3(playerPosX, 1.3f, playerPosZ);
            Transform player = Instantiate(playerPrefab, playerPos, Quaternion.identity);

            player.transform.SetParent(parent, false); //this makes the player keep its local orientation/scale rather than its global.

            var playerComponent = player.GetComponent<Player>();
            playerComponent.setStripColour(stripColour);
            playerComponent.setShirtNumber(i);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}

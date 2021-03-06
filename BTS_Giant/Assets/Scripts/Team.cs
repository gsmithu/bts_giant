﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : ScriptableObject {

    public string displayName { get; set; }
    public int score { get; set; }

    private Transform parent;
    private Color stripColour;
    private List<Transform> players;
    private Transform playerPrefab;
    private bool atHome;
    private System.Random rand;

    //TEMP HACK - GET THIS FROM EITHER PITCH OBJECT OR BY PASSING PARAMS IN TO MATCH
    int pitchSizeX = 60;
    int pitchSizeZ = 90;

    float[,] formationTwo = new float[11, 2] { //these are percentages of where the player is on the pitch e.g. 0 across, 50 up
         {0,0.5f},
         {0.125f,0.125f},
         {0.375f,0.125f},
         {-0.125f,0.125f},
         {-0.375f,0.125f},
         {0.125f,0.25f},
         {0.375f,0.25f},
         {-0.125f,0.25f},
         {-0.375f,0.25f},
         {0.125f,0.375f},   
         {-0.125f,0.375f}
    };

    float[,] formationEight = new float[11, 2] { //just for this example - have opposite end of pitch - but in reality, would need two arrays for each formation, both home and away ends
         {0,-0.5f},
         {0.125f,-0.4f},
         {0.375f,-0.4f},
         {-0.125f,-0.4f},
         {-0.375f,-0.4f},
         {0.3f,-0.3f},
         {-0.3f,-0.3f},
         {0.3f,-0.2f},
         {0,-0.2f},
         {-0.3f,-0.2f},
         {0,-0.1f}
    };

    //initialises values and draws
    public void init(Transform playerPrefab, Transform parent, Color stripColour, bool atHome, int randomSeed)
    {
        this.playerPrefab = playerPrefab;
        this.parent = parent;
        this.stripColour = stripColour;
        this.atHome = atHome;

        rand = new System.Random(randomSeed);

        Draw();
    }

    // Draws the team - not done in start as we don't have access to prefab/parent at that point
    public void Draw()
    {
        players = new List<Transform>();

        for (int i = 1; i <= 11; i++)
        {
            var playerPosX = atHome ? i : -i;
            var playerPosZ = atHome ? i : -i;
            var playerPos = new Vector3(playerPosX, 1.3f, playerPosZ);
            Transform player = Instantiate(playerPrefab, playerPos, Quaternion.identity, parent);
            players.Add(player);

            var playerComponent = player.GetComponent<Player>();
            playerComponent.setStripColour(stripColour);
            playerComponent.setShirtNumber(i);
        }
    }

    // Positions the players of the team into the formation passed in and then tells the player to generate random journeys for itself
    public void setFormation(int formationId)
    {
        var selectedFormation = new float[11, 2];
        switch (formationId)
        {
            case 2:
                selectedFormation = formationTwo;
                break;
            case 8:
                selectedFormation = formationEight;
                break;
        }

        for (int i = 0; i < players.ToArray().Length; i++)
        {
            var playerComponent = players[i].GetComponent<Player>();

            var initialPos = new Vector3(selectedFormation[i, 0] * pitchSizeX, 1.3f, selectedFormation[i, 1] * pitchSizeZ);
            playerComponent.setPlaceInFormationAndGenerateRandomJourneys(initialPos, rand.Next());
        }
    }

}

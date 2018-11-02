using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Caprica;

public class UniverseManager : MonoBehaviour {

    // This script is responsible for holding the main Galaxy data object,
    // triggering file save/loads or triggering the generation of a new galaxy.

    // Maybe also gets callbacks from end turn button?

	// Use this for initialization
	void Start () {
        Generate();
    }


    Galaxy galaxy;


    // Update is called once per frame
    void Update () {
		
	}

    public void Generate()
    {
        Debug.Log("UniverseManager::Generate -- Generating a new Galaxy");

        galaxy = new Galaxy();
        galaxy.Generate();

        // Tell our visual system to spawn the graphics
        ViewManager.Instance.GalaxyVisuals.InitiateVisuals(galaxy);
    }
}

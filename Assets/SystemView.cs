using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Caprica;

public class SystemView : MonoBehaviour {

    private void OnEnable()
    {
        Debug.Log("SystemView::OnEnable -- " + StarSystem.Name);

        // Update various UI elements for this system


        // Setup the system render view so we can see planets
        SpawnRenderables();
    }

    private void OnDisable()
    {
        // Become Darth Vader, kill all the younglings
        while (StarSystem3DContainer.transform.childCount > 0)
        {
            Transform t = StarSystem3DContainer.transform.GetChild(0);
            t.SetParent(null);
            Destroy(t.gameObject);
        }
    }

    public StarSystem StarSystem;

    public GameObject StarSystem3DContainer;

    public GameObject StarPrefab;   // This is temporary, will have to be read in from some
                                    // kind of library that links star type to the many 
                                    // images that represent that star type

    public GameObject PlanetPrefab; // Ditto.

    // Update is called once per frame
    void Update () {
    }

    void SpawnRenderables()
    {
        // Spawn our star
        GameObject go;

        go = Instantiate(StarPrefab, StarSystem3DContainer.transform);
        go.transform.localPosition = Vector3.zero;

        // Spawn all the planets
        float orbitDistance = 0;
        for (int i = 0; i < StarSystem.GetMaxPlanets(); i++)
        {
            orbitDistance += Config.GetFloat("STAR_ORBIT_DISTANCE");
            Planet p = StarSystem.GetPlanetAtIndex(i);
            if(p == null)
            {
                continue;
            }

            // If we get here, we have a valid planet

            go = Instantiate(PlanetPrefab, StarSystem3DContainer.transform);
            go.transform.localPosition = 
                Quaternion.Euler( 0, 0, Random.Range(0, 359)) * 
                new Vector3(orbitDistance, 0, 0);

        }

    }
}

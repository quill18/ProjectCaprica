using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Caprica;

public class GalaxyVisuals : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public LayerMask ClickableStarsLayerMask;

    // Update is called once per frame
    void Update () {
		
        if( Input.GetMouseButtonUp(0) )
        {
            // Mouse was clicked -- is it on a star?

            // TODO:  Ignore clicks if over a UI element

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if( Physics.Raycast(ray, out hitInfo, ClickableStarsLayerMask )  )
            {
                // We hit something, and that something can ONLY be a clickable star
                ClickableStar cs = hitInfo.collider.GetComponentInParent<ClickableStar>();

                if(cs == null)
                {
                    Debug.LogError("Our star doesn't have a ClickableStar component?");
                    return;
                }

                Debug.Log("Clicked star: " + cs.name);

                ViewManager.Instance.SystemView.SelectedStar = cs.StarSystem;
                ViewManager.Instance.ShowView( ViewManager.Instance.SystemView );
            }
        }

	}

    public GameObject[] StarPrefabs;    // Index of array is a star type. The prefabs are 
                                        // responsible for having appearance variety.

    Galaxy galaxy;

    public void InitiateVisuals( Galaxy galaxy )
    {
        this.galaxy = galaxy;

        for (int i = 0; i < galaxy.GetNumStarSystems(); i++)
        {
            StarSystem ss = galaxy.GetStarSystem(i);

            GameObject go = Instantiate(
                StarPrefabs[ss.GetStarTypeIndex()],
                ss.Position,       // Are we gonna want to mult by a scalar?
                Quaternion.identity,
                this.transform
                );

            go.GetComponent<ClickableStar>().StarSystem = ss;


        }
    }
}

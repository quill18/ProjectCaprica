using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Caprica;

public class SystemView : MonoBehaviour {

    private void OnEnable()
    {
        Debug.Log("SystemView::OnEnable -- " + SelectedStar.Name);

        // Update various UI elements for this system


        // Setup the system render view so we can see planets


    }

    public StarSystem SelectedStar;

    // Update is called once per frame
    void Update () {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Caprica;
using TMPro;

public class ClickableStar : MonoBehaviour {

    private void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = StarSystem.Name;
    }

    public StarSystem StarSystem;
}

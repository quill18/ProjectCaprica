using UnityEngine;

[ExecuteInEditMode]
public class Rotates : MonoBehaviour {

    public Vector3 RotationSpeed = new Vector3(0, 90, 0);
	
	void Update () {
        this.transform.Rotate(RotationSpeed * Time.deltaTime);
	}
}

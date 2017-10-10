using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	private Camera cam;

	private GameObject parent;
	private StarDisplay starDisplay;

	public void Start()
	{
		cam = GameObject.FindObjectOfType<Camera> ();
		parent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();

		if (!parent) {
			parent = new GameObject ("Defenders");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown ()
	{
		Vector3 rawPos = CalculateWorldPointOfMouseClick (Input.mousePosition);
		GameObject def = Button.selectedDefender;

		int defenderCost = def.GetComponent<Defender> ().starCost;

		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (rawPos, def);
		} else {
			Debug.Log ("Insufficient stars to spawn");
		}
	}

	void SpawnDefender (Vector3 rawPos, GameObject def)
	{
		Quaternion zeroRot = Quaternion.identity;
		GameObject newDef = Instantiate (def, rawPos, zeroRot) as GameObject;
		newDef.transform.parent = parent.transform;
	}

	Vector2 CalculateWorldPointOfMouseClick(Vector3 mousePos)
	{
		Vector2 gridPosition;
		float x, y;

		gridPosition = cam.ScreenToWorldPoint (mousePos);

		x = Mathf.Round (gridPosition.x);
		y = Mathf.Round (gridPosition.y);

		gridPosition = new Vector2 (x, y);
		return gridPosition;
	}
}

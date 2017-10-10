using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starText;
	public static int totalStars=100;
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		starText = GetComponent<Text> ();
		starText.text = totalStars.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddStars(int amount)
	{
		totalStars += amount;
		starText.text = totalStars.ToString ();
		print (amount + " stars added to display");
	}

	public Status UseStars(int amount)
	{
		if (totalStars >= amount) {
			totalStars -= amount;
			starText.text = totalStars.ToString ();
			print (amount + " stars used");

			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
}

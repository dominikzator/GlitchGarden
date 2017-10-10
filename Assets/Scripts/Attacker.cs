using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySecond;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			anim.SetBool ("isAttacking", false);
		}

		//print (Button.selectedDefender);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//col.GetComponent<Animator> ().SetBool ("isAttacking", true);
	}



	public void SetSpeed (float speed)
	{
		currentSpeed = speed;
	}

	//Called from the animator at time of actual blow
	public void StrikeCurrentTarget(float damage)
	{
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage (damage);
			}
		}
	}

	public void Attack (GameObject obj)
	{
		currentTarget = obj;
		//Debug.Log ("Attack " + obj.name);
	}
}

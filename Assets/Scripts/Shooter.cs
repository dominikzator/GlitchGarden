using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	public void Start()
	{
		//animator = GetComponent<Animator> ();
		animator = GameObject.FindObjectOfType<Animator>();

		projectileParent = GameObject.Find ("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");
		}

		SetMyLaneSpawner ();
	}

	void Update()
	{
		if (IsAttackerAheadInLane ()) 
		{
			animator.SetBool ("isAttacking", true);
		} 
		else 
		{
			animator.SetBool ("isAttacking", false);
		}
	}

	bool IsAttackerAheadInLane()
	{
		
		if (myLaneSpawner.transform.childCount <= 0) {
			//Debug.Log ("no attackers in lane deteckted");
			return false;
		}

		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}

		//Attacker in lane, but behind us
		return false;
	}

	void SetMyLaneSpawner()
	{
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner myLoopSpawner in spawners) {
			if (myLoopSpawner.transform.position.y == gameObject.transform.position.y) {
				myLaneSpawner = myLoopSpawner;
				return;
				//print (myLaneSpawner.transform.position.y);
			}
		}

		Debug.LogError (name + " can't find spawner in lane");
	}

	private void Fire()
	{
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

}

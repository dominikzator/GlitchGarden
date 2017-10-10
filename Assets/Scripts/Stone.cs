using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	void Update()
	{
		
	}

	public void OnTriggerStay2D(Collider2D col)
	{
		Attacker attacker = col.gameObject.GetComponent<Attacker> ();

		if (attacker && animator.GetCurrentAnimatorStateInfo(0).IsName("gravestone idle")) {
			animator.SetTrigger ("underAttack trigger");
			print ("trigger set");
		}
	}
}

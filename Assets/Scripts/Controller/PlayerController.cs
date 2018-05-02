using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header ("Animation Settings & Debug")]
	public bool isFighting = false;
	public Animator playerAnimator;
	public GameObject idlingBlade;
	public GameObject fightingBlade;

	AnimatorStateInfo animInfo;


	float vert;
	float horiRotate;

	void Awake () {
		this.playerAnimator = GetComponent<Animator> ();

		animInfo = playerAnimator.GetCurrentAnimatorStateInfo (0);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Switch Fight Mode
		if (Input.GetKeyDown (KeyCode.Tab)) {
			TriggerBattleMode ();
		}

		// walk animation
		vert = Input.GetAxis ("Vertical");
		if (vert != 0) {
			playerAnimator.SetBool ("IsWalking", true);
		} else {
			playerAnimator.SetBool ("IsWalking", false);
		}
		playerAnimator.SetFloat ("Speed", vert);

		// sprint
		if (Input.GetKey (KeyCode.LeftShift)) {
			playerAnimator.SetBool ("IsSprinting", true);
		} else {
			playerAnimator.SetBool ("IsSprinting", false);
		}

		// character rotation
		horiRotate = Input.GetAxis ("Horizontal");
		transform.RotateAround (Vector3.up, horiRotate * Time.deltaTime);

		// attack
		if (Input.GetMouseButtonDown (0) && isFighting) {
			playerAnimator.SetTrigger ("TriggerLightAttack");
		}

		// blocking
		if (Input.GetMouseButton (1) && isFighting) {
			playerAnimator.SetBool ("IsBlocking", true);
		} else {
			playerAnimator.SetBool ("IsBlocking", false);
		}

	}

	#region OnClick Event
	void TriggerBattleMode () {
		isFighting = !isFighting;
		if (isFighting) {
			playerAnimator.SetTrigger ("TriggerFightMode");
		} else {
			playerAnimator.SetTrigger ("TriggerStandMode");
		}

		playerAnimator.SetBool ("IsFighting", isFighting);
	}
	#endregion


	#region Animation Callbacks
	void OnNoudouFinished () {
		idlingBlade.SetActive (!isFighting);
		fightingBlade.SetActive (isFighting);
	}

	void OnBaddouFinished () {
		idlingBlade.SetActive (!isFighting);
		fightingBlade.SetActive (isFighting);
	}
	#endregion
}

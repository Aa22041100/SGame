using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header ("Animation Settings & Debug")]
	public bool isFighting = false;
	public Animator playerAnimator;
	public GameObject idlingBlade;
	public GameObject fightingBlade;

	[Header ("Info")]
	public AttackMode attackStrength = AttackMode.LightAttack;
	public float rotateSpeed = 1f;
	public float walkSpeed = 1f;

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

		// sprint checking
		if (Input.GetKey (KeyCode.LeftShift)) {
			playerAnimator.SetBool ("IsSprinting", true);
			playerAnimator.ResetTrigger ("TriggerAttack");
		} else {
			playerAnimator.SetBool ("IsSprinting", false);
		}

		if (vert != 0) {
			playerAnimator.SetBool ("IsWalking", true);
			playerAnimator.ResetTrigger ("TriggerFightMode");
			playerAnimator.ResetTrigger ("TriggerStandMode");
		} else {
			playerAnimator.SetBool ("IsWalking", false);
		}
		playerAnimator.SetFloat ("Speed", vert);

		// character rotation
		horiRotate = Input.GetAxis ("Horizontal");
		transform.RotateAround (Vector3.up, horiRotate * rotateSpeed * Time.deltaTime);

		// attack
		if (Input.GetMouseButtonDown (0) && isFighting) {
			playerAnimator.SetTrigger ("TriggerAttack");
		}

		// blocking
		if (Input.GetMouseButton (1) && isFighting) {
			playerAnimator.SetBool ("IsBlocking", true);
		} else {
			playerAnimator.SetBool ("IsBlocking", false);
		}

		// attack mode
		playerAnimator.SetInteger ("AttackMode", (int) attackStrength);

		// change attack mode
		if (Input.GetKeyDown (KeyCode.Q)) {
			SwitchAttackMode ();
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
	public void OnNoudouFinished () {
		idlingBlade.SetActive (!isFighting);
		fightingBlade.SetActive (isFighting);
	}

	public void OnBaddouFinished () {
		idlingBlade.SetActive (!isFighting);
		fightingBlade.SetActive (isFighting);
	}
	#endregion

	#region Setter
	public void SwitchAttackMode (AttackMode attackMode) {
		attackStrength = attackMode;
	}
	public void SwitchAttackMode () {
		int tmp = (int) attackStrength;
		tmp++;
		if (tmp >= 3) {
			tmp = 0;
		}
		attackStrength = (AttackMode) tmp;

		GameManager.Instance.UpdatePlayerAttackMode (attackStrength);
	}
	#endregion
}
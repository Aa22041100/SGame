using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	[Header ("Player")]
	public GameObject player;
	PlayerController playerController;

	[Header ("UI")]
	public GameObject uiRoot;
	UIRootController uiController;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake() {
		// save global instance
		Instance = this;

		// search gameobject and component with tag at once
		player = GameObject.FindGameObjectWithTag ("Player");
		playerController = player.GetComponent<PlayerController> ();
		uiRoot = GameObject.FindGameObjectWithTag ("UI");
		uiController = uiRoot.GetComponent<UIRootController> ();
	}
	
	#region Related Player Methods
	public void SwitchPlayerAttackMode (AttackMode attackMode) {
		playerController.SwitchAttackMode (attackMode);
	}
	public void SwitchPlayerAttackMode () {
		playerController.SwitchAttackMode ();
	}
	#endregion

	#region Related UI Methods
	public void UpdatePlayerAttackMode (AttackMode attackMode) {
		uiController.SetCurrentAttackModeLabel (attackMode);
	}
	#endregion
}

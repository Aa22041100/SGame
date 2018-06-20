using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRootController : MonoBehaviour {

	PlayerController player;

	[Header ("UI References")]
	public Text modeLbl;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		modeLbl.text = string.Format ("Mode: {0}", player.attackStrength.ToString ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#region UI Callbacks
	public void OnStartGameClicked () {
		GameManager.Instance.StartGame ();
	}
	#endregion

	#region Setter
	public void SetCurrentAttackModeLabel (AttackMode attackMode) {
		modeLbl.text = string.Format ("Mode: {0}", attackMode.ToString ());
	}
	#endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {


	NavMeshAgent navAgent;
	Transform player;
	EnemyHealth health;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake() {
	}

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		health = GetComponent<EnemyHealth> ();
		player = GameManager.Instance.player.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		navAgent.SetDestination (player.position);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {


	NavMeshAgent navAgent;
	Transform player;

	bool isReadyToChase = false;

	#region Unity Basic Events
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		player = GameManager.Instance.player.GetComponent<Transform> ();
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate() {
		if (isReadyToChase) {
			navAgent.SetDestination (player.position);
		}
	}
	#endregion

	public void InitAI () {
		isReadyToChase = true;
	}

	public void StopAI () {
		isReadyToChase = false;
		navAgent.isStopped = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(EnemyHealth))]
[RequireComponent (typeof(EnemyMovement))]
public class Enemy : MonoBehaviour {

	public int id = -1;
	EnemyHealth health;
	public bool isDamageCoolingDown = false;
	const float DAMGE_COOLDOWN_TIME = 0.1f;
	EnemyMovement movement;
	
	#region Unity Basic Event
	// Use this for initialization
	void Start () {
		health = GetComponent<EnemyHealth> ();
		movement = GetComponent<EnemyMovement> ();
	}
	#endregion

	#region Custom Events
	public void Spawn (float maxHealth, int index) {
		if (health == null) {
			health = GetComponent<EnemyHealth> ();
		}
		id = index;
		health.SetHealth (maxHealth);
		OnSpawn ();
	}
	public void OnSpawn () {
		if (movement == null) {
			movement = GetComponent<EnemyMovement> ();
		}
		movement.InitAI ();
	}

	public void OnDie () {
		if (movement == null) {
			movement = GetComponent<EnemyMovement> ();
		}
		movement.StopAI ();
		GameManager.Instance.HideEnemy (id);
	}
	#endregion

	#region Collision Event
	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter (Collision other) {

	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other) {
		print (other.gameObject.name);
		WrappedLayer objectLayer = (WrappedLayer) other.gameObject.layer;
		switch (objectLayer) {
			case WrappedLayer.Weapon_Layer:
				if (!isDamageCoolingDown) {
					print ("id: " + id + "; Get Hit!");
					float damage = UnityEngine.Random.Range (GameManager.Instance.player.GetComponent<PlayerController> ().minAtk, GameManager.Instance.player.GetComponent<PlayerController> ().maxAtk);
					health.ReduceHealth (damage);
					// StartCoroutine (GetHitFromWeapon ());
				}
			break;
		}	
	}

	IEnumerator GetHitFromWeapon () {
		// isDamageCoolingDown = true;
		yield return new WaitForSeconds (DAMGE_COOLDOWN_TIME);
		// isDamageCoolingDown = false;
    }
	#endregion
}
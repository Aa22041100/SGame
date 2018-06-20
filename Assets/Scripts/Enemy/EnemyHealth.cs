using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	[SerializeField] float remainHp = 100f;

	public void SetHealth (float maxHealth) {
		remainHp = maxHealth;
	}

	public float GetHealth () {
		return remainHp;
	}

	public void ReduceHealth (float damage) {
		remainHp -= damage;
		if (remainHp <= 0) {
            gameObject.SendMessage("OnDie");
		}
	}
}

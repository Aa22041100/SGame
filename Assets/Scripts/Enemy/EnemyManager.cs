using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject enemyPrefab;
	[SerializeField] List<GameObject> enemies = new List<GameObject> ();

	[Header ("Stage Info")]
	[SerializeField] int curLevel = 1;
	[SerializeField] int enemyCount = 0;

	[Header ("Enemy Base Settings")]
	[Range (0.1f, 1f)]
	[SerializeField] float enemyMinStrengthFactor = 0.5f;
	[Range (1f, 3f)]
	[SerializeField] float enemyMaxStrengthFactor = 1.5f;

	// Use this for initialization
	void Start () {
		
	}

	#region Init
	public void GenerateEnemy (int level) {
		print (level);
		curLevel = level;
		enemyCount = level * 10;
		if (enemyPrefab != null) {
			for (int i = 0; i < enemyCount; i++) {
				GameObject go = Instantiate (enemyPrefab);
				go.name = "Enemy";
				float calHp = 100f + UnityEngine.Random.Range (curLevel * 10f * enemyMinStrengthFactor, curLevel * 10 * enemyMaxStrengthFactor);
				go.GetComponent<Enemy> ().Spawn (calHp, i);
				enemies.Add (go);
			}
		}
	}
	#endregion

	#region Control methods
	public void HideEnemy (int index) {
		enemies[index].SetActive (false);
	}
	#endregion
}

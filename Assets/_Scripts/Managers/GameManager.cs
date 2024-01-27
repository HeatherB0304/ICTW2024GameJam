using UnityEngine;

public class GameManager : MonoBehaviour{
	[SerializeField] private Transform[] spawnPoints;

	public static GameManager Instance;

	private void Awake() {
		if(Instance == null){
			Instance = this;
		}
		else if (Instance != null){
			Destroy(gameObject);
		}
	}
}

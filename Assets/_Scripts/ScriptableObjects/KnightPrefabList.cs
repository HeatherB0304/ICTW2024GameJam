using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prefab Lists/Knight Prefab List", fileName = "KnightPrefabList")]
public class KnightPrefabList : ScriptableObject{
	public List<GameObject> knightPrefabs;

	public List<Sprite> knightImages;

	public GameObject GetKnightPrefab(KnightColor knightColor){
		return knightPrefabs[(int)knightColor];
	}

	public Sprite GetKnightImage(KnightColor knightColor){
		return knightImages[(int)knightColor];
	}
}

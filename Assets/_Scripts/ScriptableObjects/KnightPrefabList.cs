using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prefab Lists/Knight Prefab List", fileName = "KnightPrefabList")]
public class KnightPrefabList : ScriptableObject{
	public List<GameObject> knightPrefabs;

	public GameObject GetKnightPrefab(KnightColor knightColor){
		return knightPrefabs[(int)knightColor];
	}
}

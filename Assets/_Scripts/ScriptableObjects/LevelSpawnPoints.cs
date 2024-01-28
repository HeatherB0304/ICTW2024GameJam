using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Spawn List", fileName = "NewLevelSpawn")]
public class LevelSpawnPoints : ScriptableObject{
	public string LevelName;
	public List<Vector3> spawnPointsLocation = new List<Vector3>();
}

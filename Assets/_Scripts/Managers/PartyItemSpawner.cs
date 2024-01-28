using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class PartyItemSpawner : MonoBehaviour{
	[SerializeField] private List<PartyItemSO> partyItemsToSpawn;
	[SerializeField] private float spawnInterval;
	[SerializeField] private int maxItemsToSpawn;

	[SerializeField] private Color gizmosColor;
	[SerializeField, Range(0f, 30f)] private float spawnRadius;

	private List<PartyItemObject> currentPartyItemsSpawned = new List<PartyItemObject>();

	private void Start() {
		PlayerManager.Instance.OnGameStart += (object sender, EventArgs e) => {StartCoroutine(PartyItemSpawnCorutine());};
		PlayerManager.Instance.OnGameEnd += (object sender, EventArgs e) => {StopAllCoroutines();};
	}

	private void OnDestroy() {
		StopAllCoroutines();
		PlayerManager.Instance.OnGameStart -= (object sender, EventArgs e) => {StartCoroutine(PartyItemSpawnCorutine());};
		PlayerManager.Instance.OnGameEnd -= (object sender, EventArgs e) => {StopAllCoroutines();};
	}

	private IEnumerator PartyItemSpawnCorutine(){
		yield return new WaitForSeconds(spawnInterval);
		SpawnRandomPartyItem();
	}

	public void RemovePartyItem(PartyItemObject partyItemObject){
		if(currentPartyItemsSpawned.Contains(partyItemObject)){
			currentPartyItemsSpawned.Remove(partyItemObject);
		}
	}

    private void SpawnRandomPartyItem(){
		if(currentPartyItemsSpawned.Count == maxItemsToSpawn){
			StartCoroutine(PartyItemSpawnCorutine());
			return;
		}

		var randomPartyItemIndex = Random.Range(0, partyItemsToSpawn.Count);
		Vector3 randomPartyItemPosition = GetRandomSpawnPosition();
		currentPartyItemsSpawned.Add(partyItemsToSpawn[randomPartyItemIndex].SpawnItem(randomPartyItemPosition, this));
		StartCoroutine(PartyItemSpawnCorutine());
    }

    private Vector3 GetRandomSpawnPosition(){
        Vector3 center = transform.position;
		float half = spawnRadius / 2;

		var x = Random.Range(center.x - half, center.x + half);
		var z = Random.Range(center.z - half, center.z + half);
		
		return new Vector3(x, transform.position.y + 0.5f, z);
    }

	private void OnDrawGizmos() {
		Gizmos.color = gizmosColor;
		Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), new Vector3(spawnRadius, 1f, spawnRadius));	
	}
}

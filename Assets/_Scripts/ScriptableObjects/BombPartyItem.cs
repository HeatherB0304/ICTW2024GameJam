using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Party Item/Bomb Party Item", fileName = "BombPartyItem")]
public class BombPartyItem : PartyItemSO{
	[Header("Bomb Variables")]
	public float knockBackStrength;
	public float bombRadius;
	public float bombDamage;

    public override PartyItemObject SpawnItem(Vector3 position, PartyItemSpawner parentSpawner){
		PartyItemObject itemInstance = Instantiate(PartyGameObjectPrefab, position, Quaternion.identity);
		itemInstance.SetupPartyObject(this, parentSpawner);
		BombCountdown(itemInstance);

		return itemInstance;
    }

	private void BombCountdown(PartyItemObject partyItemObject){
		BombPartyItemObject bombPartyItem = partyItemObject as BombPartyItemObject;
		//Display bomb radius
		//Start bomb countdown
		partyItemObject.StartPartyItemCoroutine(GetBombCountdown(bombPartyItem));
	}

	private IEnumerator GetBombCountdown(BombPartyItemObject bombPartyItemObject){
		yield return new WaitForSeconds(ItemLiveTime);
		bombPartyItemObject.Explode(this);
	}
}

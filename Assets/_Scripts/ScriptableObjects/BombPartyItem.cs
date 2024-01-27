using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Party Item/Bomb Party Item", fileName = "BombPartyItem")]
public class BombPartyItem : PartyItemSO
{
	public float knockBackStrength;
	public float bombRadius;
	public float bombDamage;

    public override PartyItemObject SpawnItem(Vector3 position){
		PartyItemObject bombInstance = Instantiate(PartyGameObjectPrefab, position, Quaternion.identity);
		bombInstance.SetupPartyObject(this);
		BombCountdown(bombInstance);

		return bombInstance;
    }

	private void BombCountdown(PartyItemObject bombPartyItemObject){
		//Display bomb radius
		//Start bomb countdown
		bombPartyItemObject.StartPartyItemCoroutine(GetBombCountdown(bombPartyItemObject.transform.position));
	}

	private IEnumerator GetBombCountdown(Vector3 bombPosition){
		yield return new WaitForSeconds(ItemLiveTime);
		//Explode
		//TO-DO:
		//Apply Knockback to any player within the radius
		//Damage any player in the radius
	}
}

using UnityEngine;

[CreateAssetMenu(menuName = "Party Item/Sword Party Item", fileName = "SwordPartyItem")]
public class SwordPartyItem : PartyItemSO{
	[Header("Sword Variables")]
	[SerializeField] private float meleeDamage;

	public override PartyItemObject SpawnItem(Vector3 position, PartyItemSpawner parentSpawner){
		PartyItemObject swordInstance = Instantiate(PartyGameObjectPrefab, position, Quaternion.identity);
		swordInstance.SetupPartyObject(this, parentSpawner);

		return swordInstance;
    }
}

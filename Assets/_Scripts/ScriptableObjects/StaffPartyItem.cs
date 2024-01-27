using UnityEngine;

[CreateAssetMenu(menuName = "Party Item/Staff Party Item", fileName = "StaffPartyItem")]
public class StaffPartyItem : PartyItemSO{
	[Header("Ice Ball Variables")]
	[SerializeField] private float iceBallDamageAbount;
	[SerializeField] private float iceBallTravelSpeed;

	[Header("Freeze Effect Variables")]
	[SerializeField] private float freezeTimer;

	public override PartyItemObject SpawnItem(Vector3 position){
		PartyItemObject staffInstance = Instantiate(PartyGameObjectPrefab, position, Quaternion.identity);
		staffInstance.SetupPartyObject(this);

		return staffInstance;
    }
}

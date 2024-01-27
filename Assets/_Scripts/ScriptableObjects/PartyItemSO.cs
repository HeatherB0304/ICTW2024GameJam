using UnityEngine;

public abstract class PartyItemSO : ScriptableObject{
	public string ItemName;
    public float ItemLiveTime;
    public float ItemCooldownTime;
    public bool isGrabbable = false;
    public PartyItemObject PartyGameObjectPrefab;

    public virtual void UseItem(Transform userTransfrom) { }

    public virtual PartyItemObject SpawnItem(Vector3 position, PartyItemSpawner parentSpawner) { return null; }
}

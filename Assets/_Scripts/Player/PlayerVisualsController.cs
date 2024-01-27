using UnityEngine;

public class PlayerVisualsController : MonoBehaviour{
	[SerializeField] private KnightPrefabList knightPrefabList;
	[SerializeField] private Transform knightVisualParent;

    public void UpdateKnightVisual(KnightColor knightColor){
		Instantiate(knightPrefabList.GetKnightPrefab(knightColor), transform.position, transform.rotation, knightVisualParent);
    }
}

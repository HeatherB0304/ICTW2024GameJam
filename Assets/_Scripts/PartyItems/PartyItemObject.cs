using System.Collections;
using UnityEngine;

public class PartyItemObject : MonoBehaviour, IGrabbable
{
	private PartyItemSO partyItemSO;

	public void SetupPartyObject(PartyItemSO _partyItemSO){
		partyItemSO = _partyItemSO;
	}

    public bool AttemptGrabObject(){
		return partyItemSO.isGrabbable;
    }

    public void StartPartyItemCoroutine(IEnumerator coroutineToRun){
		StartCoroutine(coroutineToRun);
	}
}

using System.Collections.Generic;
using UnityEngine;

public class PlayerGameUIController : MonoBehaviour{
	[Header("Asset References")]
	[SerializeField] private KnightPrefabList knightPrefabList;
	[SerializeField] private List<PlayerUI> playerUIList;

	private void Awake() {
		foreach (var playerUI in playerUIList){
			playerUI.gameObject.SetActive(false);
		}
	}

	private void Start() {
		PlayerManager.Instance.OnPlayerJoined += AlertPlayerUI;
	}

	private void OnDestroy() {
		PlayerManager.Instance.OnPlayerJoined -= AlertPlayerUI;
	}

    private void AlertPlayerUI(object sender, PlayerManager.PlayerEventArgs e){
		playerUIList[e.player.playerNum].gameObject.SetActive(true);
		playerUIList[e.player.playerNum].SetupPlayerUI(e.player, knightPrefabList);
    }
}

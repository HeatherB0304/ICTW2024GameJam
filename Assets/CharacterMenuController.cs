using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenuController : MonoBehaviour{
	[Header("Asset References")]
	[SerializeField] private KnightPrefabList knightPrefabList;

	[SerializeField] private List<Image> knightImages;

	[SerializeField] private List<Image> winKnightImages;

	[SerializeField] private Button startGameButton;

	[SerializeField] private PlayerManager playerManager;

	private void Awake() {
		PlayerManager.OnPlayerJoined += UpdateCharacterSelectScreen;
		PlayerManager.OnValidGameStart += ValidGameStart;
		PlayerManager.OnGameEnd += UpdateWinScreen;
	}

    private void UpdateWinScreen(object sender, EventArgs e){
		var rankingList = playerManager.CurrentPlayerList;
		rankingList.OrderByDescending(x => x.currentDeathCount);

		for (int i = 0; i < rankingList.Count; i++){
			Debug.Log(rankingList[i].knightColor);

			winKnightImages[i].sprite = knightPrefabList.GetKnightImage(rankingList[i].knightColor);
			winKnightImages[i].gameObject.SetActive(true);
		}
    }

    private void Start() {
		foreach (var image in knightImages){
			image.gameObject.SetActive(false);
		}
		foreach(var image in winKnightImages){
			image.gameObject.SetActive(false);
		}

		startGameButton.interactable = false;
	}

	private void ValidGameStart(object sender, EventArgs e){
        startGameButton.interactable = true;
    }

    private void UpdateCharacterSelectScreen(object sender, PlayerManager.PlayerEventArgs e){

		knightImages[e.player.playerNum].sprite = knightPrefabList.GetKnightImage(e.player.knightColor);
		knightImages[e.player.playerNum].gameObject.SetActive(true);
    }
}

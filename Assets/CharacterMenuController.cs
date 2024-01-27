using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenuController : MonoBehaviour{
	[Header("Asset References")]
	[SerializeField] private KnightPrefabList knightPrefabList;

	[SerializeField] private List<Image> knightImages;

	[SerializeField] private Button startGameButton;

	private void Awake() {
		PlayerManager.OnPlayerJoined += UpdateCharacterSelectScreen;
		PlayerManager.OnValidGameStart += ValidGameStart;
	}

    private void Start() {
		foreach (var image in knightImages){
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

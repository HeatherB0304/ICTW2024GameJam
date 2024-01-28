using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager Instance;

	public List<Player> CurrentPlayerList => currentPlayerList;

	public event EventHandler<PlayerEventArgs> OnPlayerJoined;
	public event EventHandler<PlayerEventArgs> OnPlayerLeave;
	public event EventHandler OnValidGameStart;
	public event EventHandler OnShowCharacterScreen;
	public event EventHandler OnHideCharacterScreen;
	public event EventHandler OnGameStart;
	public event EventHandler OnGameEnd;

	public class PlayerEventArgs : EventArgs{
		public Player player;
		public PlayerEventArgs(Player _player){
			player = _player;
		}
	}

	[SerializeField] private GameObject characterSelectScreen;
	[SerializeField] private GameObject winScreen;

	[SerializeField] private List<Player> currentPlayerList;

	private void Awake() {
		currentPlayerList = new List<Player>();

		if(Instance == null){
			Instance = this;
		}
		else{
			Destroy(gameObject);
		}
	}

	private void Start() {
		ShowCharacterScreen();
		HideWinScreen();
	}

	public void OnSceneLoad(GameState state){
		if(state == GameState.Game){
			ShowCharacterScreen();
		}
	}

    public void ShowCharacterScreen(){
		characterSelectScreen.SetActive(true);
		HideWinScreen();
		OnShowCharacterScreen?.Invoke(this, EventArgs.Empty);
    }

	public void HideCharacterScreen(){
		characterSelectScreen.SetActive(false);
		OnShowCharacterScreen?.Invoke(this, EventArgs.Empty);
	}
	
	public void ShowWinScreen(){
		winScreen.SetActive(true);
		HideCharacterScreen();
	}

	public void HideWinScreen(){
		winScreen.SetActive(false);
	}

    public void AddNewPlayer(PlayerInput playerInput){
		int incomingPlayerIndex = currentPlayerList.Count;
		
		Player incomingPlayer = new Player((KnightColor)incomingPlayerIndex, incomingPlayerIndex, playerInput);
		currentPlayerList.Add(incomingPlayer);

		playerInput.GetComponent<PlayerVisualsController>().UpdateKnightVisual(incomingPlayer.knightColor);

		OnPlayerJoined?.Invoke(this, new PlayerEventArgs(incomingPlayer));

		if(currentPlayerList.Count >= 2){
			OnValidGameStart?.Invoke(this, EventArgs.Empty);
		}
    }

    public void RemovePlayer(PlayerInput playerInput){
		Player leavingPlayer = currentPlayerList.FirstOrDefault(x => x.assignedPlayerInput == playerInput);
		currentPlayerList.Remove(leavingPlayer);

		OnPlayerLeave?.Invoke(this, new PlayerEventArgs(leavingPlayer));
	}

	public void StartGame(){
		HideCharacterScreen();
		SetStartingPlayerPositions();
		StartGameTimer();
		OnGameStart?.Invoke(this, EventArgs.Empty);
	}

	public Player GetPlayerFromPlayerInput(PlayerInput playerInput){
		foreach (var player in currentPlayerList){
			if(player.assignedPlayerInput == playerInput){
				return player;
			}
		}

		return null;
	}

	public void ResetPlayerPosition(Player player){
		// var index = currentPlayerList.IndexOf(player);
		
		// player.assignedPlayerInput.transform.position = GameManager.CurrentLevel.spawnPointsLocation[index];
	}

	public void ReplayGame(){
		GameManager.UpdateGameState(GameState.MainMenu);
	}

	public int GetPlayerIndex(Player player){
		return currentPlayerList.IndexOf(player);
	}

    private void StartGameTimer(){
        StartCoroutine(GameTimer());
    }

    private void SetStartingPlayerPositions(){
		//Has valid spawn point count
		if(GameManager.CurrentLevel != null && GameManager.CurrentLevel.spawnPointsLocation.Count == 4){
			for (int i = 0; i < currentPlayerList.Count; i++){
				currentPlayerList[i].assignedPlayerInput.GetComponent<PlayerMovement>().UpdatePosition(GameManager.CurrentLevel.spawnPointsLocation[i]);
			}
		}
    }

	private IEnumerator GameTimer(){
		yield return new WaitForSeconds(GameManager.CurrentLevel.LevelTime);
		ShowWinScreen();
		OnGameEnd?.Invoke(this, EventArgs.Empty);
	}
}

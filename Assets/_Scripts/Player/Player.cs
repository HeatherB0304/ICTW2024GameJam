using System;
using UnityEngine.InputSystem;

[Serializable]
public class Player{
	public KnightColor knightColor;
	public int playerNum;
	public PlayerInput assignedPlayerInput;
	
	public Player(KnightColor _knightColor, int _playerNum, PlayerInput _assignedplayerInput){
		knightColor = _knightColor;
		playerNum = _playerNum;
		assignedPlayerInput = _assignedplayerInput;
	}
}

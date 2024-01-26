using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
	private PlayerInput inputActions;
	private PlayerMovement playerMovement;

	private void Awake(){
		TryGetComponent(out inputActions);
		TryGetComponent(out playerMovement);
	}

	private void Start() {
		var index = inputActions.playerIndex;

		//Need to refactor, testing for now
		var playerMovements = FindObjectsOfType<PlayerMovement>();
		playerMovement = playerMovements.FirstOrDefault(playerMove => playerMove.GetPlayerIndex() == index);
	}

	public void OnMove(CallbackContext context){
		if(playerMovement == null) return;
		playerMovement.SetInputVector(context.ReadValue<Vector2>());
	}
}

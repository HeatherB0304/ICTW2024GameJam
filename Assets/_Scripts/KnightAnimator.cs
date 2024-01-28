using System;
using UnityEngine;

public class KnightAnimator : MonoBehaviour{
	[SerializeField] private Animator knightAnimator;
	[SerializeField] private PlayerMovement playerMovement;
	[SerializeField] private PlayerKnockback playerKnockback;
	[SerializeField] private Health playerHealth;

	private void Start() {
		playerMovement.OnMove += PlayMoveAnimation;
		playerHealth.OnDeath += PlayerDeathAnimation;
		playerKnockback.OnPlayerKnockback += PlayDizzyAnimation;
	}

    private void PlayMoveAnimation(float movementStrength){
		if(movementStrength == 0){
			//Play Idle
		}   
		else{
			//Play Movement
		}
    }

    private void PlayDizzyAnimation(object sender, EventArgs e){

    }

    private void PlayerDeathAnimation(object sender, EventArgs e){

    }
}

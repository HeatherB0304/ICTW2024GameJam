using System;
using UnityEngine;

public class KnightAnimator : MonoBehaviour {
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerKnockback playerKnockback;
    [SerializeField] private Health playerHealth;

    private Animator knightAnimator;

    private void Start() {
        playerMovement.OnMove += PlayMoveAnimation;
        playerHealth.OnDeath += PlayerDeathAnimation;
        playerKnockback.OnPlayerKnockback += PlayDizzyAnimation;
        knightAnimator = GetComponent<Animator>(); // Assuming Animator is attached to the same GameObject as this script.
    }

    private void OnDestroy() {
        playerMovement.OnMove -= PlayMoveAnimation;
        playerHealth.OnDeath -= PlayerDeathAnimation;
        playerKnockback.OnPlayerKnockback -= PlayDizzyAnimation;
    }

    private void PlayMoveAnimation(float movementStrength) {
        // Set the "IsMoving" parameter in the animator based on movementStrength.
        knightAnimator.SetBool("IsMoving", movementStrength != 0);
    }

    private void PlayDizzyAnimation(object sender, EventArgs e) {
        // Set the "IsDizzy" parameter in the animator to true when hit by a stun item.
        knightAnimator.SetBool("IsDizzy", true);
    }

    private void PlayerDeathAnimation(object sender, EventArgs e) {
        // Set the "IsDead" trigger in the animator to transition to the death animation.
        knightAnimator.SetTrigger("IsDead");
    }
}

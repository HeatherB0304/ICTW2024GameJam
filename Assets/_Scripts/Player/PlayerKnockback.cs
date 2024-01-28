using System;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour{
	[SerializeField] private float playerMass = 3f;

	private Vector3 impact = Vector3.zero;

	private CharacterController playerCharacterController;
	private Health playerHealth;

	private bool isDead = false;

	public EventHandler OnPlayerKnockback;

	private void Awake() {
		TryGetComponent(out playerCharacterController);
		TryGetComponent(out playerHealth);
	}

	private void Start() {
		playerHealth.OnDeath += OnDeath;
		playerHealth.OnRespawn += OnRespawn;
	}

    private void OnRespawn(object sender, EventArgs e){
		isDead = false;
    }

    private void OnDeath(object sender, EventArgs e){
		isDead = true;
		impact = Vector3.zero;
    }

    public void AddKnockBackToPlayer(Vector3 direction, float knockBackStrength){
        direction.Normalize();
        if (direction.y < 0) direction.y = -direction.y; // reflect down force on the ground
        impact += direction.normalized * knockBackStrength / playerMass;
		OnPlayerKnockback?.Invoke(this, EventArgs.Empty);
    }

	private void Update() {
		if(isDead) return;

		if(impact.magnitude > 0.2f){
			playerCharacterController.Move(impact * Time.deltaTime);
			// consumes the impact energy each cycle:
			impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
		} 
	}
}

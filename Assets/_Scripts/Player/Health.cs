using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{
	public event EventHandler OnHealthValueChanged;
	public event EventHandler OnDeath;
	public event EventHandler OnRespawn;

	public class DamageRecievedEventArgs : EventArgs{
		public float damageTaken;
		public DamageRecievedEventArgs(float _damageTaken){
			damageTaken = _damageTaken;
		}
	}

	[SerializeField] private float maxHealth;

	[SerializeField] private float respawnTime;

	private float currentHealth;

	private PlayerManager playerManager;
	private Player currentPlayer;

	private bool isDead = false;

	private void Awake() {
		currentHealth = maxHealth;
	}

	private void Start() {
		playerManager = PlayerManager.Instance;
		OnHealthValueChanged?.Invoke(this, null);
	}

	public void DealDamage(float amount){
		currentHealth -= amount;
		if(currentHealth <= 0){
			Die();
			return;
		}
		else{
			OnHealthValueChanged?.Invoke(this, new DamageRecievedEventArgs(amount));
		}
	}

	public void Die(){
		if(isDead) return;
		isDead = true;
		OnDeath?.Invoke(this, EventArgs.Empty);
		currentPlayer ??= playerManager.GetPlayerFromPlayerInput(gameObject.GetComponent<PlayerInput>());
		currentPlayer.currentDeathCount++;

		StartCoroutine(RespawnTimer());
	}

	public void Respawn(){
		playerManager.ResetPlayerPosition(currentPlayer);
		
		isDead = false;
		currentHealth = maxHealth;
		OnRespawn?.Invoke(this, EventArgs.Empty);
		OnHealthValueChanged?.Invoke(this, EventArgs.Empty);
	}

	public IEnumerator RespawnTimer(){
		yield return new WaitForSeconds(respawnTime);
		Respawn();
	}

	public float GetHealthTarget(){
		return currentHealth / maxHealth;
	}
}

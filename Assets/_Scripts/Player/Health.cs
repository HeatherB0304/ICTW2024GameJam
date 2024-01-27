using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	public event EventHandler OnDamageRecieved;
	public event EventHandler OnDeath;

	public class DamageRecievedEventArgs : EventArgs{
		public float damageTaken;
		public DamageRecievedEventArgs(float _damageTaken){
			damageTaken = _damageTaken;
		}
	}

	[SerializeField] private float maxHealth;

	private float currentHealth;

	private void Awake() {
		currentHealth = maxHealth;
	}

	public void DealDamage(float amount){
		currentHealth -= amount;
		if(currentHealth <= 0){
			OnDeath?.Invoke(this, EventArgs.Empty);
			return;
		}
		else{
			OnDamageRecieved?.Invoke(this, new DamageRecievedEventArgs(amount));
		}
	}
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour{
	public string PlayerName;
	public Image PlayerBackGround;
	public Image PlayerHeadShot;
	public Slider HealthBarSlider;
	public TextMeshProUGUI PlayerDeathCount;

	[Header("UI Settings")]
	[SerializeField] private float healthFillSpeed; 

	private Health assignedHealth;

	private readonly float healthBarSnap = 0.005f;

	private float current;
	private float target;
	private float healthTarget;

	private bool updateHealthBar;

	private Player currentPlayer;

	private void Update() {
		if(updateHealthBar){
			HealthBarTick();
		}
	}

	public void SetupPlayerUI(Player player, KnightPrefabList prefabList){
		PlayerBackGround.color = prefabList.GetColorFromKnightColor(player.knightColor);
		PlayerHeadShot.sprite = prefabList.GetKnightImage(player.knightColor);
		assignedHealth = player.assignedPlayerInput.GetComponent<Health>();
		currentPlayer = player;
		assignedHealth.OnHealthValueChanged += UpdatePlayerHeath;
		assignedHealth.OnDeath += UpdatePlayerDeathCount;
	}

    private void OnDestroy() {
		if(assignedHealth != null){
			assignedHealth.OnHealthValueChanged -= UpdatePlayerHeath;
			assignedHealth.OnDeath -= UpdatePlayerDeathCount;
		}
	}
	
    private void UpdatePlayerDeathCount(object sender, EventArgs e){
		PlayerDeathCount.text = currentPlayer.currentDeathCount.ToString("000");
    }

	private void UpdatePlayerHeath(object sender, EventArgs e){
       healthTarget = assignedHealth.GetHealthTarget();
	   target = 1;
	   updateHealthBar = true;
    }

	private void HealthBarTick(){
		current = Mathf.MoveTowards(current, target, healthFillSpeed * Time.deltaTime);
		HealthBarSlider.value = Mathf.Lerp(HealthBarSlider.value, healthTarget, current);
		//if close enough snap to the target
		if(Mathf.Abs(HealthBarSlider.value - healthTarget) <= healthBarSnap){
			target = 0;
			current = 0;
			HealthBarSlider.value = healthTarget;
			updateHealthBar = false;
		} 
	}
}

using UnityEngine;

public class BombPartyItemObject : PartyItemObject
{
    [Header("Player References")]
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private GameObject explosionPrefab; // Drag and drop the explosion prefab here.

    public void Explode(BombPartyItem bombPartyItem)
    {
        var players = Physics.OverlapSphere(transform.position, bombPartyItem.bombRadius, playerLayerMask);

        foreach (var player in players)
        {
            // Get playerknockback
            var playerKnockback = player.GetComponent<PlayerKnockback>();
            // Get the direction away from the player
            Vector3 knockBackDir = transform.position - player.transform.position + Vector3.up;
            playerKnockback.AddKnockBackToPlayer(-knockBackDir, bombPartyItem.knockBackStrength);

            var playerHealth = player.GetComponent<Health>();
            playerHealth.DealDamage(bombPartyItem.bombDamage);
        }

        // Remove the party item from the scene
        DeletePartyItem();
    }

    public void DeletePartyItem()
    {
        // Instantiate the explosion prefab at the current position
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Destroy the current object
        Destroy(gameObject);
    }
}

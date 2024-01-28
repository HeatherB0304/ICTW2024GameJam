using UnityEngine;

//this script should be attached to both portal objects
//drag and drop the destination portal in the inspector
//make sure collider is set to "Is Trigger"

public class PortalTeleporter : MonoBehaviour
{
    public Transform destinationPortal; // Drag and drop the destination portal's transform here
    public float teleportCooldown = 2f; 

    private float lastTeleportTime = -Mathf.Infinity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Time.time > lastTeleportTime + teleportCooldown) //Could also do a bool idk
        {
            TeleportPlayer(other.transform);
        }
    }

    private void TeleportPlayer(Transform playerTransform)
    {
        playerTransform.position = destinationPortal.position;
        lastTeleportTime = Time.time;
    }
}

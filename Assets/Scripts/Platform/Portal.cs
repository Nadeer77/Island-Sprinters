using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    public Transform destinationPortal; // Assign in Inspector

    public float cooldownTime = 0.5f; // Prevents instant re-teleportation

    private bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canTeleport && other.CompareTag("Player"))
        {
            // Disable destination portal's teleporter briefly to prevent instant back-teleport
            Portal destinationPortalScript = destinationPortal.GetComponent<Portal>();
            if (destinationPortalScript != null)
            {
                destinationPortalScript.DisableTeleportTemporarily(cooldownTime);
            }
            
            // Teleport player
            other.transform.position = destinationPortal.position;
        }
    }

    // Called by other portal to disable teleport for a cooldown window
    public void DisableTeleportTemporarily(float time)
    {
        StartCoroutine(TeleportCooldown(time));
    }

    private IEnumerator TeleportCooldown(float time)
    {
        canTeleport = false;
        yield return new WaitForSeconds(time);
        canTeleport = true;
    }
}
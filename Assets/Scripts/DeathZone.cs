using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;
    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.instance.currentHealth = 0;
            PlayerHealth.instance.healthBar.SetHealth(PlayerHealth.instance.currentHealth);
            DieEau();
        }
    }
    public void DieEau()
    {
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Death");
        PlayerMovement.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
        AttackHitBox.instance.enabled = false;

    }
}

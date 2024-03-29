using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float startHealth = 100;
    private float health;
    public int earnedMoney = 50;
    public GameObject deathEffect;
    
    [Header("Unity stuff")]
    public Image healthBar;

    private bool isDead = false;
    void Start() {

        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float amount) {
        
        speed = startSpeed * (1f-amount);
    }

    void Die()
    {
        isDead = true;
        PlayerStats.Money += earnedMoney;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public HealthBar playerHealthBar;
    public HealthBar enemyHealthBar;

    private int maxHealth = 100;
    [SerializeField] int playerHealth;
    [SerializeField] int enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        playerHealthBar.SetMaxHealth(playerHealth);
        playerHealthBar.SetHealth(playerHealth);

        enemyHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(enemyHealth);
        enemyHealthBar.SetHealth(enemyHealth);
    }

    public void DamagePlayer(int dmg)
    {
        playerHealth -= dmg;
        playerHealthBar.SetHealth(playerHealth);
    }

    public void DamageEnemy(int dmg)
    {
        enemyHealth -= dmg;
        enemyHealthBar.SetHealth(enemyHealth);
    }
}

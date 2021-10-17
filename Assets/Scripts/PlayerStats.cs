using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public HealthBar playerHealthBar;
    public HealthBar enemyHealthBar;

    public Text gameOverText;
    public Button backToMenuButton;

    public GameObject questionUI;

    private int maxHealth = 100;
    [SerializeField] int playerHealth;
    [SerializeField] int enemyHealth;

    private void Awake()
    {
        gameOverText.gameObject.SetActive(false);
        backToMenuButton.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        backToMenuButton.onClick.AddListener(GotoMainMenu);

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
        if (playerHealth <= 0)
        {
            SetGameOverScreenVisible("Defeat...");
        }
    }

    public void DamageEnemy(int dmg)
    {
        enemyHealth -= dmg;
        enemyHealthBar.SetHealth(enemyHealth);
        if (enemyHealth <= 0)
        {
            SetGameOverScreenVisible("Victory!");
        }
    }

    void SetGameOverScreenVisible(string text)
    {
        gameOverText.text = text;
        gameOverText.gameObject.SetActive(true);
        backToMenuButton.gameObject.SetActive(true);
        questionUI.SetActive(false);
    }

    void GotoMainMenu()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
}

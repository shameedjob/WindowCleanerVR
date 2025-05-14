using UnityEngine;

public class Player : MonoBehaviour {
    public float maxHealth = 100f;
    public float currentHealth;

    public HealthBar healthBar;

    void Start() {
        currentHealth = maxHealth; 
        healthBar.SetMaxHealth(maxHealth);  
    }

}

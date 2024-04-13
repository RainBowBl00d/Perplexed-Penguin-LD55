using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Property's
    public int health;

    // Health Mechanics
    public void SubtractHealt( int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0) Death();
    }
    public void AddHealth(int amountHealed)
    {
        health += amountHealed;
    }
    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void Death()
    {
        SceneManager.LoadScene (sceneName:"GameOver");
        Destroy(gameObject);
        
    }
}

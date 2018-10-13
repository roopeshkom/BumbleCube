using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_controller : MonoBehaviour {

    public int initialHealth;
    private int health;
    private TextMesh healthUI;

    void Start()
    {
        health = initialHealth;
        healthUI = gameObject.GetComponentInChildren<TextMesh>();
    }

    private void Update()
    {
        healthUI.text = health.ToString();

        if (health <= 0){
            Destroy(gameObject);
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damage)
    {
        health -= damage;
    }

    public void Heal(int healing)
    {
        if(health+healing > initialHealth)
        {
            health = initialHealth;
        }
        else
        {
            health += healing;
        }
    }
}

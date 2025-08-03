using UnityEngine;

public class HealthManager : MonoBehaviour
{

    [SerializeField] float health = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //getters & setters

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }

    public void AddHealth(float healthToAdd)
    {
        health += healthToAdd;
    }

    public void RemoveHealth(float healthToRemove)
    {
        health -= healthToRemove;
    }
}

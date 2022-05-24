using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    // This is the current value of the health#
    private int hv;
    public int Value
    {
        // Limit number from going below zero.
        get { return hv; }
        private set { hv = value > 0 ? value : 0; }
    }
    
    // Starting Health
    public int startingHealth = 10;
    
    // The amount of damage one 
    public int interval = 1;

    /// <summary>
    /// Setup the basic health basics
    /// </summary>
    private void Start()
    {
        Value = startingHealth;
    }

    private void Update()
    {
        if (Value == 0)
        {
            print("This entity is dead lol, handle some killing here...");
        }
    }

    /// <summary>
    /// Takes damage from a player
    /// </summary>
    public void TakeDamage()
    {
        Value -= interval;
    }

    /// <summary>
    /// Takes damage from a player
    /// </summary>
    /// <param name="multiplier">How much more impact, this is multiplied by the standard impact</param>
    public void TakeDamage(int multiplier)
    {
        Value -= (interval * multiplier);
    }

    /// <summary>
    /// Resets the health of the player.
    /// </summary>
    public void Regenerate()
    {
        Value = startingHealth;
    }
    
    /// <summary>
    /// Increases the players health by value.
    /// Will cap out at the starting health. 
    /// </summary>
    /// <param name="x">How much to increase by.</param>
    public void Regenerate(int x)
    {
        if (x > startingHealth)
            Value = startingHealth;
        else
            Value += x;
    }

    public void Kill()
    {
        Value = 0;
    }
}

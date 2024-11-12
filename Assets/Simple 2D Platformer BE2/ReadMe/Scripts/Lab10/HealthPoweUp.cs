using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoweUp : PowerUp
{
    int healthincrease;

    private void Start()
    {
        healthincrease = 20;
    }

    public override void ApplyPowerUp(Player player)
    {
        player.PowerUp(healthincrease);
    }
}

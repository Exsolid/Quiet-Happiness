using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoleMinigameEventmanager : Module
{
    public Action<float, int> hit;

    public void Hit(float delay, int ID)
    {
        if(hit != null)
        {
            hit(delay, ID);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Pistol
{

    void Start()
    {
        //Задержка между выстрелами
        cooldown = 0.2f;
        auto = true;
    }

   
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swampy : Enemy
{
    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
    }
}

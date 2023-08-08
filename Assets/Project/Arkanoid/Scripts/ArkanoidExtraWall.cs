using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidExtraWall : MonoBehaviour, IDamagable
{
    public void Damage()
    {
        Destroy(this.gameObject);
    }
}

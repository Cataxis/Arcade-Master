using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidExtraLife : MonoBehaviour, IDamagable
{
    [SerializeField] GameObject extraLife;
    public void Damage()
    {
        extraLife.SetActive(true);
        Destroy(this.gameObject);
    }
}

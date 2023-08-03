using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{
    public void Damage()
    {
        //Sonido de bloque
        Destroy(gameObject);
    }
}

using UnityEngine;

public class ArkanoidWall : MonoBehaviour, IDamagable
{
    public void Damage()
    {
        ArkanoidGameManager.Instance.Effects.ToggleColors();
        ArkanoidGameManager.Instance.Effects.ShakeCamera();
       
    }
}

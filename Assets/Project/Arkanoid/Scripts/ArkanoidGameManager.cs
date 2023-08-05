using UnityEngine;

public class ArkanoidGameManager : MonoBehaviour
{
    #region Singleton
    public static ArkanoidGameManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField] private LevelSO levels;

    public ArkanoidEffectController Effects { get; private set;}
    private int blocksLeft = 0;

    private void Start()
    {
        Effects = GetComponentInChildren<ArkanoidEffectController>();
        UpdateBlockCount();
    }


    public void BlockDestroyed()
    {
        blocksLeft--;
        if(blocksLeft <= 0) Win();              
    }

    public void Win()
    {
        Debug.Log("<color=green>YOU WIN!</color>");
    }
    public void Loose()
    {
        Debug.Log("<color=red>YOU LOOSE!</color>");
    }

    private void UpdateBlockCount()
    {
        ArkanoidBlock[] currentBlocks = FindObjectsOfType<ArkanoidBlock>();
        blocksLeft = currentBlocks.Length;
    } 

}
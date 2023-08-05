using UnityEngine;

[CreateAssetMenu(fileName = "New Levels", menuName = "Game Levels")]
public class LevelSO : ScriptableObject
{
    [SerializeField] private string[] Levels;
}

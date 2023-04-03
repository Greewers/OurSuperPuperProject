using UnityEngine;

[CreateAssetMenu(fileName = "SpawnSettings", menuName = "SpawnSettings")]
public class SpawnSettings :ScriptableObject 
{
    public int MaxBombCount = 5;
    public int MaxShieldCount = 1;
}

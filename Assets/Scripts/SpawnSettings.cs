using UnityEngine;

[CreateAssetMenu(fileName = "SpawnSettings", menuName = "SpawnSettings")]
public class SpawnSettings :ScriptableObject 
{
    public int MaxBombCount = 10;
    public int MaxShieldCount = 3;
}

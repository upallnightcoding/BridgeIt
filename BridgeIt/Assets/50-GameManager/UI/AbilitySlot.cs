using UnityEngine;

[CreateAssetMenu(fileName="AbilitySlot", menuName="Bridge It/Ability Slot")]
public class AbilitySlot : ScriptableObject
{
    public int points;
    public int stack; 
    public Sprite sprite;
}

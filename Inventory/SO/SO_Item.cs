using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/New Item")]
public class SO_Item : ScriptableObject
{
    [field:SerializeField] public string Name {  get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField][TextArea] public string Description { get; private set; }
}

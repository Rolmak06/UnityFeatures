using UnityEngine;

public class Socket : MonoBehaviour
{
    public enum SocketType
    {
        Weapon,
        Armor
    }

    public bool IsEmpty;
    public SocketType Type;

    private GameObject equippedInstance;
    
    public void Equip(SO_Equipable equipable)
    {
        equippedInstance = Instantiate(equipable.Prefab, transform.position, transform.rotation, transform);
    }

    public void Unequip(SO_Equipable equipable)
    {
        Destroy(equippedInstance);
    }
}

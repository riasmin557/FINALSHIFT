using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>();

    public int quantidadeSlots = 20;

    private void Awake()
    {
        for (int i = 0; i < quantidadeSlots; i++)
        {
            slots.Add(new InventorySlot());
        }
    }
}
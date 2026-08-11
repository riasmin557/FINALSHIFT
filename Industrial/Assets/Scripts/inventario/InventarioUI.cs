using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;

    public SlotUI[] slotsUI;

    void Start()
    {
        AtualizarInventario();
    }

    public void AtualizarInventario()
    {
        for (int i = 0; i < slotsUI.Length; i++)
        {
            slotsUI[i].AtualizarSlot(inventory.slots[i]);
        }
    }
}

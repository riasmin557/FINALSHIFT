using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image icone;
    public TMP_Text quantidadeTexto;

    public void AtualizarSlot(InventorySlot slot)
    {
        if (slot.item == null)
        {
            icone.enabled = false;
            quantidadeTexto.text = "";
            return;
        }

        icone.enabled = true;
        icone.sprite = slot.item.icone;

        if (slot.quantidade > 1)
            quantidadeTexto.text = slot.quantidade.ToString();
        else
            quantidadeTexto.text = "";
    }
}

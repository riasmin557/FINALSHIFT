using UnityEngine;

[CreateAssetMenu(fileName = "Novo Item", menuName = "Inventario/Item")]
public class Item : ScriptableObject
{
    public string nomeItem;

    public Sprite icone;

    [TextArea]
    public string descricao;

    public bool empilhavel = true;

    public int quantidadeMaxima = 10;

    public int cura = 0;
}
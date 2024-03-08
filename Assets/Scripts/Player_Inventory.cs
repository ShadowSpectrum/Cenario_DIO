using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    private Dictionary<string, int> items;

    // Start is called before the first frame update
    void Awake()
    {
        // Cria o Dicionário responsável pelo inventário;
        items = new Dictionary<string, int>();
    }

    public void additem(string name, int quantity)
    // Função responsável pela adição de Itens no Inventário
    {
        Debug.Log("additem");

        // Se o item já existir no inventário...
        if (items.ContainsKey(name))
        {
            //...adiciona quantidade ao item;
            items[name] += quantity;
        }
        else
        {
            //Caso contrário adiciona o item, na quantidade obtida, ao inventário;
            items.Add(name, quantity);
        }
        // [REMOVER EM PRODUÇÂO] Imprime no Console os itens presentes no inventário;
        foreach (KeyValuePair<string, int> item in items)
        {
            Debug.Log(item.Key + " : " + item.Value);
        }
    }

    public int search(string name)
    // Função responsável por localizar a presença de um item no inventário;
    {
        if (items.ContainsKey(name))
        {
            Debug.Log(items.ContainsKey(name));
            return 1;
        }
        else
        {
            return 0;
        }

    }

    public void itemrmv(string name, int quantity)
    // Função responsável por eliminar quantidade/um item do inventário;
    {


        //Caso o item exista...
        if (items.ContainsKey(name))
        {
            //...remove a quantidade do item;
            items[name] -= quantity;

            // Caso a quantidade chegue a zero...
            if (items[name] <= 0)
            {
                //remove o item do inventário;
                items.Remove(name);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    private Dictionary<string, int> items;

    // Start is called before the first frame update
    void Awake()
    {
        // Cria o Dicion�rio respons�vel pelo invent�rio;
        items = new Dictionary<string, int>();
    }

    public void additem(string name, int quantity)
    // Fun��o respons�vel pela adi��o de Itens no Invent�rio
    {
        Debug.Log("additem");

        // Se o item j� existir no invent�rio...
        if (items.ContainsKey(name))
        {
            //...adiciona quantidade ao item;
            items[name] += quantity;
        }
        else
        {
            //Caso contr�rio adiciona o item, na quantidade obtida, ao invent�rio;
            items.Add(name, quantity);
        }
        // [REMOVER EM PRODU��O] Imprime no Console os itens presentes no invent�rio;
        foreach (KeyValuePair<string, int> item in items)
        {
            Debug.Log(item.Key + " : " + item.Value);
        }
    }

    public int search(string name)
    // Fun��o respons�vel por localizar a presen�a de um item no invent�rio;
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
    // Fun��o respons�vel por eliminar quantidade/um item do invent�rio;
    {


        //Caso o item exista...
        if (items.ContainsKey(name))
        {
            //...remove a quantidade do item;
            items[name] -= quantity;

            // Caso a quantidade chegue a zero...
            if (items[name] <= 0)
            {
                //remove o item do invent�rio;
                items.Remove(name);
            }
        }
    }

}

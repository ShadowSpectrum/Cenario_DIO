using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    // Quantidade de Item;
    [SerializeField] int quantity = 1;
    // Tipo de Intera��o, controla qual tratamento o item vai receber quando o usu�rio interagir com ele. Essa defini��o afeta o switch case no metodo 'interaction';
    [SerializeField] int interaction_type;
    // Recebe o nome do item necess�rio para concretizar a intera��o;
    [SerializeField] string requisito;
    //Type 1 - Basic Interation, ou intera��o b�sica, Usada para retornar uma fala/texto ao jogador;
    //Type 2 - Invetory Interaction, usada para coletar Itens;
    //Type 3 - Intermedi�rio de Intera��o necess�rio (Ex: Porta que precisa de chave, etc...);

    public void interaction()
    {
        // Quando o jogador interage com o objeto, entrega o tratamento correto baseado no tipo de intera��o configurada;
        switch (interaction_type)
        {
            case 1:
                Debug.Log("Isso � um " + gameObject.name);
                break;

            case 2:
               Player_Inventory playerinventory = cripfind();
                // Invoca o metodo 'additem' para adicionar o item ao invent�rio;
                playerinventory.additem(gameObject.name, quantity);
                // Destroi o modelo do item no mundo;
                Destroy(gameObject);
                break;

            case 3:
                Player_Inventory playerinventory_ = cripfind();
                // Invoca o metodo 'additem' para adicionar o item ao invent�rio;
                if (playerinventory_.search(requisito) == 1)
                {
                    //...executa o c�digo;
                    Debug.Log("Ok?");
                }
                // Caso o item necess�rio n�o exista no invent�rio...
                else
                {

                    Debug.Log("Not ok...");
                }
                break;
            //Caso o tratamento n�o tenha sido configurado corretamente... Me avisa no console :)
            default:
                Debug.Log("Esqueceu de Declarar o Caso de Intera��o");
                break;

        }

    }

    private Player_Inventory cripfind()
    {
        // Localiza o GameObject do invent�rio
        GameObject Inventario = GameObject.Find("Inventario");
        //Obtem o Script Componente "Player_Inventory" e adiciona a uma variavel local "playerinventory"
        Player_Inventory playerinventory = Inventario.GetComponent<Player_Inventory>();
        // Invoca o metodo 'additem' para adicionar o item ao invent�rio;

        return playerinventory;
    }
}

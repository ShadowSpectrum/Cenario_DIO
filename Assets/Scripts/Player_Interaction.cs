using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    // Quantidade de Item;
    [SerializeField] int quantity = 1;
    // Tipo de Interação, controla qual tratamento o item vai receber quando o usuário interagir com ele. Essa definição afeta o switch case no metodo 'interaction';
    [SerializeField] int interaction_type;
    // Recebe o nome do item necessário para concretizar a interação;
    [SerializeField] string requisito;
    //Type 1 - Basic Interation, ou interação básica, Usada para retornar uma fala/texto ao jogador;
    //Type 2 - Invetory Interaction, usada para coletar Itens;
    //Type 3 - Intermediário de Interação necessário (Ex: Porta que precisa de chave, etc...);

    public void interaction()
    {
        // Quando o jogador interage com o objeto, entrega o tratamento correto baseado no tipo de interação configurada;
        switch (interaction_type)
        {
            case 1:
                Debug.Log("Isso é um " + gameObject.name);
                break;

            case 2:
               Player_Inventory playerinventory = cripfind();
                // Invoca o metodo 'additem' para adicionar o item ao inventário;
                playerinventory.additem(gameObject.name, quantity);
                // Destroi o modelo do item no mundo;
                Destroy(gameObject);
                break;

            case 3:
                Player_Inventory playerinventory_ = cripfind();
                // Invoca o metodo 'additem' para adicionar o item ao inventário;
                if (playerinventory_.search(requisito) == 1)
                {
                    //...executa o código;
                    Debug.Log("Ok?");
                }
                // Caso o item necessário não exista no inventário...
                else
                {

                    Debug.Log("Not ok...");
                }
                break;
            //Caso o tratamento não tenha sido configurado corretamente... Me avisa no console :)
            default:
                Debug.Log("Esqueceu de Declarar o Caso de Interação");
                break;

        }

    }

    private Player_Inventory cripfind()
    {
        // Localiza o GameObject do inventário
        GameObject Inventario = GameObject.Find("Inventario");
        //Obtem o Script Componente "Player_Inventory" e adiciona a uma variavel local "playerinventory"
        Player_Inventory playerinventory = Inventario.GetComponent<Player_Inventory>();
        // Invoca o metodo 'additem' para adicionar o item ao inventário;

        return playerinventory;
    }
}

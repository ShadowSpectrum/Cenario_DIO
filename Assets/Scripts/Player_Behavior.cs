using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Behavior : MonoBehaviour
{
    // Variavel para armazenar o valor de chamada do Input Siystem;
    //public Vector2 movevar;
    // Velocidade de movimento do Jogador;
    public float mvspeed;
    private float basespeed;
    // Variaveis privadas intermediarias para armazenamewnto do movimento do jogador;
    private float movementx;
    private float movementy;
    public bool isrunning;

    // Booleana de Stamina, oriunda do script Player_Sprint
    public Player_Sprint stamina;




    // Start is called before the first frame update

    void Start()
    {   
        // Obtem o valor base da variavel mvspeed;
        basespeed = mvspeed;
    }


    void OnBasic_Move(InputValue value) // Metodo Invocado pelo Asset de Input, toda vez que é realizada a anetrada de input compativel com a Action Basic Move;
    {
        Console.WriteLine("Move");
        // Obtem o valor de movimento da entrada em Vector2;
        Vector2 movevar = value.Get<Vector2>();

        // Recebem os valores de movimento em X e Y;       
        movementx = movevar.x;
        movementy = movevar.y;

        Console.WriteLine("Amigo estou aqui");
    }

    void OnSprint(InputValue value) //Metodo invocado pelo Unity Input Sistem ao ser pressionada a tecla Shift;
    {   

        /* Funcionalidade Corrida: 
        Quando o botão de sprint é pressionado aciona o metodo "OnSprint", no script 'Player_Behavior'. É feita uma verificação se, no momento que o input foi pressionado, o jogador tem stamina.
        Isso é feito a partir da booleana "stamina" do script 'Player_Sprint' que representa presença de stamina quando true e altera como false quando atinge zero, liberando-a somente quando
        estiver completamente restabelecida. O metodo FixedUpdate do Script 'Player_Behavior' checa ativamente o status da stamina, travando o sprint caso ela acabe. O usuário deve pressionar 
        novamente o Input de correr quando a stamina estiver recuperada, para que possa correr novamente*/

        // Obtem o float inidicando o precionamento da tecla;
        float sprint = value.Get<float>();


        // Caso o botão de de Sprint for precionado...
        if (sprint == 1)
        {
            // ...e o jogador tiver estamina...
            if (stamina.stamina == true)
            {
                // Altera o Parametro de velocidade para o dobro da velocidade base;
                mvspeed = basespeed * 2;
                // Avisa o 'Player_Sprint' que o jogador está correndo e deve consumir stamina;
                isrunning = true;
            }
        }
        else // caso o Input de sprint seja liberado, reseta a velocidade para a padrão;
        {
            mvspeed = basespeed;
            isrunning = false;
        }



    }

    void OnInteraction(InputValue value)
    {
        float interac = value.Get<float>();


        if (interac == 1)
        {
            // Gera o Raio a partir da posição do cursos, que está travada no centro da tela pelo script "Camera_Control"
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            

            if (Physics.Raycast(ray, out hit, 10f))
            {
                string tag = hit.collider.tag;
                if (tag == "Interactable")
                {
                    Player_Interaction activation = hit.collider.gameObject.GetComponent<Player_Interaction>();
                    activation.interaction();
                }
                
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        /*MOVIMENTO
         Realiza a alteração de posição do objeto player, baseando-se nos valores de X e Y(Aqui na posição Z) do retorno de input;*/
        transform.Translate(new Vector3(movementx, 0f, movementy) * mvspeed * Time.deltaTime);

        /* STAMINA
        Checa ativamente se o jogador possui stamina para continuar correndo, caso ela atinja false, bloqueia o sprint;*/
        if (stamina.stamina == false)
        {
            mvspeed = basespeed;
            isrunning = false;
        }
    }

    private void FixedUpdate()
    {

    }


}

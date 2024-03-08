using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sprint : MonoBehaviour
{
    private float stamin_lv;
    [SerializeField]private float max_stamin;
    public bool stamina = true;

    public Player_Behavior player_behavior;

    // Start is called before the first frame update
    void Start()
    {
         stamin_lv = max_stamin;
    }

    // Update is called once per frame
    void Update()
    {
        // Se o jogador estiver correndo...
        if (player_behavior.isrunning == true)
        {
            //...e sua estamina for diferente de zero, consome stamina;
            if (stamin_lv >= 0)
            {
                stamin_lv -= 2;
            }
            //... e sua estamina for zero, seta a booleana de corrida para false;
            else
            {
                stamina = false;
            }
        }
        //Caso o jogador não esteja correndo...
        if (player_behavior.isrunning == false)
        {
            //... se a estamina não estiver cheia, regenera stamina;
            if (stamin_lv < max_stamin)
            {
                stamin_lv += 1;
            }
        }
        //Caso a booleana de estamina esteja desativada...
        if (stamina == false)
        {
            //... verifica se a stamina está cheia, antes de liberar novamente a corrida;
            if (stamin_lv == max_stamin)
            {
                stamina = true;
            }
        }

    }

}


/* Funcionalidade Corrida: 
Quando o botão de sprint é pressionado aciona o metodo "OnSprint", no script 'Player_Behavior'. É feita uma verificação se, no momento que o input foi pressionado, o jogador tem stamina.
Isso é feito a partir da booleana "stamina" do script 'Player_Sprint' que representa presença de stamina quando true e altera como false quando atinge zero, liberando-a somente quando
estiver completamente restabelecida. O metodo FixedUpdate do Script 'Player_Behavior' checa ativamente o status da stamina, travando o sprint caso ela acabe. O usuário deve pressionar 
novamente o Input de correr quando a stamina estiver recuperada, para que possa correr novamente*/
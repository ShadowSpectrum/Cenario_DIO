using UnityEngine;
using UnityEngine.InputSystem;

public class Camera_Control : MonoBehaviour
{
    [SerializeField] Transform Player;   // Referência ao objeto jogador
    public float smoothing = 5f;   // Suavização do movimento da câmera

    [SerializeField]float minViewDist = 25f; //Distância de Visão Minima;
    [SerializeField]float sensitivity = 100f; //Sensibilidade do Mouse;
    float xRotation = 0f; // Variavel float responsável pela atualização Horizontal;
    float yRotation = 0f; // Variavel float responsável pela atualização Vertical;
    Vector3 offset;

    private void Start()
    {
        // Calcula a diferença inicial entre a posição da câmera e do jogador
        offset = transform.position - Player.position;

        // Trava o cursor no centro tela;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Obtem o a entrada do mouse a partir do método "Get.Axis", do InputSistem, e a armazena nas variaveis;
          float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
          float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Realiza a atualização do valor da posição da câmera. Inverter os valores de +/-, causa a inversão dos controles;
        xRotation += mouseX; //XRotation incrementa com o valor de MouseX; (0f + 1, + 1, -1)
        yRotation -= mouseY; //YRotation decrementa com o valor de MouseY;
        //Limita o movimento Vertical da Câmera;
        yRotation = Mathf.Clamp(yRotation, -90f, minViewDist);

        // Realiza as rotações da câmera basendo-se na atualização das variaveis;
        transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0f);
        // Rotaciona o objeto jogador junto com a câmera ao realizar movimentos na horizontal;
        Player.Rotate(Vector3.up * mouseX);
    }

    private void FixedUpdate()
    {
        // Calcula a posição desejada da câmera
        Vector3 targetCamPos = Player.position + offset;

        // Aplica suavização do movimento da câmera
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
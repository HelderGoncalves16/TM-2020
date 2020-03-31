using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(PlayerMotor))] //adicionar Rigid Body do Player Motor
public class PlayerController : MonoBehaviour
{

    // Movimento
    [SerializeField] //aparece no inspetor mesmo estando private
    private float speed = 5f;

    [SerializeField]
    private float sensiblidade = 3f; //default

    //Referencia ao Player Motor
    private PlayerMotor motor; // referencia ao Player Motor

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //calcular movimento, velocidade como um vetor 3D
        float xMov = Input.GetAxisRaw("Horizontal"); // -1 e 1
        float zMov = Input.GetAxisRaw("Vertical"); // -1 e 1

        Vector3 _movHorizontal = transform.right * xMov;
        Vector3 _movVertical = transform.forward * zMov;

        //vetor do movimento final
        Vector3 _velocity = (_movHorizontal + _movVertical) * speed;

        //Aplicar o movimento
        motor.Move(_velocity);

        //Calcular a rotação como vetor 3D, atraves do rato
        // Isto é para aplicar o rato unicamente no eixo do X olhar em volta
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * sensiblidade;

        //Aplicar a rotação no player
        motor.Rotate(_rotation);

        //-------------------------------------------------------
        float __xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(__xRot, 0f, 0f) * sensiblidade;

        //Aplicar a rotação no player
        motor.RotateCamera(_cameraRotation);
    }
}

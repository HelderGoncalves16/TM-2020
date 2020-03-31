using System;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Movimento do vetor
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //Rotação do vetor
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    //Corre todas as iterações fisicas
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

    }

    //Fazer o movimento conforme a variavel velocidade
    void PerformMovement()
    {
        if(velocity != Vector3.zero) //Verificar se a velocidade é 0
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
            if(cam != null)
            {
                cam.transform.Rotate(-cameraRotation); //o sinal menos significa para a camera nao ficar inversa
            }
        }
    }

}

using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionController : NetworkBehaviour
{
    public float speed;
    private Vector2 move;
    private NetworkVariable<Vector3> networkedPosition = new NetworkVariable<Vector3>(
        writePerm: NetworkVariableWritePermission.Owner);

    private Camera _mainCamera;


    private void Initialize()
    {
        _mainCamera = Camera.main;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Initialize();
    }

    private void Update()
    {
        if (IsOwner)
        {
            networkedPosition.Value = transform.position;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, networkedPosition.Value, Time.deltaTime * 10f);
        }
    }

    void FixedUpdate()
    {

        if (!IsOwner) return; 
        MovePlayer();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!IsOwner) return;
        move = context.ReadValue<Vector2>();
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}

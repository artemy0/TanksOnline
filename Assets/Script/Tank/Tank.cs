using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private PhotonView _photonView;


    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }


    private void Update()
    {
        if (_photonView.IsMine == false)
        {
            return;
        }


        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(transform.forward * verticalInput * movementSpeed * Time.deltaTime
            , Space.World);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}

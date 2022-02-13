using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private string simpleTankName;


    private void Start()
    {
        Vector3 tankPosition = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

        PhotonNetwork.Instantiate(simpleTankName, tankPosition, Quaternion.identity);
    }
}

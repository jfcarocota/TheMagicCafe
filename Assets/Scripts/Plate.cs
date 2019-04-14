using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{


    [SerializeField]
    bool isDelivered = false;


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Submit") && other.tag == "Player" && !isDelivered)
        {
            Player player = other.GetComponent<Player>();
            player.Anim.SetTrigger("Start bring");
            transform.parent = player.PlateTrans;
            transform.localPosition = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
            player.CurrentPlate = gameObject;
        }
    }

}

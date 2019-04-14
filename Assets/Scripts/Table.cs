using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField]
    bool hasClient = false;
    [SerializeField]
    private bool isEating = false;
    [SerializeField]
    Transform platePivot;

    public bool HasClient { get => hasClient; set => hasClient = value; }
    public bool IsEating { get => isEating; set => isEating = value; }
    public Transform PlatePivot { get => platePivot; set => platePivot = value; }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Submit") && other.tag == "Player" && hasClient)
        {
            Player player = other.GetComponent<Player>();
            if (player.CurrentPlate)
            {
                player.Anim.SetTrigger("End bring");
                player.CurrentPlate.transform.parent = null;
                player.CurrentPlate.transform.position = platePivot.position;
                player.CurrentPlate = null;
                IsEating = true;
            }
        }
    }
}

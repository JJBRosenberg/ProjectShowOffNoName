using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChair : MonoBehaviour
{
    public Transform newChair;
    private bool isInRange;
    [SerializeField] public GameObject oldChair;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            oldChair.gameObject.transform.position = newChair.position;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
        }
    }
}

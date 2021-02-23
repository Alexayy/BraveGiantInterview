using System;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public GameObject finalPlace;
    private bool isMoving;
    private bool isFinalPlacement;

    private float startPositionX;
    private float startPositionY;

    private Vector3 resetPosition;

    private float startRotation = 0.0f;
    private float maxTurnDegree = 45.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Da ne bude metoda prazna, buni mi se Rider :c");

        resetPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFinalPlacement)
        {
            if (isMoving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                gameObject.transform.localPosition = new Vector3(
                    mousePos.x - startPositionX,
                    mousePos.y - startPositionY,
                    gameObject.transform.localPosition.z
                );
            }
        }
    }

    private void OnMouseDown()
    {
        isMoving = true;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPositionX = mousePos.x - transform.localPosition.x;
            startPositionY = mousePos.y - transform.localPosition.y;

            GetComponent<SpriteRenderer>().sortingOrder++;
        } 
    }

    private void OnMouseUp()
    {
        isMoving = false;
        Vector3 localPos = finalPlace.transform.localPosition;
        Quaternion localRot = finalPlace.transform.rotation;
        
        if (Math.Abs(transform.localPosition.x - localPos.x) <= 0.5f && 
            Math.Abs(transform.localPosition.y - localPos.y) <= 0.5f && 
            Math.Abs(transform.rotation.z - finalPlace.transform.rotation.z) <= 0.35f)
        {
            transform.localPosition = new Vector3(localPos.x, localPos.y, localPos.z);
            transform.localRotation = new Quaternion(localRot.x, localRot.y, localRot.z, localRot.w);

            isFinalPlacement = true;
            GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else
        {
            transform.Rotate(startRotation, startRotation, maxTurnDegree); 
        }
    }
}
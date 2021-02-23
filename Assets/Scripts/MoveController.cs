using System;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public GameObject finalPlace;
    private bool moving;
    private bool isFinalPlacement;

    private float startPositionX;
    private float startPositionY;

    private Vector3 resetPosition;

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
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                gameObject.transform.localPosition = new Vector3(
                    mousePos.x - startPositionX,
                    mousePos.y - startPositionY,
                    gameObject.transform.localPosition.z
                );

                Debug.Log(
                    $"Nesto se desava - x: {startPositionX}, y: {startPositionY}. " +
                    $"U Update metodi. Ime objekta: {gameObject.name}");
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPositionX = mousePos.x - transform.localPosition.x;
            startPositionY = mousePos.y - transform.localPosition.y;

            moving = true;

            Debug.Log(
                $"Nesto se desava - x: {startPositionX}, y: {startPositionY}. " +
                $"U OnMouseDown metodi. Ime objekta: {gameObject.name}");
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if (Math.Abs(transform.localPosition.x - finalPlace.transform.localPosition.x) <= 0.5f &&
            Math.Abs(transform.localPosition.y - finalPlace.transform.localPosition.y) <= 0.5f)
        {
            Vector3 localPosition = finalPlace.transform.localPosition;
            transform.localPosition = new Vector3(
                localPosition.x,
                localPosition.y,
                localPosition.z
            );

            isFinalPlacement = true;
        }
        else
        {
            transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }
}
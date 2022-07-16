using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkContainer : MonoBehaviour
{
    [Header("Input Settings : ")]
    [SerializeField] private LayerMask markLayerMask;
    [SerializeField] private float touchRadius;


    private Board board;
    private Camera cam;

    public GameObject currentSelection;

    private void Start()
    {
        cam = Camera.main;
        board = FindObjectOfType<Board>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 touchPosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hit = Physics2D.OverlapCircle(touchPosition, touchRadius, markLayerMask);

            if (hit)//Mark from selection container
            {
                SelectMark(hit.GetComponent<Shape>());
            }
        }
    }

    private void SelectMark(Shape shape)
    {
        currentSelection = shape.gameObject;

        if (board.currentMark == Mark.X)
        {
            if (shape.size == 3)
            {
                board.currentMarkSizeToPlace = board.xBigMark;
            }
            else if (shape.size == 2)
            {
                board.currentMarkSizeToPlace = board.xMidMark;
            }
            else if (shape.size == 1)
            {
                board.currentMarkSizeToPlace = board.xSmallMark;
            }
        }
        else
        {
            if (shape.size == 3)
            {
                board.currentMarkSizeToPlace = board.oBigMark;
            }
            else if (shape.size == 2)
            {
                board.currentMarkSizeToPlace = board.oMidMark;
            }
            else if (shape.size == 1)
            {
                board.currentMarkSizeToPlace = board.oSmallMark;
            }
        }
          
    }
 }


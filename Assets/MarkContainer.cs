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
                //Llamado al m�todo de la modificaci�n del item.
                ModifyOnSelection(hit.GetComponent<SpriteRenderer>(), hit.GetComponent<CircleCollider2D>());
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

    //M�todo que modifica los items del tablero cuando se seleccionan. Usar una propiedad similar al borde o algo as�
    private void ModifyOnSelection(SpriteRenderer spriteRenderer_, CircleCollider2D collider)
    {
        spriteRenderer_ = currentSelection.GetComponent<SpriteRenderer>();
        
        collider = currentSelection.GetComponent<CircleCollider2D>();

        Color32 newColor;
        Color32 oldColor;
        newColor = new Color32(0, 255, 0, 255);
        oldColor = spriteRenderer_.color;

        if (currentSelection.tag == "1")
        {
            spriteRenderer_.color = newColor;
            
        }else if (collider.enabled == true && currentSelection.tag == "2")
        {
            spriteRenderer_.color = newColor;
        }
        else if (collider.enabled == true && currentSelection.tag == "3")
        {
            spriteRenderer_.color = newColor;
        }
        else if (collider.enabled == true && currentSelection.tag == "4")
        {
            spriteRenderer_.color = newColor;
        }
        else if (collider.enabled == true && currentSelection.tag == "5")
        {
            spriteRenderer_.color = newColor;
        }
        else if (collider.enabled == true && currentSelection.tag == "6")
        {
            spriteRenderer_.color = newColor;
        }
        else if (collider.enabled == true && currentSelection.tag == "7")
        {
            spriteRenderer_.color = newColor;
        }
        else if (collider.enabled == true && currentSelection.tag == "8")
        {
            spriteRenderer_.color = newColor;
        }
        else if (collider.enabled == true && currentSelection.tag == "9")
        {
            spriteRenderer_.color = newColor;
        }
        else if (collider.enabled == true && currentSelection.tag == "10")
        {
            spriteRenderer_.color = newColor;
        }
        else if (collider.enabled == true && currentSelection.tag == "11")
        {
            spriteRenderer_.color = newColor;
        }
        else if (collider.enabled == true && currentSelection.tag == "12")
        {
            spriteRenderer_.color = newColor;
        }
    }
 }


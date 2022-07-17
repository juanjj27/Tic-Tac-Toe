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
        //currentSelection = FindObjectOfType<GameObject>();
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
                //Llamado al método de la modificación del item.
                ModOnSelect();
                //ModifyOnSelection(hit.GetComponent<SpriteRenderer>(), hit.GetComponent<CircleCollider2D>());
            }
        }
    }

    private void SelectMark(Shape shape)
    {
        if(currentSelection != null)
        {
            if (currentSelection.tag == "1" && currentSelection.GetComponent<CircleCollider2D>().enabled == true)
            {
                currentSelection.GetComponent<SpriteRenderer>().color = new Color32(255, 68, 0, 255);
            }
            else if (currentSelection.tag == "2" && currentSelection.GetComponent<CircleCollider2D>().enabled == true)
            {
                currentSelection.GetComponent<SpriteRenderer>().color = new Color32(255, 124, 76, 255);
            }
            else if (currentSelection.tag == "3" && currentSelection.GetComponent<CircleCollider2D>().enabled == true)
            {
                currentSelection.GetComponent<SpriteRenderer>().color = new Color32(255, 180, 153, 255);
            }
            else if (currentSelection.tag == "4" && currentSelection.GetComponent<CircleCollider2D>().enabled == true)
            {
                currentSelection.GetComponent<SpriteRenderer>().color = new Color32(0, 159, 255, 255);
            }
            else if (currentSelection.tag == "5" && currentSelection.GetComponent<CircleCollider2D>().enabled == true)
            {
                currentSelection.GetComponent<SpriteRenderer>().color = new Color32(76, 188, 255, 255);
            }
            else if (currentSelection.tag == "6" && currentSelection.GetComponent<CircleCollider2D>().enabled == true)
            {
                currentSelection.GetComponent<SpriteRenderer>().color = new Color32(153, 217, 255, 255);
            }
        }
        

        currentSelection = shape.gameObject;

        if(board.currentMark == shape.mark)
        {
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
        else
        {
            Debug.Log("No es tu turno");
            currentSelection = null;
        }
    }

    //Método que modifica los items del tablero cuando se seleccionan. Usar una propiedad similar al borde o algo así
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

    private void ModOnSelect()
    {
        if(currentSelection != null)
        {
            currentSelection.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 255);
        }
        else
        {
            Debug.Log("No es tu turno");
        }
    }
 }


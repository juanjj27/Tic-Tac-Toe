using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [Header("Input Settings: ")]
    [SerializeField] private LayerMask boxesLayerMask;
    [SerializeField] private float touchRadius;

    [Header("Mark Sprites: ")]
    [SerializeField] public GameObject xBigMark;
    [SerializeField] public GameObject oBigMark;
    [SerializeField] public GameObject xMidMark;
    [SerializeField] public GameObject oMidMark;
    [SerializeField] public GameObject xSmallMark;
    [SerializeField] public GameObject oSmallMark;

    [Header("Mark Colors: ")]
    [SerializeField] private Color colorX;
    [SerializeField] private Color color0;

    //Agregar sprite  y colores de acuerdo a los tamaños

    public Mark[] marks;

    private Camera cam;

    public Mark currentMark;
    public GameObject GO1;
    public GameObject GO2;

    public GameObject currentMarkSizeToPlace;
    public MarkContainer markContainer;
    public bool canSwitchPlayer;

    private void Start()
    {
        markContainer = FindObjectOfType<MarkContainer>();
        cam = Camera.main;

        currentMark = Mark.X;
        //Cambiar a la mark que esté seleccionada de acuerdo al turno del jugador

        marks = new Mark[9];
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Vector2 touchPosition = cam.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hit = Physics2D.OverlapCircle(touchPosition, touchRadius, boxesLayerMask);

            if (hit)//Box is touched
            {
                HitBox(hit.GetComponent <Box> ());
            }
        }
    }

    private void HitBox(Box box)
    {
        if (!box.isMarked)
        {
            if (markContainer.currentSelection != null)
            {
                //Aquí se verificaría no solo sí está marcada sino si el tamaño es mayor, menor o igual a la marca que se desea poner
                marks[box.index] = currentMark;

                //box.SetAsMarked(GetMark(), currentMark, GetColor());
                box.SetAsMarked(GetMark(), currentMark, markContainer);
            }
            else
            {
                GO1.SetActive(true);
            }
     

            bool won = CheckIfWin();
            if (won)
            {
                Debug.Log(currentMark.ToString() + " Wins.");
                GO2.SetActive(true);
                GO2.GetComponentInChildren<Text>().text = "Winner" + "\n" + currentMark; 
                return;
            }
            //NO PASAR A SWITCH PLAYER SI NO SE PUDO PONER MARCA
            if (canSwitchPlayer)
            {
                SwitchPlayer();
                canSwitchPlayer = false;
            }
            
        }  
    }

    private bool CheckIfWin()
    {
        return
        AreBoxesMatched(0, 1, 2) || AreBoxesMatched(3, 4, 5) || AreBoxesMatched(6, 7, 8) ||
        AreBoxesMatched(0, 3, 6) || AreBoxesMatched(1, 4, 7) || AreBoxesMatched(2, 5, 8) ||
        AreBoxesMatched(0, 4, 8) || AreBoxesMatched(2, 4, 6);
    }

    private bool AreBoxesMatched(int i, int j, int k)
    {
        Mark m = currentMark;
        bool matched = (marks[i] == m && marks[j] == m && marks[k] == m);
        return matched;
    }

    private void SwitchPlayer()
    {
        currentMark = (currentMark == Mark.X) ? Mark.O : Mark.X;
        markContainer.currentSelection = null; 
    }

    private Color GetColor()
    {
        return (currentMark == Mark.X) ? colorX : color0;
    }

    private GameObject GetMark()
    {
        return (markContainer.currentSelection != null) ? currentMarkSizeToPlace : null;
        //return (currentMark == Mark.X) ? xBigMark : oBigMark;
        //markContainer.currentSelection.GetComponent<SpriteRenderer>().color = new Color32(101, 101, 101, 255)
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Input Settings : ")]
    [SerializeField] private LayerMask boxesLayerMask;
    [SerializeField] private float touchRadius;

    [Header("Mark Sprites : ")]
    [SerializeField] private GameObject xBigMark;
    [SerializeField] private GameObject oBigMark;

    [Header("Mark Colors : ")]
    [SerializeField] private Color colorX;
    [SerializeField] private Color color0;

    //Agregar sprite  y colores de acuerdo a los tamaños

    public Mark[] marks;

    private Camera cam;

    private Mark currentMark;

    private void Start()
    {
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
            //Aquí se verificaría no solo sí está marcada sino si el tamaño es mayor, menor o igual a la marca que se desea poner
            marks[box.index] = currentMark;

            box.SetAsMarked(GetMark(), currentMark, GetColor());
            SwitchPlayer();
        }  
    }

    private void SwitchPlayer()
    {
        currentMark = (currentMark == Mark.X) ? Mark.O : Mark.X;
    }

    private Color GetColor()
    {
        return (currentMark == Mark.X) ? colorX : color0;
    }

    private GameObject GetMark()
    {
        return (currentMark == Mark.X) ? xBigMark : oBigMark;
    }
}

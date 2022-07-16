using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int index;
    public Mark mark;
    public bool isMarked;
    public Shape currentMark;

    private GameObject xSmallPrefab;
    private SpriteRenderer spriteRenderer;
    Board board;

    private void Awake()
    {
        //xSmallPrefab = GetComponent<GameObject>();
        /*ismarked: true or false
         * mark.equals("small") {
         * bool = true;
         * }
         * 
         * 
         */
        board = FindObjectOfType<Board>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        index = transform.GetSiblingIndex();
        mark = Mark.None;
        isMarked = false;
    }

    public void SetAsMarked(GameObject Markprefab, Mark mark, MarkContainer markSelected)
    {
        GameObject mark_ = null;

        if (Markprefab != null)
        {
            if (currentMark == null)
            {
                mark_ = Instantiate(Markprefab, this.transform);
                markSelected.currentSelection.GetComponent<SpriteRenderer>().color = new Color32(101, 101, 101, 255);
                markSelected.currentSelection.GetComponent<CircleCollider2D>().enabled = false;
                board.canSwitchPlayer = true;
                //isMarked = true;
                this.mark = mark;
                currentMark = mark_.GetComponent<Shape>();
                //Cambiar color del que quedo atras
            }
            else if (currentMark != null && Markprefab.GetComponent<Shape>().size > currentMark.size && Markprefab.GetComponent<Shape>().mark != currentMark.mark)
            {
                mark_ = Instantiate(Markprefab, this.transform);
                markSelected.currentSelection.GetComponent<SpriteRenderer>().color = new Color32(101, 101, 101, 255);
                markSelected.currentSelection.GetComponent<CircleCollider2D>().enabled = false;
                board.canSwitchPlayer = true;
                //isMarked = true;
                this.mark = mark;
                currentMark = mark_.GetComponent<Shape>();
                //Cambiar color del que quedo atras
            }
            else
            {
                //mostrar en UI que debe seleccionar un tamano menor al que esta puesto
                board.canSwitchPlayer = false;
                Debug.Log("Seleccione un tamano mayor al ya puesto");
            }
        }
        else
        {
            //mostrar en UI que debe seleccionar un tamano
            board.canSwitchPlayer = false;
            Debug.Log("Seleccione un tamano");
        }

       
        if(mark_ != null && mark_.GetComponent<Shape>().size == 3)
            GetComponent<CircleCollider2D>().enabled = false;
 
        
        //verificar los cambios de Daniel y ajustar

        //gameObject.color = color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int index;
    public Mark mark;
    public bool isMarked;

    private GameObject xSmallPrefab;
    private SpriteRenderer spriteRenderer;

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
        spriteRenderer = GetComponent<SpriteRenderer>();
        index = transform.GetSiblingIndex();
        mark = Mark.None;
        isMarked = false;
    }

    public void SetAsMarked(GameObject Markprefab, Mark mark, Color color)
    {
        isMarked = true;
        this.mark = mark;
        
        GameObject mark_ = Instantiate(Markprefab, this.transform);
       
        if(mark_ != null && mark_.GetComponent<Shape>().size == "Big")
            GetComponent<CircleCollider2D>().enabled = false;   
        //verificar los cambios de Daniel y ajustar

        //gameObject.color = color;
    }
}

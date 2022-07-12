using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int index;
    public Mark mark;
    public bool isMarked;

    private GameObject xSmallPrefab;

    private void Awake()
    {
        xSmallPrefab = GetComponent<GameObject>();
        /*ismarked: true or false
         * mark.equals("small") {
         * bool = true;
         * }
         * 
         * 
         */
        index = transform.GetSiblingIndex();
        mark = Mark.None;
        isMarked = false;
    }

    public void SetAsMarked(GameObject gameObject, Mark mark, Color color)
    {
        isMarked = true;
        this.mark = mark;

        //gameObject.color = color;
    }
}

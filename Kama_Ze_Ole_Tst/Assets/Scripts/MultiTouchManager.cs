using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTouchManager : MonoBehaviour
{
    private int[] touchPhase = new int[10];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("M:" + Input.mousePosition);
        if (Input.touchCount == 0)
        {
            return;
        }
        for (int i = 0; i < 1/*Input.touchCount*/; i++)
        {

            //Debug.Log("T:" + Input.touches[i].position);
            if (touchPhase[i] == 0) // && !touchBegan)//!TopLeftTouchBegan && !TopLeftTouchBegan && !BotRightTouchBegan && !BotLeftTouchBegan)
            {
                Debug.Log("touch began");

                touchPhase[i] = 1;
                Vector2 touchPos = Input.touches[i].position;
                //touchBegan = true;
                //Collider2D[] hits = Physics2D.OverlapPointAll(Input.touches[i].position);
                //Debug.Log(hits.Length);
                //GameObject prefabCopy = Instantiate(prefab, Kanvas.transform);
                //prefabCopy.GetComponent<Image>().SetNativeSize();
            }
        }
    }
}
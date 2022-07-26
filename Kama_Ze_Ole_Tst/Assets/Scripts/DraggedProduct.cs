using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using TouchScript.Gestures.TransformGestures;

public class DraggedProduct : MonoBehaviour
{
    public Product origin;
    Collider2D[] hits;

    private enum DraggedProductStatus
    {
        Free,
        Manual,
        Dropped
    }

    private DraggedProductStatus status = DraggedProductStatus.Manual;

    private void OnEnable()
    {
        GetComponent<PressGesture>().Pressed += pressedhandler;
        GetComponent<ReleaseGesture>().Released += releasedHandler;
    }

    private void OnDisable()
    {
        GetComponent<PressGesture>().Pressed -= pressedhandler;
        GetComponent<ReleaseGesture>().Released -= releasedHandler;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case DraggedProductStatus.Free:
                //transform.RotateAround(transform.parent.position, Vector3.up,
                //    Speed * Time.unscaledDeltaTime / transform.localPosition.sqrMagnitude);
                //transform.Translate(transform.up * -1f);
                break;
            case DraggedProductStatus.Manual:
                break;
            case DraggedProductStatus.Dropped:
                //transform.localScale *= 1 - FallSpeed;
                //transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, FallSpeed);
                Destroy(gameObject);
                break;
        }
        hits = Physics2D.OverlapPointAll(transform.position);
        foreach (var item in hits)
        {
            if (item.CompareTag("Resetter"))
            {
                Resetter resetter = item.GetComponent<Resetter>();
                resetter.ResetTrans();
            }
        }

    }

    void pressedhandler(object sender, System.EventArgs e)
    {
        //Debug.Log("pressed");
        
        //status = DraggedProductStatus.Free;
    }

    void releasedHandler(object sender, System.EventArgs e)
    {
        CheckAddToCart();
        //Debug.Log("released");
        //if (status != DraggedProductStatus.Manual) return;
        status = DraggedProductStatus.Dropped;
    }

    void CheckAddToCart()
    {
        hits = Physics2D.OverlapPointAll(transform.position);
        if (hits.Length > 0)
        {
            foreach (var item in hits)
            {
                if (item.gameObject.CompareTag("Cart"))
                {
                    //Debug.Log(this.name);
                    //if (item.transform.position.x > Screen.width / 2 && item.transform.position.y > Screen.width / 2)//"TopRightCorner"
                    //    {
                    //        if (this.name.Contains(TopRightItem) && TopRightItem.Length > 3)
                    item.gameObject.GetComponent<ShoppingCart>().AddToCart(origin);
                }
            }
        }
    }
}

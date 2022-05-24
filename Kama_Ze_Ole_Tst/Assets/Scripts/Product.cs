using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public enum ProductName { Milk, EMilk, Bottle, EBottle, Shirt, EShirt, Brick, EBrick, Phone, EPhone };
public class Product : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] public GameObject prefab;
    [SerializeField] public TransitionManager myTransManager;
    [SerializeField] GameObject Kanvas;

    public ProductName productName;
    private GameObject prefabCopy;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Collider2D[] hits = Physics2D.OverlapPointAll(Input.mousePosition);

        prefabCopy = Instantiate(prefab, Kanvas.transform);
        prefabCopy.GetComponent<Image>().SetNativeSize();

        if (hits.Length > 0)
        {
            foreach (var item in hits)
            {
                if (item.gameObject.CompareTag("TopRightCorner"))
                {
                    prefabCopy.transform.eulerAngles = new Vector3(prefabCopy.transform.eulerAngles.x, prefabCopy.transform.eulerAngles.y, 131.515f);
                }
                else if (item.gameObject.CompareTag("BotRightCorner"))
                {
                    prefabCopy.transform.eulerAngles = new Vector3(prefabCopy.transform.eulerAngles.x, prefabCopy.transform.eulerAngles.y, 41.515f);
                }
                else if (item.gameObject.CompareTag("TopLeftCorner"))
                {
                    prefabCopy.transform.eulerAngles = new Vector3(prefabCopy.transform.eulerAngles.x, prefabCopy.transform.eulerAngles.y, -131.515f);
                }
                else if (item.gameObject.CompareTag("BotLeftCorner"))
                {
                    prefabCopy.transform.eulerAngles = new Vector3(prefabCopy.transform.eulerAngles.x, prefabCopy.transform.eulerAngles.y, -41.515f);
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        prefabCopy.transform.position = Input.mousePosition;
        Collider2D[] collider2DsHits = Physics2D.OverlapPointAll(Input.mousePosition);
        if (collider2DsHits.Length > 0)
        {
            foreach (var item in collider2DsHits)
            {
                if (item.CompareTag("Resetter"))
                {
                    Resetter resetter = item.GetComponent<Resetter>();
                    resetter.ResetTrans();
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Collider2D[] hits = Physics2D.OverlapPointAll(Input.mousePosition);
        
        if (hits.Length > 0)
        {
            foreach (var item in hits)
            {
                if (item.gameObject.CompareTag("Cart"))
                {
                    item.gameObject.GetComponent<ShoppingCart>().AddToCart(this);
                }
            }
        }

        Destroy(prefabCopy);
    }

}
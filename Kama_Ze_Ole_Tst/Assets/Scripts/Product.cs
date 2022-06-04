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
    private Collider2D myCollider;

    private void Awake()
    {
        myCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (DrageMode._input == Inputs.Click)
        {

            if (Input.GetMouseButtonDown(0) && myTransManager)
            {
                Collider2D[] hits = Physics2D.OverlapPointAll(Input.mousePosition);
                if (hits.Length > 0)
                {
                    foreach (var asd in hits)
                    {
                        if (asd == myCollider)
                        {
                            foreach (var item in hits)
                            {
                                if (item.gameObject.CompareTag("TopRightCorner"))
                                {
                                    myTransManager.ResetTransition();
                                    myTransManager._dragMode.shoppingCartTR.AddToCart(this);
                                }
                                else if (item.gameObject.CompareTag("BotRightCorner"))
                                {
                                    myTransManager.ResetTransition();
                                    myTransManager._dragMode.shoppingCartBR.AddToCart(this);
                                }
                                else if (item.gameObject.CompareTag("TopLeftCorner"))
                                {
                                    myTransManager.ResetTransition();
                                    myTransManager._dragMode.shoppingCartTL.AddToCart(this);
                                }
                                else if (item.gameObject.CompareTag("BotLeftCorner"))
                                {
                                    myTransManager.ResetTransition();
                                    myTransManager._dragMode.shoppingCartBL.AddToCart(this);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (DrageMode._input == Inputs.Drag)
        {
            DragInput();
        }
    }

    private void DragInput()
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
        if (DrageMode._input == Inputs.Drag)
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
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (DrageMode._input == Inputs.Drag)
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
}
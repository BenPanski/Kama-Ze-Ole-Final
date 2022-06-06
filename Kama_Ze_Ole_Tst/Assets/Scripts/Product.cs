using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public enum ProductName { Milk, EMilk, Bottle, EBottle, Shirt, EShirt, Brick, EBrick, Phone, EPhone };
public class Product : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] public GameObject prefab;
    [SerializeField] public TransitionManager BRTransManager;
    [SerializeField] public TransitionManager TRTransManager;
    [SerializeField] public TransitionManager BLTransManager;
    [SerializeField] public TransitionManager TLTransManager;
    [SerializeField] GameObject Kanvas;

    public ProductName productName;
    private GameObject prefabCopy;
    private Collider2D myCollider;

    private int PressedScreen = 0;

    private void Awake()
    {
        myCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (DrageMode._input == Inputs.FakeTouch)
        {
            FakeTouchFunctionality();
        }

        if (DrageMode._input == Inputs.Click)
        {
            ClickInputFunctionality();
        }
    }

    private void FakeTouchFunctionality()
    {

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            PressedScreen = 1;
            //print("Left Canvas");
            /*  DragInputFakeTouch();*/
        }
        else if (Input.GetKey(KeyCode.Keypad1))
        {
            /*  OnDragFakeTouch();*/
            PressedScreen = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            //print("Right Canvas");
            PressedScreen = 2;
            /*  DragInputFakeTouch();*/
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            PressedScreen = 2;
            /*  OnDragFakeTouch();*/
        }


    }

    private void ClickInputFunctionality()
    {
        if (Input.GetMouseButtonDown(0))
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
                                TRTransManager.ResetTransition();
                                TRTransManager._dragMode.shoppingCartTR.AddToCart(this);
                            }
                            else if (item.gameObject.CompareTag("BotRightCorner"))
                            {
                                BRTransManager.ResetTransition();
                                BRTransManager._dragMode.shoppingCartBR.AddToCart(this);
                            }
                            else if (item.gameObject.CompareTag("TopLeftCorner"))
                            {
                                TLTransManager.ResetTransition();
                                TLTransManager._dragMode.shoppingCartTL.AddToCart(this);
                            }
                            else if (item.gameObject.CompareTag("BotLeftCorner"))
                            {
                                BLTransManager.ResetTransition();
                                BLTransManager._dragMode.shoppingCartBL.AddToCart(this);
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
        else if (DrageMode._input == Inputs.FakeTouch)
        {
            DragInputFakeTouch();
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

    private void DragInputFakeTouch()
    {
        Collider2D[] hits = Physics2D.OverlapPointAll(Input.mousePosition);
        print(hits);
        prefabCopy = Instantiate(prefab, Kanvas.transform);
        prefabCopy.GetComponent<Image>().SetNativeSize();

        if (hits.Length > 0)
        {
            foreach (var item in hits)
            {
                if (item.gameObject.CompareTag("TopRightCorner") && PressedScreen == 2)
                {
                    prefabCopy.transform.eulerAngles = new Vector3(prefabCopy.transform.eulerAngles.x, prefabCopy.transform.eulerAngles.y, 131.515f);
                }
                else if (item.gameObject.CompareTag("BotRightCorner") && PressedScreen == 2)
                {
                    prefabCopy.transform.eulerAngles = new Vector3(prefabCopy.transform.eulerAngles.x, prefabCopy.transform.eulerAngles.y, 41.515f);
                }
                else if (item.gameObject.CompareTag("TopLeftCorner") && PressedScreen == 1)
                {
                    prefabCopy.transform.eulerAngles = new Vector3(prefabCopy.transform.eulerAngles.x, prefabCopy.transform.eulerAngles.y, -131.515f);
                }
                else if (item.gameObject.CompareTag("BotLeftCorner") && PressedScreen == 1)
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

    public void OnDragFakeTouch()
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

    public void OnEndDragFakeTouch()
    {
        if (DrageMode._input == Inputs.Drag && DrageMode._input == Inputs.FakeTouch)
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

    public void OnEndDrag(PointerEventData eventData)
    {
        if (DrageMode._input == Inputs.Drag || DrageMode._input == Inputs.FakeTouch)
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
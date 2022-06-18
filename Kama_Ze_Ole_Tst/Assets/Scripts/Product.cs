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
    private GameObject prefabCopyTopLeft;
    private GameObject prefabCopyTopRight;
    private GameObject prefabCopyBottomLeft;
    private GameObject prefabCopyBottomRight;
    private Collider2D myCollider;

    private int PressedScreen = 0;
    public bool NegisutProd;

    private bool TopRightTouchBegan = false;
    private bool TopLeftTouchBegan = false;
    private bool BotRightTouchBegan = false;
    private bool BotLeftTouchBegan = false;

    private bool TopRightAddedToCart = false;
    private bool TopLeftAddedToCart = false;
    private bool BotRightAddedToCart = false;
    private bool BotLeftAddedToCart = false;

    private string TopRightItem = "";
    private string TopLeftItem = "";
    private string BotRightItem = "";
    private string BotLeftItem = "";


    private bool touchBegan = false;
    private int[] touchPhase = new int[10];


    private void Awake()
    {
        myCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (NegisutProd)
        {
            ClickInputFunctionality();
        }
        else
        {
            if (DrageMode._input == Inputs.MultiTouch)
            {
                MultiTouchInputFunctionality();
            }

            if (DrageMode._input == Inputs.FakeTouch)
            {
                FakeTouchFunctionality();
            }

            if (DrageMode._input == Inputs.Click)
            {
                ClickInputFunctionality();
            }
        }

    }

    private void MultiTouchInputFunctionality()
    {
        //Debug.Log("M:" + Input.mousePosition);
        if (Input.touchCount == 0)
        {
            return;
        }
        for (int i = 0; i < Input.touchCount; i++)
        {
            Collider2D[] hits = Physics2D.OverlapPointAll(Input.touches[i].position);
            Vector2 curr_pos = Input.touches[i].position;
            //Debug.Log(hits.Length);
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                if (hits.Length > 0)
                {
                    foreach (var asd in hits)
                    {
                        if (asd == myCollider)
                        {
                            if (touchPhase[i] == 0)
                            {
                                //prefabCopy = Instantiate(prefab, Kanvas.transform);
                                //prefabCopy.GetComponent<Image>().SetNativeSize();
                                touchPhase[i] = 1;
                                //Debug.Log(prefab.name);
                                if (curr_pos.x > Screen.width / 2 && curr_pos.y > Screen.width / 2)//"TopRightCorner"
                                {
                                    TopRightItem = prefab.name;
                                    prefabCopyTopRight = Instantiate(prefab, Kanvas.transform);
                                    prefabCopyTopRight.GetComponent<Image>().SetNativeSize();
                                    prefabCopyTopRight.transform.eulerAngles = new Vector3(prefabCopyTopRight.transform.eulerAngles.x, prefabCopyTopRight.transform.eulerAngles.y, 131.515f);
                                }
                                else if (curr_pos.x > Screen.width / 2 && curr_pos.y < Screen.width / 2)//"BotRightCorner"
                                {
                                    BotRightItem = prefab.name;
                                    prefabCopyBottomRight = Instantiate(prefab, Kanvas.transform);
                                    prefabCopyBottomRight.GetComponent<Image>().SetNativeSize();
                                    prefabCopyBottomRight.transform.eulerAngles = new Vector3(prefabCopyBottomRight.transform.eulerAngles.x, prefabCopyBottomRight.transform.eulerAngles.y, 41.515f);
                                }
                                else if (curr_pos.x < Screen.width / 2 && curr_pos.y > Screen.width / 2)//"TopLeftCorner"
                                {
                                    TopLeftItem = prefab.name;
                                    prefabCopyTopLeft = Instantiate(prefab, Kanvas.transform);
                                    prefabCopyTopLeft.GetComponent<Image>().SetNativeSize();
                                    prefabCopyTopLeft.transform.eulerAngles = new Vector3(prefabCopyTopLeft.transform.eulerAngles.x, prefabCopyTopLeft.transform.eulerAngles.y, -131.515f);
                                }
                                else if (curr_pos.x < Screen.width / 2 && curr_pos.y < Screen.width / 2)//"BotLeftCorner"
                                {
                                    BotLeftItem = prefab.name;
                                    prefabCopyBottomLeft = Instantiate(prefab, Kanvas.transform);
                                    prefabCopyBottomLeft.GetComponent<Image>().SetNativeSize();
                                    prefabCopyBottomLeft.transform.eulerAngles = new Vector3(prefabCopyBottomLeft.transform.eulerAngles.x, prefabCopyBottomLeft.transform.eulerAngles.y, -41.515f);
                                }
                            }
                        }
                    }
                }
            }
            else if (Input.touches[i].phase == TouchPhase.Moved || Input.touches[i].phase == TouchPhase.Stationary)
            {
                //prefabCopy.transform.position = Input.touches[i].position;
                if (curr_pos.x > Screen.width / 2 && curr_pos.y > Screen.width / 2)//"TopRightCorner"
                {
                    if (prefabCopyTopRight != null)
                    {
                        prefabCopyTopRight.transform.position = Input.touches[i].position;
                        //prefabCopyTopRight.transform.eulerAngles = new Vector3(prefabCopyTopRight.transform.eulerAngles.x, prefabCopyTopRight.transform.eulerAngles.y, 131.515f);
                    }
                }
                else if (curr_pos.x > Screen.width / 2 && curr_pos.y < Screen.width / 2)//"BotRightCorner"
                {
                    if (prefabCopyBottomRight != null)
                    {
                        prefabCopyBottomRight.transform.position = Input.touches[i].position;
                        //prefabCopyBottomRight.transform.eulerAngles = new Vector3(prefabCopyBottomRight.transform.eulerAngles.x, prefabCopyBottomRight.transform.eulerAngles.y, 41.515f);
                    }
                }
                else if (curr_pos.x < Screen.width / 2 && curr_pos.y > Screen.width / 2)//"TopLeftCorner"
                {
                    if (prefabCopyTopLeft != null)
                    {
                        prefabCopyTopLeft.transform.position = Input.touches[i].position;
                        //prefabCopyTopLeft.transform.eulerAngles = new Vector3(prefabCopyTopLeft.transform.eulerAngles.x, prefabCopyTopLeft.transform.eulerAngles.y, -131.515f);
                    }
                }
                else if (curr_pos.x < Screen.width / 2 && curr_pos.y < Screen.width / 2)//"BotLeftCorner"
                {
                    if (prefabCopyBottomLeft != null)
                    {
                        prefabCopyBottomLeft.transform.position = Input.touches[i].position;
                        //prefabCopyBottomLeft.transform.eulerAngles = new Vector3(prefabCopyBottomLeft.transform.eulerAngles.x, prefabCopyBottomLeft.transform.eulerAngles.y, -41.515f);
                    }
                }

                foreach (var item in hits)
                {
                    if (item.CompareTag("Resetter"))
                    {
                        Resetter resetter = item.GetComponent<Resetter>();
                        resetter.ResetTrans();
                    }
                }

            }
            else if (Input.touches[i].phase == TouchPhase.Ended)
            {
                touchPhase[i] = 0;
                if (hits.Length > 0)
                {
                    foreach (var item in hits)
                    {
                        if (item.gameObject.CompareTag("Cart"))
                        {
                            Debug.Log(productName);

                            if ((Mathf.Abs(this.transform.position.x - item.transform.position.x) < (Screen.width / 4)) && (Mathf.Abs(this.transform.position.y - item.transform.position.y) < (Screen.height / 4)))
                            {
                                //Debug.Log(this.name);
                                if (item.transform.position.x > Screen.width / 2 && item.transform.position.y > Screen.width / 2)//"TopRightCorner"
                                {
                                    if (this.name.Contains(TopRightItem) && TopRightItem.Length > 3)
                                    {
                                        Debug.Log(TopRightItem);
                                        item.gameObject.GetComponent<ShoppingCart>().AddToCart(this);
                                    }
                                }
                                else if (item.transform.position.x > Screen.width / 2 && item.transform.position.y < Screen.width / 2)//"BotRightCorner"
                                {
                                    if (this.name.Contains(BotRightItem) && BotRightItem.Length > 3)
                                    {
                                        Debug.Log(BotRightItem);
                                        item.gameObject.GetComponent<ShoppingCart>().AddToCart(this);
                                    }
                                }
                                else if (item.transform.position.x < Screen.width / 2 && item.transform.position.y > Screen.width / 2)//"TopLeftCorner"
                                {
                                    if (this.name.Contains(TopLeftItem) && TopLeftItem.Length > 3)
                                    {
                                        Debug.Log(TopLeftItem);
                                        item.gameObject.GetComponent<ShoppingCart>().AddToCart(this);
                                    }
                                }
                                else if (item.transform.position.x < Screen.width / 2 && item.transform.position.y < Screen.width / 2)//"BotLeftCorner"
                                {
                                    Debug.Log(BotLeftItem);
                                    if (this.name.Contains(BotLeftItem) && BotLeftItem.Length > 3)
                                    {
                                        item.gameObject.GetComponent<ShoppingCart>().AddToCart(this);
                                    }
                                }
                            }

                        }
                    }
                }

                if (curr_pos.x > Screen.width / 2 && curr_pos.y > Screen.width / 2)//"TopRightCorner"
                {
                    if (prefabCopyTopRight != null)
                    {
                        Destroy(prefabCopyTopRight);
                    }
                }
                else if (curr_pos.x > Screen.width / 2 && curr_pos.y < Screen.width / 2)//"BotRightCorner"
                {
                    if (prefabCopyBottomRight != null)
                    {
                        Destroy(prefabCopyBottomRight);
                    }
                }
                else if (curr_pos.x < Screen.width / 2 && curr_pos.y > Screen.width / 2)//"TopLeftCorner"
                {
                    if (prefabCopyTopLeft != null)
                    {
                        Destroy(prefabCopyTopLeft);
                    }
                }
                else if (curr_pos.x < Screen.width / 2 && curr_pos.y < Screen.width / 2)//"BotLeftCorner"
                {
                    if (prefabCopyBottomLeft != null)
                    {
                        Destroy(prefabCopyBottomLeft);
                    }
                }

            }




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

        Collider2D[] hits = Physics2D.OverlapPointAll(Input.mousePosition);
        if (hits.Length > 0)
        {
            if (Input.GetMouseButtonDown(0))
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
        if (!NegisutProd)
        {
            if (DrageMode._input == Inputs.Drag)
            {
                DragInput();
            }
            else if (DrageMode._input == Inputs.FakeTouch)
            {
                DragInputFakeTouch();
            }
            else if (DrageMode._input == Inputs.MultiTouch)
            {
                return;
            }
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

    private void MultiTouchInput(Vector2 pos)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (DrageMode._input == Inputs.Drag && !NegisutProd)
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
        if ((DrageMode._input == Inputs.Drag || DrageMode._input == Inputs.FakeTouch) && !NegisutProd)
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
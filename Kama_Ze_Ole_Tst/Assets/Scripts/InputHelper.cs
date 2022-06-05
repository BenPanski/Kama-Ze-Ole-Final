using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
public enum TouchCorner { TR, TL, BR,BL }
public class InputHelper : MonoBehaviour
{
    private static TouchCreator lastFakeTouch;
    public static bool LeftCanvas;
    [SerializeField] DrageMode dragMode;
    internal static TouchCorner _touchCorner;


    [SerializeField] Product Bottle;
    [SerializeField] Product Shirt;
    [SerializeField] Product Milk;
    [SerializeField] Product Brick;
    [SerializeField] Product Phone;
    public static List<Touch> GetTouches()
    {
        List<Touch> touches = new List<Touch>();
        touches.AddRange(Input.touches);
#if UNITY_EDITOR
        if (lastFakeTouch == null) lastFakeTouch = new TouchCreator();
        if (Input.GetMouseButtonDown(0))
        {
            lastFakeTouch.phase = TouchPhase.Began;
            lastFakeTouch.deltaPosition = new Vector2(0, 0);
            lastFakeTouch.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            lastFakeTouch.fingerId = 0;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            lastFakeTouch.phase = TouchPhase.Ended;
            Vector2 newPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            lastFakeTouch.deltaPosition = newPosition - lastFakeTouch.position;
            lastFakeTouch.position = newPosition;
            lastFakeTouch.fingerId = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            lastFakeTouch.phase = TouchPhase.Moved;
            Vector2 newPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            lastFakeTouch.deltaPosition = newPosition - lastFakeTouch.position;
            lastFakeTouch.position = newPosition;
            lastFakeTouch.fingerId = 0;
        }
        else
        {
            lastFakeTouch = null;
        }
        if (lastFakeTouch != null) touches.Add(lastFakeTouch.Create());
#endif


        return touches;
    }
    private void Update()
    {
        if (DrageMode._input == Inputs.FakeTouch)
        {


            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                print("Left Canvas");
                LeftCanvas = true;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                print("Right Canvas");
                LeftCanvas = false;
            }
            List<Touch> touches = InputHelper.GetTouches();



            if (touches.Count > 0)
            {
                foreach (Touch touch in touches)
                {
                    
                    Collider2D[] hits = Physics2D.OverlapPointAll(touch.position);
                    foreach (var item in hits)
                    {

                        if (item.gameObject.CompareTag("TopRightCorner") && !LeftCanvas)
                        {
                            _touchCorner = TouchCorner.TR;                         
                        }
                        else if (item.gameObject.CompareTag("BotRightCorner") && !LeftCanvas)
                        {
                            _touchCorner = TouchCorner.BR;
                        }
                        else if (item.gameObject.CompareTag("TopLeftCorner") && LeftCanvas)
                        {
                            _touchCorner = TouchCorner.TL;
                        }
                        else if (item.gameObject.CompareTag("BotLeftCorner") && LeftCanvas)
                        {
                            _touchCorner = TouchCorner.BL;
                        }
                    }
                    foreach (var item in hits) 
                    {
                        if (item.CompareTag("Product"))
                        {
                           
                        
                       
                        var x = item.GetComponent<Product>();

                            if (LeftCanvas)
                            {
                                switch (_touchCorner)
                                {
                                    
                                    case TouchCorner.TL:
                                        break;
                                    case TouchCorner.BL:
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (_touchCorner)
                                {
                                    case TouchCorner.TR:
                                        dragMode.shoppingCartTR.transitionManager.ResetTransition();
                                        dragMode.shoppingCartTR.AddToCart(x);
                                        break;
                                    case TouchCorner.BR:
                                        dragMode.shoppingCartBR.transitionManager.ResetTransition();
                                        dragMode.shoppingCartBR.AddToCart(x);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        
                    }
                }
            }
        }
    }

    public class TouchCreator
    {
        static BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
        static Dictionary<string, FieldInfo> fields;

        object touch;

        public float deltaTime { get { return ((Touch)touch).deltaTime; } set { fields["m_TimeDelta"].SetValue(touch, value); } }
        public int tapCount { get { return ((Touch)touch).tapCount; } set { fields["m_TapCount"].SetValue(touch, value); } }
        public TouchPhase phase { get { return ((Touch)touch).phase; } set { fields["m_Phase"].SetValue(touch, value); } }
        public Vector2 deltaPosition { get { return ((Touch)touch).deltaPosition; } set { fields["m_PositionDelta"].SetValue(touch, value); } }
        public int fingerId { get { return ((Touch)touch).fingerId; } set { fields["m_FingerId"].SetValue(touch, value); } }
        public Vector2 position { get { return ((Touch)touch).position; } set { fields["m_Position"].SetValue(touch, value); } }
        public Vector2 rawPosition { get { return ((Touch)touch).rawPosition; } set { fields["m_RawPosition"].SetValue(touch, value); } }

        public Touch Create()
        {
            return (Touch)touch;
        }

        public TouchCreator()
        {
            touch = new Touch();
        }

        static TouchCreator()
        {
            fields = new Dictionary<string, FieldInfo>();
            foreach (var f in typeof(Touch).GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                fields.Add(f.Name, f);

            }
        }


    }
}
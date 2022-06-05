using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Inputs { Drag, Click, FakeTouch }
public class DrageMode : MonoBehaviour
{
    internal static Inputs _input;
    public Inputs inputs;
    [SerializeField] internal ShoppingCart shoppingCartTR;
    [SerializeField] internal ShoppingCart shoppingCartTL;
    [SerializeField] internal ShoppingCart shoppingCartBL;
    [SerializeField] internal ShoppingCart shoppingCartBR;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("drag mode");
            _input = Inputs.Drag;
            inputs = Inputs.Drag;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            print("click mode");
            _input = Inputs.Click;
            inputs = Inputs.Click;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            print("fake touch mode");
            _input = Inputs.FakeTouch;
            inputs = Inputs.FakeTouch;
        } 
        switch (inputs)
        {
            case Inputs.Drag:
                _input = Inputs.Drag;
                break;
            case Inputs.Click:
                _input = Inputs.Click;
                break;
            case Inputs.FakeTouch:
                _input = Inputs.FakeTouch;
                break;
            default:
                break;
        }
    }
}

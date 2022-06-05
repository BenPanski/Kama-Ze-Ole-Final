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
            _input = Inputs.Drag;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            _input = Inputs.Click;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            _input = Inputs.FakeTouch;
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

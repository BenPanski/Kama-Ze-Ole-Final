using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum Inputs { Drag, Click, MultiTouch, FakeTouch }
public class DrageMode : MonoBehaviour
{
    internal static Inputs _input;
    public Inputs inputs;
    [SerializeField] internal ShoppingCart shoppingCartTR;
    [SerializeField] internal ShoppingCart shoppingCartTL;
    [SerializeField] internal ShoppingCart shoppingCartBL;
    [SerializeField] internal ShoppingCart shoppingCartBR;
    //internal static int PressedScreen = 0;
    private void Start()
    {
        if (Directory.Exists("c:\\media"))
        {
            if (File.Exists("c:\\media\\dragmode_.ini"))
            {
                string dragModeFromFile = File.ReadAllText("c:\\media\\dragmode.ini");
                if (dragModeFromFile == "A")
                {
                    print("drag mode");
                    _input = Inputs.Drag;
                    inputs = Inputs.Drag;
                }
                else if (dragModeFromFile == "B")
                {
                    print("click mode");
                    _input = Inputs.Click;
                    inputs = Inputs.Click;
                }
                else if (dragModeFromFile == "C")
                {
                    print("multi touch mode");
                    _input = Inputs.MultiTouch;
                    inputs = Inputs.MultiTouch;
                }
                else if (dragModeFromFile == "D")
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
                    case Inputs.MultiTouch:
                        _input = Inputs.MultiTouch;
                        break;
                    case Inputs.FakeTouch:
                        _input = Inputs.FakeTouch;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void Update()
    {
        //Debug.Log(Input.touchCount);
        //if (Input.GetKeyDown(KeyCode.Keypad1))
        //{
        //    PressedScreen = 1;
        //}
        //else if (Input.GetKeyDown(KeyCode.Keypad2))
        //{
        //    PressedScreen = 2;
        //}
        //else
        //{
        //    PressedScreen = 0;
        //}

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
            print("multi touch mode");
            _input = Inputs.MultiTouch;
            inputs = Inputs.MultiTouch;
        }
        else if (Input.GetKeyDown(KeyCode.D))
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
            case Inputs.MultiTouch:
                _input = Inputs.MultiTouch;
                break;
            case Inputs.FakeTouch:
                _input = Inputs.FakeTouch;
                break;
            default:
                break;
        }
    }
}

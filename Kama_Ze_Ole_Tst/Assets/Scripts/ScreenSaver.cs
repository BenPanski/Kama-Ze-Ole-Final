using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSaver : MonoBehaviour
{
    public static bool English = false;

    [SerializeField] GameObject Cart;
    [SerializeField] GameObject cornerTxt;
    [SerializeField] GameObject underCartTxt;
    [SerializeField] GameObject handToCartIcon;
    ImageChanger cornerImage;
    ImageChanger underCartImage;
    ShoppingCart cartScript;

    private void Awake()
    {
        cornerImage = cornerTxt.GetComponent<ImageChanger>();
        underCartImage = underCartTxt.GetComponent<ImageChanger>();
        cartScript = Cart.GetComponent<ShoppingCart>();
    }

    private void OnEnable()
    {
       
        cornerTxt.SetActive(true);
        underCartTxt.SetActive(true);
        handToCartIcon.SetActive(true);
        Cart.SetActive(true);
        cartScript.ResetCart();
    }

    private void OnDisable()
    {
        if (cornerTxt)
        {
            cornerTxt.SetActive(false);
        }
        if (underCartTxt)
        {
            underCartTxt.transform.localScale = Vector3.one;
            underCartTxt.SetActive(false);
        }
        if (handToCartIcon)
        {
            handToCartIcon.SetActive(false);
        }
    }

    public void ChangeLanguae(bool eng)
    {
        English = eng;
        if (English)
        {
            cornerImage.SwapImage(ProductName.EMilk);
            underCartImage.SwapImage(ProductName.EMilk);
        }
        else
        {
            cornerImage.SwapImage(ProductName.Milk);
            underCartImage.SwapImage(ProductName.Milk);
        }
    }

    public void EnlargeUnderCartText()
    {
        underCartTxt.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

}
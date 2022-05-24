using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class ImageChanger : MonoBehaviour
{
    Image myImage;

    [SerializeField] Sprite MilkSprite;
    [SerializeField] Sprite EMilkSprite;
    [SerializeField] Sprite BottleSprite;
    [SerializeField] Sprite EBottleSprite;
    [SerializeField] Sprite ShirtSprite;
    [SerializeField] Sprite EShirtSprite;
    [SerializeField] Sprite BrickSprite;
    [SerializeField] Sprite EBrickSprite;
    [SerializeField] Sprite PhoneSprite;
    [SerializeField] Sprite EPhoneSprite;

    private void Awake()
    {
        myImage = GetComponent<Image>();
    }

    public void SwapImage(ProductName state)
    {
        if (gameObject.activeSelf)
        {
            switch (state)
            {
                case ProductName.Milk:
                    myImage.sprite = MilkSprite;
                    break;
                case ProductName.EMilk:
                    myImage.sprite = EMilkSprite;
                    break;
                case ProductName.Bottle:
                    myImage.sprite = BottleSprite;
                    break;
                case ProductName.EBottle:
                    myImage.sprite = EBottleSprite;
                    break;
                case ProductName.Shirt:
                    myImage.sprite = ShirtSprite;
                    break;
                case ProductName.EShirt:
                    myImage.sprite = EShirtSprite;
                    break;
                case ProductName.Brick:
                    myImage.sprite = BrickSprite;
                    break;
                case ProductName.EBrick:
                    myImage.sprite = EBrickSprite;
                    break;
                case ProductName.Phone:
                    myImage.sprite = PhoneSprite;
                    break;
                case ProductName.EPhone:
                    myImage.sprite = EPhoneSprite;
                    break;
                default:
                    break;
            }
            myImage.SetNativeSize();
        }
    }
}
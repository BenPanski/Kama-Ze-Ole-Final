using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StickerManager : MonoBehaviour
{
    [SerializeField] TransitionManager _transitionManager;
    [SerializeField] Animator animatorRightH;
    [SerializeField] Animator animatorRightE;
    [SerializeField] Animator animatorLeftH;
    [SerializeField] Animator animatorLeftE;
    [SerializeField] GameObject leTashlum;
    [SerializeField] GameObject payment;
    [SerializeField] GameObject findOutYellowTxt;
    [SerializeField] GameObject cart;
    [SerializeField] GameObject CornerImage;
    [SerializeField] GameObject CornerButton;
    [SerializeField] GameObject CornerAnimation;
    SubCategory mySubCategory;
    ProductName myProduct;
    internal bool rightStickerClicked;
    internal bool leftStickerClicked;
    bool buttonClicked;
    Image myImage;

    #region StickerTxt
    [Header("Hebrew StickerTxt")]
    [SerializeField] Sprite MilkOzon;
    [SerializeField] Sprite MilkHealth;
    [SerializeField] Sprite MilkGW;
    [SerializeField] Sprite BottleEnergy;
    [SerializeField] Sprite BottleHealth;
    [SerializeField] Sprite BottleGW;
    [SerializeField] Sprite BrickEnergy;
    [SerializeField] Sprite BrickAcid;
    [SerializeField] Sprite BrickGW;
    [SerializeField] Sprite PhoneAcid;
    [SerializeField] Sprite PhoneHealth;
    [SerializeField] Sprite PhoneGW;
    [SerializeField] Sprite ShirtWater;
    [SerializeField] Sprite ShirtHealth;
    [SerializeField] Sprite ShirtGW;
    [Header("English StickerTxt")]
    [SerializeField] Sprite EMilkOzon;
    [SerializeField] Sprite EMilkHealth;
    [SerializeField] Sprite EMilkGW;
    [SerializeField] Sprite EBottleEnergy;
    [SerializeField] Sprite EBottleHealth;
    [SerializeField] Sprite EBottleGW;
    [SerializeField] Sprite EBrickEnergy;
    [SerializeField] Sprite EBrickAcid;
    [SerializeField] Sprite EBrickGW;
    [SerializeField] Sprite EPhoneAcid;
    [SerializeField] Sprite EPhoneHealth;
    [SerializeField] Sprite EPhoneGW;
    [SerializeField] Sprite EShirtWater;
    [SerializeField] Sprite EShirtHealth;
    [SerializeField] Sprite EShirtGW;
    [Header("Hebrew Hayadata StickerTxt")]
    [SerializeField] Sprite RMilkOzon;
    [SerializeField] Sprite RMilkHealth;
    [SerializeField] Sprite RMilkGW;
    [SerializeField] Sprite RBottleEnergy;
    [SerializeField] Sprite RBottleHealth;
    [SerializeField] Sprite RBottleGW;
    [SerializeField] Sprite RBrickEnergy;
    [SerializeField] Sprite RBrickAcid;
    [SerializeField] Sprite RBrickGW;
    [SerializeField] Sprite RPhoneAcid;
    [SerializeField] Sprite RPhoneHealth;
    [SerializeField] Sprite RPhoneGW;
    [SerializeField] Sprite RShirtWater;
    [SerializeField] Sprite RShirtHealth;
    [SerializeField] Sprite RShirtGW;
    [Header("English Hayadata StickerTxt")]
    [SerializeField] Sprite ERMilkOzon;
    [SerializeField] Sprite ERMilkHealth;
    [SerializeField] Sprite ERMilkGW;
    [SerializeField] Sprite ERBottleEnergy;
    [SerializeField] Sprite ERBottleHealth;
    [SerializeField] Sprite ERBottleGW;
    [SerializeField] Sprite ERBrickEnergy;
    [SerializeField] Sprite ERBrickAcid;
    [SerializeField] Sprite ERBrickGW;
    [SerializeField] Sprite ERPhoneAcid;
    [SerializeField] Sprite ERPhoneHealth;
    [SerializeField] Sprite ERPhoneGW;
    [SerializeField] Sprite ERShirtWater;
    [SerializeField] Sprite ERShirtHealth;
    [SerializeField] Sprite ERShirtGW;
    [Header("Hebrew Nekuda StickerTxt")]
    [SerializeField] Sprite LMilkOzon;
    [SerializeField] Sprite LMilkHealth;
    [SerializeField] Sprite LMilkGW;
    [SerializeField] Sprite LBottleEnergy;
    [SerializeField] Sprite LBottleHealth;
    [SerializeField] Sprite LBottleGW;
    [SerializeField] Sprite LBrickEnergy;
    [SerializeField] Sprite LBrickAcid;
    [SerializeField] Sprite LBrickGW;
    [SerializeField] Sprite LPhoneAcid;
    [SerializeField] Sprite LPhoneHealth;
    [SerializeField] Sprite LPhoneGW;
    [SerializeField] Sprite LShirtWater;
    [SerializeField] Sprite LShirtHealth;
    [SerializeField] Sprite LShirtGW;
    [Header("English Nekuda StickerTxt")]
    [SerializeField] Sprite ELMilkOzon;
    [SerializeField] Sprite ELMilkHealth;
    [SerializeField] Sprite ELMilkGW;
    [SerializeField] Sprite ELBottleEnergy;
    [SerializeField] Sprite ELBottleHealth;
    [SerializeField] Sprite ELBottleGW;
    [SerializeField] Sprite ELBrickEnergy;
    [SerializeField] Sprite ELBrickAcid;
    [SerializeField] Sprite ELBrickGW;
    [SerializeField] Sprite ELPhoneAcid;
    [SerializeField] Sprite ELPhoneHealth;
    [SerializeField] Sprite ELPhoneGW;
    [SerializeField] Sprite ELShirtWater;
    [SerializeField] Sprite ELShirtHealth;
    [SerializeField] Sprite ELShirtGW;
    #endregion

    private void Awake()
    {
        myImage = GetComponent<Image>();
    }

    public void CheckLang(GameObject Eng, GameObject Heb)
    {
        if (_transitionManager._english)
        {
            Heb.SetActive(false);
            Eng.SetActive(true);
        }
        else
        {
            Eng.SetActive(false);
            Heb.SetActive(true);
        }
    }

    public void ActivateFindOutTxt()
    {
        if (!findOutYellowTxt.activeSelf)
        {
            StartCoroutine(FindOutTxtCoroutine());
        }
    }

    public void DeactivateFindOutTxt()
    {
        findOutYellowTxt.SetActive(false);
    }

    public void ToggleSticker(bool _rightSticker)
    {
        CornerImage.SetActive(buttonClicked);
        CornerButton.SetActive(buttonClicked);
        CornerAnimation.SetActive(buttonClicked);
        if (buttonClicked)
        {
            InitStickersText();
            if (_rightSticker)
            {
                if (_transitionManager._english)
                {
                    animatorRightE.SetTrigger("ClickedH");
                }
                else
                {
                    animatorRightH.SetTrigger("ClickedH");
                }
                rightStickerClicked = !buttonClicked;
            }
            else
            {
                if (_transitionManager._english)
                {
                    animatorLeftE.SetTrigger("ClickedN");
                }
                else
                {
                    animatorLeftH.SetTrigger("ClickedN");
                }
                leftStickerClicked = !buttonClicked;
            }
        }
        else
        {
            UpdateStickerText(_rightSticker);
            if (_rightSticker)
            {
                if (_transitionManager._english)
                {
                    animatorRightE.SetTrigger("ClickedH");
                }
                else
                {
                    animatorRightH.SetTrigger("ClickedH");
                }
                rightStickerClicked = !buttonClicked;
            }
            else
            {
                if (_transitionManager._english)
                {
                    animatorLeftE.SetTrigger("ClickedN");
                }
                else
                {
                    animatorLeftH.SetTrigger("ClickedN");
                }
                leftStickerClicked = !buttonClicked;
            }
        }
        buttonClicked = !buttonClicked;
    }

    public void UpdateStickerText(bool _rightSticker)
    {
        UpdateEnums();

        switch (myProduct)
        {
            case ProductName.Milk:
                switch (mySubCategory)
                {
                    case SubCategory.HealthDes:
                        SwapSprite(_rightSticker, RMilkHealth, LMilkHealth);
                        break;
                    case SubCategory.OzonDes:
                        SwapSprite(_rightSticker, RMilkOzon, LMilkOzon);
                        break;
                    case SubCategory.GWDes:
                        SwapSprite(_rightSticker, RMilkGW, LMilkGW);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EMilk:
                switch (mySubCategory)
                {
                    case SubCategory.EHealthDes:
                        SwapSprite(_rightSticker, ERMilkHealth, ELMilkHealth); 
                        break;
                    case SubCategory.EOzonDes:
                        SwapSprite(_rightSticker, ERMilkOzon, ELMilkOzon);
                        break;
                    case SubCategory.EGWDes:
                        SwapSprite(_rightSticker, ERMilkGW, ELMilkGW);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.Bottle:
                switch (mySubCategory)
                {
                    case SubCategory.HealthDes:
                        SwapSprite(_rightSticker, RBottleHealth, LBottleHealth); 
                        break;
                    case SubCategory.GWDes:
                        SwapSprite(_rightSticker, RBottleGW, LBottleGW);
                        break;
                    case SubCategory.EnergyDes:
                        SwapSprite(_rightSticker, RBottleEnergy, LBottleEnergy);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EBottle:
                switch (mySubCategory)
                {
                    case SubCategory.EHealthDes:
                        SwapSprite(_rightSticker, ERBottleHealth, ELBottleHealth);
                        break;
                    case SubCategory.EGWDes:
                        SwapSprite(_rightSticker, ERBottleGW, ELBottleGW);
                        break;
                    case SubCategory.EEnergyDes:
                        SwapSprite(_rightSticker, ERBottleEnergy, ELBottleEnergy);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.Shirt:
                switch (mySubCategory)
                {
                    case SubCategory.HealthDes:
                        SwapSprite(_rightSticker, RShirtHealth, LShirtHealth);
                        break;
                    case SubCategory.GWDes:
                        SwapSprite(_rightSticker, RShirtGW, LShirtGW);
                        break;
                    case SubCategory.WaterDes:
                        SwapSprite(_rightSticker, RShirtWater, LShirtWater);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EShirt:
                switch (mySubCategory)
                {
                    case SubCategory.EHealthDes:
                        SwapSprite(_rightSticker, ERShirtHealth, ELShirtHealth);
                        break;
                    case SubCategory.EGWDes:
                        SwapSprite(_rightSticker, ERShirtGW, ELShirtGW);
                        break;
                    case SubCategory.EWaterDes:
                        SwapSprite(_rightSticker, ERShirtWater, ELShirtWater);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.Brick:
                switch (mySubCategory)
                {
                    case SubCategory.GWDes:
                        SwapSprite(_rightSticker, RBrickGW, LBrickGW);
                        break;
                    case SubCategory.AcidDes:
                        SwapSprite(_rightSticker, RBrickAcid, LBrickAcid);
                        break;
                    case SubCategory.EnergyDes:
                        SwapSprite(_rightSticker, RBrickEnergy, LBrickEnergy);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EBrick:
                switch (mySubCategory)
                {
                    case SubCategory.EGWDes:
                        SwapSprite(_rightSticker, ERBrickGW, ELBrickGW);
                        break;
                    case SubCategory.EAcidDes:
                        SwapSprite(_rightSticker, ERBrickAcid, ELBrickAcid); ;
                        break;
                    case SubCategory.EEnergyDes:
                        SwapSprite(_rightSticker, ERBrickEnergy, ELBrickEnergy); 
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.Phone:
                switch (mySubCategory)
                {
                    case SubCategory.HealthDes:
                        SwapSprite(_rightSticker, RPhoneHealth, LPhoneHealth);
                        break;
                    case SubCategory.GWDes:
                        SwapSprite(_rightSticker, RPhoneGW, LPhoneGW); ;
                        break;
                    case SubCategory.AcidDes:
                        SwapSprite(_rightSticker, RPhoneAcid, LPhoneAcid);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EPhone:
                switch (mySubCategory)
                {
                    case SubCategory.EHealthDes:
                        SwapSprite(_rightSticker, ERPhoneHealth, ELPhoneHealth);
                        break;
                    case SubCategory.EGWDes:
                        SwapSprite(_rightSticker, ERPhoneGW, ELPhoneGW);
                        break;
                    case SubCategory.EAcidDes:
                        SwapSprite(_rightSticker, ERPhoneAcid, ELPhoneAcid);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        if (_rightSticker)
        {
            animatorLeftH.gameObject.SetActive(false);
            animatorLeftE.gameObject.SetActive(false);
        }
        else
        {
            animatorRightH.gameObject.SetActive(false);
            animatorRightE.gameObject.SetActive(false);
        }
    }

    public void InitStickersText()
    {
        if (cart.activeSelf)
        {
            return;
        }

        UpdateEnums();
        CheckLang(animatorRightE.gameObject, animatorRightH.gameObject);
        CheckLang(animatorLeftE.gameObject, animatorLeftH.gameObject);
        CheckLang(payment, leTashlum);

        switch (myProduct)
        {
            case ProductName.Milk:
                switch (mySubCategory)
                {
                    case SubCategory.HealthDes:
                        myImage.sprite = MilkHealth;
                        mySubCategory = SubCategory.HealthDes;
                        break;
                    case SubCategory.OzonDes:
                        myImage.sprite = MilkOzon;
                        mySubCategory = SubCategory.OzonDes;
                        break;
                    case SubCategory.GWDes:
                        myImage.sprite = MilkGW;
                        mySubCategory = SubCategory.GWDes;
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EMilk:
                switch (mySubCategory)
                {
                    case SubCategory.EHealthDes:
                        myImage.sprite = EMilkHealth;
                        mySubCategory = SubCategory.EHealthDes;
                        break;
                    case SubCategory.EOzonDes:
                        myImage.sprite = EMilkOzon;
                        mySubCategory = SubCategory.EOzonDes;
                        break;
                    case SubCategory.EGWDes:
                        myImage.sprite = EMilkGW;
                        mySubCategory = SubCategory.EGWDes;
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.Bottle:
                switch (mySubCategory)
                {
                    case SubCategory.HealthDes:
                        myImage.sprite = BottleHealth;
                        mySubCategory = SubCategory.HealthDes;
                        break;
                    case SubCategory.GWDes:
                        myImage.sprite = BottleGW;
                        mySubCategory = SubCategory.GWDes;
                        break;
                    case SubCategory.EnergyDes:
                        myImage.sprite = BottleEnergy;
                        mySubCategory = SubCategory.EnergyDes;
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EBottle:
                switch (mySubCategory)
                {
                    case SubCategory.EHealthDes:
                        myImage.sprite = EBottleHealth;
                        mySubCategory = SubCategory.EHealthDes;
                        break;
                    case SubCategory.EGWDes:
                        myImage.sprite = EBottleGW;
                        mySubCategory = SubCategory.EGWDes;
                        break;
                    case SubCategory.EEnergyDes:
                        myImage.sprite = EBottleEnergy;
                        mySubCategory = SubCategory.EEnergyDes;
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.Shirt:
                switch (mySubCategory)
                {
                    case SubCategory.HealthDes:
                        myImage.sprite = ShirtHealth;
                        mySubCategory = SubCategory.HealthDes;
                        break;
                    case SubCategory.GWDes:
                        myImage.sprite = ShirtGW;
                        mySubCategory = SubCategory.GWDes;
                        break;
                    case SubCategory.WaterDes:
                        myImage.sprite = ShirtWater;
                        mySubCategory = SubCategory.WaterDes;
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EShirt:
                switch (mySubCategory)
                {
                    case SubCategory.EHealthDes:
                        myImage.sprite = EShirtHealth;
                        mySubCategory = SubCategory.EHealthDes;
                        break;
                    case SubCategory.EGWDes:
                        myImage.sprite = EShirtGW;
                        mySubCategory = SubCategory.EGWDes;
                        break;
                    case SubCategory.EWaterDes:
                        myImage.sprite = EShirtWater;
                        mySubCategory = SubCategory.EWaterDes;
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.Brick:
                switch (mySubCategory)
                {
                    case SubCategory.GWDes:
                        myImage.sprite = BrickGW;
                        mySubCategory = SubCategory.GWDes;
                        break;
                    case SubCategory.AcidDes:
                        myImage.sprite = BrickAcid;
                        mySubCategory = SubCategory.AcidDes;
                        break;
                    case SubCategory.EnergyDes:
                        myImage.sprite = BrickEnergy;
                        mySubCategory = SubCategory.EnergyDes;
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EBrick:
                switch (mySubCategory)
                {
                    case SubCategory.EGWDes:
                        myImage.sprite = EBrickGW;
                        mySubCategory = SubCategory.EGWDes;
                        break;
                    case SubCategory.EAcidDes:
                        myImage.sprite = EBrickAcid;
                        mySubCategory = SubCategory.EAcidDes;
                        break;
                    case SubCategory.EEnergyDes:
                        myImage.sprite = EBrickEnergy;
                        mySubCategory = SubCategory.EEnergyDes;
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.Phone:
                switch (mySubCategory)
                {
                    case SubCategory.HealthDes:
                        myImage.sprite = PhoneHealth;
                        mySubCategory = SubCategory.HealthDes;
                        break;
                    case SubCategory.GWDes:
                        myImage.sprite = PhoneGW;
                        mySubCategory = SubCategory.GWDes;
                        break;
                    case SubCategory.AcidDes:
                        myImage.sprite = PhoneAcid;
                        mySubCategory = SubCategory.AcidDes;
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EPhone:
                switch (mySubCategory)
                {
                    case SubCategory.EHealthDes:
                        myImage.sprite = EPhoneHealth;
                        mySubCategory = SubCategory.EHealthDes;
                        break;
                    case SubCategory.EGWDes:
                        myImage.sprite = EPhoneGW;
                        mySubCategory = SubCategory.EGWDes;
                        break;
                    case SubCategory.EAcidDes:
                        myImage.sprite = EPhoneAcid;
                        mySubCategory = SubCategory.EAcidDes;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        _transitionManager.UpdateSubCatEnum(mySubCategory);
    }

    public void ResetClickedButtons()
    {
        if (rightStickerClicked)
        {
            if (_transitionManager._english)
            {
                animatorRightE.SetTrigger("ClickedH");
            }
            else
            {
                animatorRightH.SetTrigger("ClickedH");
            }
        }
        else if (leftStickerClicked)
        {
            if (_transitionManager._english)
            {
                animatorLeftE.SetTrigger("ClickedN");
            }
            else
            {
                animatorLeftH.SetTrigger("ClickedN");
            }
        }
        rightStickerClicked = false;
        leftStickerClicked = false;
        buttonClicked = false;
    }

    private void UpdateEnums()
    {
        myProduct = _transitionManager._currentProduct;
        mySubCategory = _transitionManager._currentSubCategory;
    }

    private void SwapSprite(bool _right, Sprite right, Sprite left)
    {
        if (_right)
        {
            myImage.sprite = right;
        }
        else
        {
            myImage.sprite = left;
        }
    }

    IEnumerator FindOutTxtCoroutine()
    {
        yield return new WaitForSeconds(5);
        if (CornerImage.activeSelf)
        {
            findOutYellowTxt.SetActive(true);
            findOutYellowTxt.GetComponent<ImageChanger>().SwapImage(myProduct);
        }
       
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SubCategory { HealthDes, OzonDes, GWDes, AcidDes, EnergyDes, WaterDes, EHealthDes, EOzonDes, EGWDes, EAcidDes, EEnergyDes, EWaterDes }
public class SubCatManager : MonoBehaviour
{
    private Image _myImage;
    [SerializeField] TransitionManager _transitionManager;
    [SerializeField] StickerManager _stickerManager;
    [SerializeField] GameObject _subDescription;
    [SerializeField] GameObject _findOutTxt;
    [SerializeField] GameObject ecoGradeHeb;
    [SerializeField] GameObject ecoGradeEng;
    [SerializeField] Image _subDescriptionImage;
    [SerializeField] public Animator _headerAnimation;
    [SerializeField] ImageChanger _pickCatToFindPrice;
    internal SubCategory currSubCat;
    private ProductName currProd;
    internal bool _pickCat;
    bool _subCat1, _subCat2, _subCat3;
    Color filled = new Color(1, 1, 1, 1);
    Color trans = new Color(1, 1, 1, 0);

    #region Sub Categories Text
    [Header("Hebrew")]
    [SerializeField] Sprite MilkOzon;
    [SerializeField] Sprite MilkHealth;
    [SerializeField] Sprite MilkGW;
    [SerializeField] Sprite MilkDef;
    [SerializeField] Sprite BottleEnergy;
    [SerializeField] Sprite BottleHealth;
    [SerializeField] Sprite BottleGW;
    [SerializeField] Sprite BottleDef;
    [SerializeField] Sprite BrickEnergy;
    [SerializeField] Sprite BrickAcid;
    [SerializeField] Sprite BrickGW;
    [SerializeField] Sprite BrickDef;
    [SerializeField] Sprite PhoneAcid;
    [SerializeField] Sprite PhoneHealth;
    [SerializeField] Sprite PhoneGW;
    [SerializeField] Sprite PhoneDef;
    [SerializeField] Sprite ShirtWater;
    [SerializeField] Sprite ShirtHealth;
    [SerializeField] Sprite ShirtGW;
    [SerializeField] Sprite ShirtDef;
    [Header("English")]
    [SerializeField] Sprite EMilkOzon;
    [SerializeField] Sprite EMilkHealth;
    [SerializeField] Sprite EMilkGW;
    [SerializeField] Sprite EMilkDef;
    [SerializeField] Sprite EBottleEnergy;
    [SerializeField] Sprite EBottleHealth;
    [SerializeField] Sprite EBottleGW;
    [SerializeField] Sprite EBottleDef;
    [SerializeField] Sprite EBrickEnergy;
    [SerializeField] Sprite EBrickAcid;
    [SerializeField] Sprite EBrickGW;
    [SerializeField] Sprite EBrickDef;
    [SerializeField] Sprite EPhoneAcid;
    [SerializeField] Sprite EPhoneHealth;
    [SerializeField] Sprite EPhoneGW;
    [SerializeField] Sprite EPhoneDef;
    [SerializeField] Sprite EShirtWater;
    [SerializeField] Sprite EShirtHealth;
    [SerializeField] Sprite EShirtGW;
    [SerializeField] Sprite EShirtDef;
    [Header("Hebrew Descripions")]
    [SerializeField] Sprite HealthDes;
    [SerializeField] Sprite OzonDes;
    [SerializeField] Sprite GWDes;
    [SerializeField] Sprite AcidDes;
    [SerializeField] Sprite EnergyDes;
    [SerializeField] Sprite WaterDes;
    [Header("English Descripions")]
    [SerializeField] Sprite EHealthDes;
    [SerializeField] Sprite EOzonDes;
    [SerializeField] Sprite EGWDes;
    [SerializeField] Sprite EAcidDes;
    [SerializeField] Sprite EEnergyDes;
    [SerializeField] Sprite EWaterDes;
    #endregion

    #region Circle Animations
    [Header("Hebrew Circle Animation")]
    [SerializeField] GameObject MilkCircles;
    [SerializeField] GameObject BottleCircles;
    [SerializeField] GameObject BrickCircles;
    [SerializeField] GameObject ShirtCircles;
    [SerializeField] GameObject PhoneCircles;
    [Header("English Circle Animation")]
    [SerializeField] GameObject EMilkCircles;
    [SerializeField] GameObject EBottleCircles;
    [SerializeField] GameObject EBrickCircles;
    [SerializeField] GameObject EShirtCircles;
    [SerializeField] GameObject EPhoneCircles;
    #endregion

    #region Circle Outlines
    [Header("Hebrew Circle Outlines")]
    [SerializeField] GameObject COMilkOzon;
    [SerializeField] GameObject COMilkHealth;
    [SerializeField] GameObject COMilkGW;
    [SerializeField] GameObject COBottleEnergy;
    [SerializeField] GameObject COBottleHealth;
    [SerializeField] GameObject COBottleGW;
    [SerializeField] GameObject COBrickEnergy;
    [SerializeField] GameObject COBrickAcid;
    [SerializeField] GameObject COBrickGW;
    [SerializeField] GameObject COPhoneAcid;
    [SerializeField] GameObject COPhoneHealth;
    [SerializeField] GameObject COPhoneGW;
    [SerializeField] GameObject COShirtWater;
    [SerializeField] GameObject COShirtHealth;
    [SerializeField] GameObject COShirtGW;
    [Header("English Circle Outlines")]
    [SerializeField] GameObject COEMilkOzon;
    [SerializeField] GameObject COEMilkHealth;
    [SerializeField] GameObject COEMilkGW;
    [SerializeField] GameObject COEBottleEnergy;
    [SerializeField] GameObject COEBottleHealth;
    [SerializeField] GameObject COEBottleGW;
    [SerializeField] GameObject COEBrickEnergy;
    [SerializeField] GameObject COEBrickAcid;
    [SerializeField] GameObject COEBrickGW;
    [SerializeField] GameObject COEPhoneAcid;
    [SerializeField] GameObject COEPhoneHealth;
    [SerializeField] GameObject COEPhoneGW;
    [SerializeField] GameObject COEShirtWater;
    [SerializeField] GameObject COEShirtHealth;
    [SerializeField] GameObject COEShirtGW;
    #endregion

    #region Corner Images
    [Header("Hebrew Corner Text")]
    [SerializeField] Sprite MilkCorner;
    [SerializeField] Sprite BottleCorner;
    [SerializeField] Sprite BrickCorner;
    [SerializeField] Sprite ShirtCorner;
    [SerializeField] Sprite PhoneCorner;
    [Header("English Corner Text")]
    [SerializeField] Sprite EMilkCorner;
    [SerializeField] Sprite EBottleCorner;
    [SerializeField] Sprite EBrickCorner;
    [SerializeField] Sprite EShirtCorner ;
    [SerializeField] Sprite EPhoneCorner ;
    #endregion

    private void Awake()
    {
        _myImage = GetComponent<Image>();
    }

    public void SetByEnum(ProductName currEnum)
    {
        currProd = currEnum;
        switch (currProd)
        {
            case ProductName.Milk:
                _myImage.sprite = MilkDef;
                currSubCat = SubCategory.HealthDes;
                break;
            case ProductName.EMilk:
                _myImage.sprite = EMilkDef;
                currSubCat = SubCategory.EHealthDes;
                break;
            case ProductName.Bottle:
                _myImage.sprite = BottleDef;
                currSubCat = SubCategory.HealthDes;
                break;
            case ProductName.EBottle:
                _myImage.sprite = EBottleDef;
                currSubCat = SubCategory.EHealthDes;
                break;
            case ProductName.Shirt:
                _myImage.sprite = ShirtDef;
                currSubCat = SubCategory.HealthDes;
                break;
            case ProductName.EShirt:
                _myImage.sprite = EShirtDef;
                currSubCat = SubCategory.EHealthDes;
                break;
            case ProductName.Brick:
                _myImage.sprite = BrickDef;
                currSubCat = SubCategory.AcidDes;
                break;
            case ProductName.EBrick:
                _myImage.sprite = EBrickDef;
                currSubCat = SubCategory.EAcidDes;
                break;
            case ProductName.Phone:
                _myImage.sprite = PhoneDef;
                currSubCat = SubCategory.HealthDes;
                break;
            case ProductName.EPhone:
                _myImage.sprite = EPhoneDef;
                currSubCat = SubCategory.EHealthDes;
                break;
            default:
                break;
        }
        ActivateCircle();
        _myImage.SetNativeSize();
        _transitionManager.UpdateSubCatEnum(currSubCat);
    }

    public bool AllSubCatPressed()
    {
        if (currProd == ProductName.Milk || currProd == ProductName.EMilk)
        {
            if (currSubCat == SubCategory.HealthDes || currSubCat == SubCategory.EHealthDes)
            {
                _subCat1 = true;
            }
            else if (currSubCat == SubCategory.GWDes || currSubCat == SubCategory.EGWDes)
            {
                _subCat2 = true;
            }
            else if (currSubCat == SubCategory.OzonDes || currSubCat == SubCategory.EOzonDes)
            {
                _subCat3 = true;
            }
        }
        else if (currProd == ProductName.Bottle || currProd == ProductName.EBottle)
        {
            if (currSubCat == SubCategory.HealthDes || currSubCat == SubCategory.EHealthDes)
            {
                _subCat1 = true;
            }
            else if (currSubCat == SubCategory.GWDes || currSubCat == SubCategory.EGWDes)
            {
                _subCat2 = true;
            }
            else if (currSubCat == SubCategory.EnergyDes || currSubCat == SubCategory.EEnergyDes)
            {
                _subCat3 = true;
            }
        }
        else if (currProd == ProductName.Shirt || currProd == ProductName.EShirt)
        {
            if (currSubCat == SubCategory.HealthDes || currSubCat == SubCategory.EHealthDes)
            {
                _subCat1 = true;
            }
            else if (currSubCat == SubCategory.GWDes || currSubCat == SubCategory.EGWDes)
            {
                _subCat2 = true;
            }
            else if (currSubCat == SubCategory.WaterDes || currSubCat == SubCategory.EWaterDes)
            {
                _subCat3 = true;
            }
        }
        else if (currProd == ProductName.Brick || currProd == ProductName.EBrick)
        {
            if (currSubCat == SubCategory.EnergyDes || currSubCat == SubCategory.EEnergyDes)
            {
                _subCat1 = true;
            }
            else if (currSubCat == SubCategory.GWDes || currSubCat == SubCategory.EGWDes)
            {
                _subCat2 = true;
            }
            else if (currSubCat == SubCategory.AcidDes || currSubCat == SubCategory.EAcidDes)
            {
                _subCat3 = true;
            }
        }
        else if (currProd == ProductName.Phone || currProd == ProductName.EPhone)
        {
            if (currSubCat == SubCategory.HealthDes || currSubCat == SubCategory.EHealthDes)
            {
                _subCat1 = true;
            }
            else if (currSubCat == SubCategory.GWDes || currSubCat == SubCategory.EGWDes)
            {
                _subCat2 = true;
            }
            else if (currSubCat == SubCategory.AcidDes || currSubCat == SubCategory.EAcidDes)
            {
                _subCat3 = true;
            }
        }

        if (_subCat1 && _subCat2 && _subCat3)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void ResetSubCatBools()
    {
        _subCat1 = false;
        _subCat2 = false;
        _subCat3 = false;
    }

    public void Left()
    {
        TurnPickCatOff();
        _transitionManager.CloseStickerTrans();
        _headerAnimation.Play("OpenSubTitles", -1, 0f);
        if (_findOutTxt.activeSelf)
        {
            _findOutTxt.SetActive(false);
        }
        switch (currProd)
        {
            case ProductName.Milk:
                if (_myImage.sprite == MilkOzon || _myImage.sprite == MilkDef)
                {
                    _myImage.sprite = MilkGW;
                    currSubCat = SubCategory.GWDes;
                }
                else if (_myImage.sprite == MilkHealth || _myImage.sprite == MilkDef)
                {
                    _myImage.sprite = MilkOzon;
                    currSubCat = SubCategory.OzonDes;
                }
                else if (_myImage.sprite == MilkGW || _myImage.sprite == MilkDef)
                {
                    _myImage.sprite = MilkOzon;
                    currSubCat = SubCategory.OzonDes;
                }
                break;

            case ProductName.EMilk:
                if (_myImage.sprite == EMilkOzon || _myImage.sprite == EMilkDef)
                {
                    _myImage.sprite = EMilkGW;
                    currSubCat = SubCategory.EGWDes;
                }
                else if (_myImage.sprite == EMilkHealth || _myImage.sprite == EMilkDef)
                {
                    _myImage.sprite = MilkOzon;
                    currSubCat = SubCategory.OzonDes;
                }
                else if (_myImage.sprite == EMilkGW || _myImage.sprite == EMilkDef)
                {
                    _myImage.sprite = EMilkOzon;
                    currSubCat = SubCategory.EOzonDes;
                }
                break;

            case ProductName.Bottle:
                if (_myImage.sprite == BottleEnergy || _myImage.sprite == BottleDef)
                {
                    _myImage.sprite = BottleHealth;
                    currSubCat = SubCategory.HealthDes;
                }
                else if (_myImage.sprite == BottleHealth || _myImage.sprite == BottleDef)
                {
                    _myImage.sprite = BottleEnergy;
                    currSubCat = SubCategory.EnergyDes;
                }
                else if (_myImage.sprite == BottleGW || _myImage.sprite == BottleDef)
                {
                    _myImage.sprite = BottleHealth;
                    currSubCat = SubCategory.HealthDes;
                }
                break;

            case ProductName.EBottle:
                if (_myImage.sprite == EBottleEnergy || _myImage.sprite == EBottleDef)
                {
                    _myImage.sprite = EBottleHealth;
                    currSubCat = SubCategory.EHealthDes;
                }
                else if (_myImage.sprite == EBottleHealth || _myImage.sprite == EBottleDef)
                {
                    _myImage.sprite = EBottleEnergy;
                    currSubCat = SubCategory.EEnergyDes;
                }
                else if (_myImage.sprite == EBottleGW || _myImage.sprite == EBottleDef)
                {
                    _myImage.sprite = EBottleHealth;
                    currSubCat = SubCategory.EHealthDes;
                }
                break;

            case ProductName.Shirt:
                if (_myImage.sprite == ShirtWater || _myImage.sprite == ShirtDef)
                {
                    _myImage.sprite = ShirtHealth;
                    currSubCat = SubCategory.HealthDes;
                }
                else if (_myImage.sprite == ShirtHealth || _myImage.sprite == ShirtDef)
                {
                    _myImage.sprite = ShirtWater;
                    currSubCat = SubCategory.WaterDes;
                }
                else if (_myImage.sprite == ShirtGW || _myImage.sprite == ShirtDef)
                {
                    _myImage.sprite = ShirtHealth;
                    currSubCat = SubCategory.HealthDes;
                }
                break;

            case ProductName.EShirt:
                if (_myImage.sprite == EShirtWater || _myImage.sprite == EShirtDef)
                {
                    _myImage.sprite = EShirtHealth;
                    currSubCat = SubCategory.EHealthDes;
                }
                else if (_myImage.sprite == EShirtHealth || _myImage.sprite == EShirtDef)
                {
                    _myImage.sprite = EShirtWater;
                    currSubCat = SubCategory.EWaterDes;
                }
                else if (_myImage.sprite == EShirtGW || _myImage.sprite == EShirtDef)
                {
                    _myImage.sprite = EShirtHealth;
                    currSubCat = SubCategory.EHealthDes;
                }
                break;

            case ProductName.Brick:
                if (_myImage.sprite == BrickEnergy || _myImage.sprite == BrickDef)
                {
                    _myImage.sprite = BrickAcid;
                    currSubCat = SubCategory.AcidDes;
                }
                else if (_myImage.sprite == BrickAcid || _myImage.sprite == BrickDef)
                {
                    _myImage.sprite = BrickEnergy;
                    currSubCat = SubCategory.EnergyDes;
                }
                else if (_myImage.sprite == BrickGW || _myImage.sprite == BrickDef)
                {
                    _myImage.sprite = BrickAcid;
                    currSubCat = SubCategory.AcidDes;
                }
                break;

            case ProductName.EBrick:
                if (_myImage.sprite == EBrickEnergy || _myImage.sprite == EBrickDef)
                {
                    _myImage.sprite = EBrickAcid;
                    currSubCat = SubCategory.EAcidDes;
                }
                else if (_myImage.sprite == EBrickAcid || _myImage.sprite == EBrickDef)
                {
                    _myImage.sprite = EBrickGW;
                    currSubCat = SubCategory.EGWDes;
                }
                else if (_myImage.sprite == EBrickGW || _myImage.sprite == EBrickDef)
                {
                    _myImage.sprite = EBrickAcid;
                    currSubCat = SubCategory.EAcidDes;
                }
                break;

            case ProductName.Phone:
                if (_myImage.sprite == PhoneAcid || _myImage.sprite == PhoneDef)
                {
                    _myImage.sprite = PhoneHealth;
                    currSubCat = SubCategory.HealthDes;
                }
                else if (_myImage.sprite == PhoneHealth || _myImage.sprite == PhoneDef)
                {
                    _myImage.sprite = PhoneAcid;
                    currSubCat = SubCategory.AcidDes;
                }
                else if (_myImage.sprite == PhoneGW || _myImage.sprite == PhoneDef)
                {
                    _myImage.sprite = PhoneHealth;
                    currSubCat = SubCategory.HealthDes;
                }
                break;

            case ProductName.EPhone:
                if (_myImage.sprite == EPhoneAcid || _myImage.sprite == EPhoneDef)
                {
                    _myImage.sprite = EPhoneHealth;
                    currSubCat = SubCategory.EHealthDes;
                }
                else if (_myImage.sprite == EPhoneHealth || _myImage.sprite == EPhoneDef)
                {
                    _myImage.sprite = EPhoneAcid;
                    currSubCat = SubCategory.EAcidDes;
                }
                else if (_myImage.sprite == EPhoneGW || _myImage.sprite == EPhoneDef)
                {
                    _myImage.sprite = EPhoneAcid;
                    currSubCat = SubCategory.EAcidDes;
                }
                break;
            default:
                break;
        }
        _myImage.SetNativeSize();
        _transitionManager.UpdateSubCatEnum(currSubCat);
        _stickerManager.InitStickersText();
        ActivateCircle();
        ActivateOutline();
        AllSubCatPressed();
    }

    public void Middle()
    {
        TurnPickCatOff();
        _transitionManager.CloseStickerTrans();
        _headerAnimation.Play("OpenSubTitles", -1, 0f);
        if (_findOutTxt.activeSelf)
        {
            _findOutTxt.SetActive(false);
        }
        switch (currProd)
        {
            case ProductName.Milk:
                if (_myImage.sprite == MilkDef)
                {
                    _myImage.sprite = MilkHealth;
                    currSubCat = SubCategory.HealthDes;
                }
                break;

            case ProductName.EMilk:
                if (_myImage.sprite == EMilkDef)
                {
                    _myImage.sprite = EMilkHealth;
                    currSubCat = SubCategory.EHealthDes;
                }
                break;

            case ProductName.Bottle:
                if (_myImage.sprite == BottleDef)
                {
                    _myImage.sprite = BottleHealth;
                    currSubCat = SubCategory.HealthDes;
                }
                break;

            case ProductName.EBottle:
                if (_myImage.sprite == EBottleDef)
                {
                    _myImage.sprite = EBottleHealth;
                    currSubCat = SubCategory.EHealthDes;
                }
                break;

            case ProductName.Shirt:
                if (_myImage.sprite == ShirtDef)
                {
                    _myImage.sprite = ShirtHealth;
                    currSubCat = SubCategory.HealthDes;
                }
                break;

            case ProductName.EShirt:
                if (_myImage.sprite == EShirtDef)
                {
                    _myImage.sprite = EShirtHealth;
                    currSubCat = SubCategory.EHealthDes;
                }
                break;

            case ProductName.Brick:
                if (_myImage.sprite == BrickDef)
                {
                    _myImage.sprite = BrickAcid;
                    currSubCat = SubCategory.AcidDes;
                }
                break;

            case ProductName.EBrick:
                if (_myImage.sprite == EBrickDef)
                {
                    _myImage.sprite = EBrickAcid;
                    currSubCat = SubCategory.EAcidDes;
                }
                break;

            case ProductName.Phone:
                if (_myImage.sprite == PhoneDef)
                {
                    _myImage.sprite = PhoneHealth;
                    currSubCat = SubCategory.HealthDes;
                }
                break;

            case ProductName.EPhone:
                if (_myImage.sprite == EPhoneDef)
                {
                    _myImage.sprite = EPhoneHealth;
                    currSubCat = SubCategory.EHealthDes;
                }
                break;
            default:
                break;
        }
        _myImage.SetNativeSize();
        _transitionManager.UpdateSubCatEnum(currSubCat);
        _stickerManager.InitStickersText();
        ActivateCircle();
        ActivateOutline();
        AllSubCatPressed();
    }

    public void Right()
    {
        TurnPickCatOff();
        _transitionManager.CloseStickerTrans();
        _headerAnimation.Play("OpenSubTitles", -1, 0f);
        if (_findOutTxt.activeSelf)
        {
            _findOutTxt.SetActive(false);
        }
        switch (currProd)
        {
            case ProductName.Milk:
                if (_myImage.sprite == MilkOzon || _myImage.sprite == MilkDef)
                {
                    _myImage.sprite = MilkHealth;
                    currSubCat = SubCategory.HealthDes;
                }
                else if (_myImage.sprite == MilkHealth || _myImage.sprite == MilkDef)
                {
                    _myImage.sprite = MilkGW;
                    currSubCat = SubCategory.GWDes;
                }
                else if (_myImage.sprite == MilkGW || _myImage.sprite == MilkDef)
                {
                    _myImage.sprite = MilkHealth;
                    currSubCat = SubCategory.HealthDes;
                }
                break;

            case ProductName.EMilk:
                if (_myImage.sprite == EMilkOzon || _myImage.sprite == EMilkDef)
                {
                    _myImage.sprite = EMilkHealth;
                    currSubCat = SubCategory.EHealthDes;
                }
                else if (_myImage.sprite == EMilkHealth || _myImage.sprite == EMilkDef)
                {
                    _myImage.sprite = EMilkGW;
                    currSubCat = SubCategory.EGWDes;
                }
                else if (_myImage.sprite == EMilkGW || _myImage.sprite == EMilkDef)
                {
                    _myImage.sprite = EMilkHealth;
                    currSubCat = SubCategory.EHealthDes;
                }
                break;

            case ProductName.Bottle:
                if (_myImage.sprite == BottleEnergy || _myImage.sprite == BottleDef)
                {
                    _myImage.sprite = BottleGW;
                    currSubCat = SubCategory.GWDes;
                }
                else if (_myImage.sprite == BottleHealth || _myImage.sprite == BottleDef)
                {
                    _myImage.sprite = BottleGW;
                    currSubCat = SubCategory.GWDes;
                }
                else if (_myImage.sprite == BottleGW || _myImage.sprite == BottleDef)
                {
                    _myImage.sprite = BottleEnergy;
                    currSubCat = SubCategory.EnergyDes;
                }
                break;

            case ProductName.EBottle:
                if (_myImage.sprite == EBottleEnergy || _myImage.sprite == EBottleDef)
                {
                    _myImage.sprite = EBottleGW;
                    currSubCat = SubCategory.EGWDes;
                }
                else if (_myImage.sprite == EBottleHealth || _myImage.sprite == EBottleDef)
                {
                    _myImage.sprite = EBottleGW;
                    currSubCat = SubCategory.EGWDes;
                }
                else if (_myImage.sprite == EBottleGW || _myImage.sprite == EBottleDef)
                {
                    _myImage.sprite = EBottleEnergy;
                    currSubCat = SubCategory.EEnergyDes;
                }
                break;

            case ProductName.Shirt:
                if (_myImage.sprite == ShirtWater || _myImage.sprite == ShirtDef)
                {
                    _myImage.sprite = ShirtGW;
                    currSubCat = SubCategory.GWDes;
                }
                else if (_myImage.sprite == ShirtHealth || _myImage.sprite == ShirtDef)
                {
                    _myImage.sprite = ShirtGW;
                    currSubCat = SubCategory.GWDes;
                }
                else if (_myImage.sprite == ShirtGW || _myImage.sprite == ShirtDef)
                {
                    _myImage.sprite = ShirtWater;
                    currSubCat = SubCategory.WaterDes;
                }
                break;

            case ProductName.EShirt:
                if (_myImage.sprite == EShirtWater || _myImage.sprite == EShirtDef)
                {
                    _myImage.sprite = EShirtGW;
                    currSubCat = SubCategory.EGWDes;
                }
                else if (_myImage.sprite == EShirtHealth || _myImage.sprite == EShirtDef)
                {
                    _myImage.sprite = EShirtGW;
                    currSubCat = SubCategory.EGWDes;
                }
                else if (_myImage.sprite == EShirtGW || _myImage.sprite == EShirtDef)
                {
                    _myImage.sprite = EShirtWater;
                    currSubCat = SubCategory.EWaterDes;
                }
                break;

            case ProductName.Brick:
                if (_myImage.sprite == BrickEnergy || _myImage.sprite == BrickDef)
                {
                    _myImage.sprite = BrickGW;
                    currSubCat = SubCategory.GWDes;
                }
                else if (_myImage.sprite == BrickAcid || _myImage.sprite == BrickDef)
                {
                    _myImage.sprite = BrickGW;
                    currSubCat = SubCategory.GWDes;
                }
                else if (_myImage.sprite == BrickGW || _myImage.sprite == BrickDef)
                {
                    _myImage.sprite = BrickEnergy;
                    currSubCat = SubCategory.EnergyDes;
                }
                break;

            case ProductName.EBrick:
                if (_myImage.sprite == EBrickEnergy || _myImage.sprite == EBrickDef)
                {
                    _myImage.sprite = EBrickGW;
                    currSubCat = SubCategory.EGWDes;
                }
                else if (_myImage.sprite == EBrickAcid || _myImage.sprite == EBrickDef)
                {
                    _myImage.sprite = EBrickEnergy;
                    currSubCat = SubCategory.EEnergyDes;
                }
                else if (_myImage.sprite == EBrickGW || _myImage.sprite == EBrickDef)
                {
                    _myImage.sprite = EBrickEnergy;
                    currSubCat = SubCategory.EEnergyDes;
                }
                break;

            case ProductName.Phone:
                if (_myImage.sprite == PhoneAcid || _myImage.sprite == PhoneDef)
                {
                    _myImage.sprite = PhoneGW;
                    currSubCat = SubCategory.GWDes;
                }
                else if (_myImage.sprite == PhoneHealth || _myImage.sprite == PhoneDef)
                {
                    _myImage.sprite = PhoneGW;
                    currSubCat = SubCategory.GWDes;
                }
                else if (_myImage.sprite == PhoneGW || _myImage.sprite == PhoneDef)
                {
                    _myImage.sprite = PhoneAcid;
                    currSubCat = SubCategory.AcidDes;
                }
                break;

            case ProductName.EPhone:
                if (_myImage.sprite == EPhoneAcid || _myImage.sprite == EPhoneDef)
                {
                    _myImage.sprite = EPhoneGW;
                    currSubCat = SubCategory.EGWDes;
                }
                else if (_myImage.sprite == EPhoneHealth || _myImage.sprite == EPhoneDef)
                {
                    _myImage.sprite = EPhoneGW;
                    currSubCat = SubCategory.EGWDes;
                }
                else if (_myImage.sprite == EPhoneGW || _myImage.sprite == EPhoneDef)
                {
                    _myImage.sprite = EPhoneHealth;
                    currSubCat = SubCategory.EHealthDes;
                }
                break;
            default:
                break;
        }
        _myImage.SetNativeSize();
        _transitionManager.UpdateSubCatEnum(currSubCat);
        _stickerManager.InitStickersText();
        ActivateCircle();
        ActivateOutline();
        AllSubCatPressed();
    }

    public void SicumHeader()
    {
        _headerAnimation.SetTrigger("Sicum");
        SetByEnum(currProd);
    }

    public void ShowDescription()
    {
        _subDescription.SetActive(true);

        switch (currSubCat)
        {
            case SubCategory.HealthDes:
                _subDescriptionImage.sprite = HealthDes;
                break;
            case SubCategory.OzonDes:
                _subDescriptionImage.sprite = OzonDes;
                break;
            case SubCategory.GWDes:
                _subDescriptionImage.sprite = GWDes;
                break;
            case SubCategory.AcidDes:
                _subDescriptionImage.sprite = AcidDes;
                break;
            case SubCategory.EnergyDes:
                _subDescriptionImage.sprite = EnergyDes;
                break;
            case SubCategory.WaterDes:
                _subDescriptionImage.sprite = WaterDes;
                break;
            case SubCategory.EHealthDes:
                _subDescriptionImage.sprite = EHealthDes;
                break;
            case SubCategory.EOzonDes:
                _subDescriptionImage.sprite = EOzonDes;
                break;
            case SubCategory.EGWDes:
                _subDescriptionImage.sprite = EGWDes;
                break;
            case SubCategory.EAcidDes:
                _subDescriptionImage.sprite = EAcidDes;
                break;
            case SubCategory.EEnergyDes:
                _subDescriptionImage.sprite = EEnergyDes;
                break;
            case SubCategory.EWaterDes:
                _subDescriptionImage.sprite = EWaterDes;
                break;
            default:
                break;
        }
    }

    public void CloseDescription()
    {
        _subDescription.SetActive(false);
    }

    public void TurnPickCatOff()
    {
        _pickCat = true;
        _pickCatToFindPrice.gameObject.SetActive(false);
    }

    private void CloseAllAnim()
    {
        MilkCircles.SetActive(false);
        EMilkCircles.SetActive(false);
        BottleCircles.SetActive(false);
        EBottleCircles.SetActive(false);
        BrickCircles.SetActive(false);
        EBrickCircles.SetActive(false);
        ShirtCircles.SetActive(false);
        EShirtCircles.SetActive (false);
        PhoneCircles.SetActive(false);
        EPhoneCircles.SetActive(false);
    }

    private void ActivateCircle()
    {
        CloseAllAnim();
        switch (currProd)
        {
            case ProductName.Milk:
                MilkCircles.SetActive(true);
                break;
            case ProductName.EMilk:
                EMilkCircles.SetActive(true);
                break;
            case ProductName.Bottle:
                BottleCircles.SetActive(true);
                break;
            case ProductName.EBottle:
                EBottleCircles.SetActive(true);
                break;
            case ProductName.Shirt:
                ShirtCircles.SetActive(true);
                break;
            case ProductName.EShirt:
                EShirtCircles.SetActive(true);
                break;
            case ProductName.Brick:
                BrickCircles.SetActive(true);
                break;
            case ProductName.EBrick:
                EBrickCircles.SetActive(true);
                break;
            case ProductName.Phone:
                PhoneCircles.SetActive(true);
                break;
            case ProductName.EPhone:
                EPhoneCircles.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void ActivateOutline()
    {
        CloseAllOutLines();
        switch (currProd)
        {
            case ProductName.Milk:
                switch (currSubCat)
                {
                    case SubCategory.HealthDes:
                        COMilkHealth.SetActive(true);
                        break;
                    case SubCategory.OzonDes:
                        COMilkOzon.SetActive(true);
                        break;
                    case SubCategory.GWDes:
                        COMilkGW.SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EMilk:
                switch (currSubCat)
                {
                    case SubCategory.EHealthDes:
                        COEMilkHealth.SetActive(true);
                        break;
                    case SubCategory.EOzonDes:
                        COEMilkOzon.SetActive(true);
                        break;
                    case SubCategory.EGWDes:
                        COEMilkGW.SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.Bottle:
                switch (currSubCat)
                {
                    case SubCategory.HealthDes:
                        COBottleHealth.SetActive(true);
                        break;
                    case SubCategory.GWDes:
                        COBottleGW.SetActive(true);
                        break;
                    case SubCategory.EnergyDes:
                        COBottleEnergy.SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EBottle:
                switch (currSubCat)
                {
                    case SubCategory.EHealthDes:
                        COEBottleHealth.SetActive(true);
                        break;
                    case SubCategory.EGWDes:
                        COEBottleGW.SetActive(true);
                        break;
                    case SubCategory.EEnergyDes:
                        COEBottleEnergy.SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.Shirt:
                switch (currSubCat)
                {
                    case SubCategory.HealthDes:
                        COShirtHealth.SetActive(true);
                        break;
                    case SubCategory.GWDes:
                        COShirtGW.SetActive(true);
                        break;
                    case SubCategory.WaterDes:
                        COShirtWater.SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EShirt:
                switch (currSubCat)
                {
                    case SubCategory.EHealthDes:
                        COEShirtHealth.SetActive(true);
                        break;
                    case SubCategory.EGWDes:
                        COEShirtGW.SetActive(true);
                        break;
                    case SubCategory.EWaterDes:
                        COEShirtWater.SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.Brick:
                switch (currSubCat)
                {
                    case SubCategory.GWDes:
                        COBrickGW.SetActive(true);
                        break;
                    case SubCategory.AcidDes:
                        COBrickAcid.SetActive(true);
                        break;
                    case SubCategory.EnergyDes:
                        COBrickEnergy.SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EBrick:
                switch (currSubCat)
                {
                    case SubCategory.EGWDes:
                        COEBrickGW.SetActive(true);
                        break;
                    case SubCategory.EAcidDes:
                        COEBrickAcid.SetActive(true);
                        break;
                    case SubCategory.EEnergyDes:
                        COEBrickEnergy.SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.Phone:
                switch (currSubCat)
                {
                    case SubCategory.HealthDes:
                        COPhoneHealth.SetActive(true);
                        break;
                    case SubCategory.GWDes:
                        COPhoneGW.SetActive(true);
                        break;
                    case SubCategory.AcidDes:
                        COPhoneAcid.SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            case ProductName.EPhone:
                switch (currSubCat)
                {
                    case SubCategory.EHealthDes:
                        COEPhoneHealth.SetActive(true);
                        break;
                    case SubCategory.EGWDes:
                        COEPhoneGW.SetActive(true);
                        break;
                    case SubCategory.EAcidDes:
                        COEPhoneAcid.SetActive(true);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }

        ResetEcoGrade();
    }

    private void OnDisable()
    {
        ecoGradeEng.SetActive(false);
        ecoGradeHeb.SetActive(false);
    }

    private void ResetEcoGrade()
    {
        ecoGradeEng.SetActive(false);
        ecoGradeHeb.SetActive(false);

        if (this.gameObject.activeSelf)
        {
            if (_transitionManager._english)
            {
                ecoGradeEng.SetActive(true);
            }
            else
            {
                ecoGradeHeb.SetActive(true);
            }
        }
        
    }

    private void CloseAllOutLines()
    {
        COMilkOzon.SetActive(false);
        COMilkHealth.SetActive(false);
        COMilkGW.SetActive(false);
        COBottleEnergy.SetActive(false);
        COBottleHealth.SetActive(false);
        COBottleGW.SetActive(false);
        COBrickEnergy.SetActive(false);
        COBrickAcid.SetActive(false);
        COBrickGW.SetActive(false);
        COPhoneAcid.SetActive(false);
        COPhoneHealth.SetActive(false);
        COPhoneGW.SetActive(false);
        COShirtWater.SetActive(false);
        COShirtHealth.SetActive(false);
        COShirtGW.SetActive(false);
        COEMilkOzon.SetActive(false);
        COEMilkHealth.SetActive(false);
        COEMilkGW.SetActive(false);
        COEBottleEnergy.SetActive(false);
        COEBottleHealth.SetActive(false);
        COEBottleGW.SetActive(false);
        COEBrickEnergy.SetActive(false);
        COEBrickAcid.SetActive(false);
        COEBrickGW.SetActive(false);
        COEPhoneAcid.SetActive(false);
        COEPhoneHealth.SetActive(false);
        COEPhoneGW.SetActive(false);
        COEShirtWater.SetActive(false);
        COEShirtHealth.SetActive(false);
        COEShirtGW.SetActive(false);
    }

    //qustionable
    IEnumerator FadeImage()
    {
        _myImage.color = trans;

        for (float i = 0; i >= 1; i += Time.deltaTime)
        {
            for (int j = 0; j < 30; j++)
                yield return null;

            _myImage.color = new Color(1, 1, 1, i);

            yield return null;
        }

        _myImage.color = filled;
    }

    public IEnumerator PickCatToFindPrice() //todo
    {
        yield return new WaitForSeconds(5);
        if (!_pickCat && !_stickerManager.gameObject.activeSelf && this.gameObject.activeSelf)
        {
            _pickCatToFindPrice.gameObject.SetActive(true);
            _pickCatToFindPrice.SwapImage(currProd);
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] StickerManager _stickerManager;
    [SerializeField] ObjectManager _objectManager;
    [SerializeField] ScreenSaver _screenSaver;
    [SerializeField] SubCatManager _subCatManager;
    [SerializeField] Button _middleCatButton;
    [SerializeField] float _resetTime;
    internal ProductName _currentProduct;
    internal SubCategory _currentSubCategory;
    internal bool _countdownStarted = false, _english = false, _idleSubCat = true;
    private float _timeTillReset;

    public ProductName currentProduct { get => _currentProduct; set => _currentProduct = value; }

    private void Awake()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (_countdownStarted)
        {
            StartResetTimer();
        }
    }

    public void ResetTimer()
    {
        _timeTillReset = _resetTime;
    }

    public void UpdateEnum(ProductName product)
    {
        if (_english)
        {
            switch (product)
            {
                case ProductName.Milk:
                    currentProduct = ProductName.EMilk;
                    break;
                case ProductName.Bottle:
                    currentProduct = ProductName.EBottle;
                    break;
                case ProductName.Shirt:
                    currentProduct = ProductName.EShirt;
                    break;
                case ProductName.Brick:
                    currentProduct = ProductName.EBrick;
                    break;
                case ProductName.Phone:
                    currentProduct = ProductName.EPhone;
                    break;
                default:
                    currentProduct = product;
                    break;
            }
            return;
        }
        else
        {
            switch (product)
            {
                case ProductName.EMilk:
                    currentProduct = ProductName.Milk;
                    break;
                case ProductName.EBottle:
                    currentProduct = ProductName.Bottle;
                    break;
                case ProductName.EShirt:
                    currentProduct = ProductName.Shirt;
                    break;
                case ProductName.EBrick:
                    currentProduct = ProductName.Brick;
                    break;
                case ProductName.EPhone:
                    currentProduct = ProductName.Phone;
                    break;
                default:
                    currentProduct = product;
                    break;
            }
            return;
        }
    }

    public void UpdateSubCatEnum(SubCategory category)
    {
        _currentSubCategory = category;
    }

    public void ToggleLanguage()
    {
        _english = !_english;
        UpdateEnum(_currentProduct);
        _screenSaver.ChangeLanguae(_english);

        foreach (GameObject obj in _objectManager.Allobjects)
        {
            if (obj.GetComponent<ImageChanger>() && obj.activeSelf)
            {
                obj.GetComponent<ImageChanger>().SwapImage(_currentProduct);
            }
            else if (obj.GetComponent<SubCatManager>() && obj.activeSelf)
            {
                obj.GetComponent<SubCatManager>().SetByEnum(_currentProduct);
            }
            else if (obj.GetComponent<StickerManager>() && obj.activeSelf)
            {
                StickerManager _mystickerManager = obj.GetComponent<StickerManager>();
                _mystickerManager.ResetClickedButtons();
                _mystickerManager.InitStickersText();
            }
        }
    }

    public void CloseStickerTrans()
    {
        if (_objectManager.StickersAndStuff[0].activeSelf)
        {
            DeActivateGO(_objectManager.StickersAndStuff);
        }
    }

    public void UserNotIdle()
    {
        _idleSubCat = false;
    }

    #region Transitions

    public void FullCartTransition()
    {
        _screenSaver.gameObject.SetActive(false);
        StartCoroutine(_subCatManager.PickCatToFindPrice());
        ActivateGO(_objectManager.FullCartList);
        StartCoroutine(DelayedFullCartTrans());
    }

    IEnumerator DelayedFullCartTrans()
    {
        yield return new WaitForSeconds(0.3f);
        if (_objectManager.Cart.activeSelf)
        {
            ActivateGO(_objectManager.DelayedFullCart);
        }
       
    }

    public void StickerTransition()
    {
        ActivateGO(_objectManager.StickersAndStuff);
        _stickerManager.InitStickersText();
    }

    public void SummeryTransition()
    {
        Transition(_objectManager.CloseBeforeSummery, _objectManager.Summery);
        Invoke("ShowHand", 10);
        Invoke("MoreProdAwait", 3);
    }

    public void ReverseSummeryTransition()
    {
        foreach (var item in _objectManager.Summery)
        {
            if (item.activeSelf)
            {
                _objectManager.HandPoint.SetActive(false);
                Transition(_objectManager.Summery, _objectManager.CloseBeforeSummery);
            }
        }
    }

    public void ResetTransition()
    {
        StartCoroutine(ResettingCoroutine());
    }

    IEnumerator ResettingCoroutine()
    {
        _subCatManager._pickCat = true;
        _subCatManager.ResetSubCatBools();
        DeActivateGO(_objectManager.Allobjects);
        _screenSaver.gameObject.SetActive(true);
        _idleSubCat = true;
        yield return new WaitForSeconds(0.2f);
        _subCatManager._pickCat = false;
    }

    #endregion

    private void ShowHand() 
    {
        if (_objectManager.Summery[0].activeSelf)
        {
            _objectManager.HandPoint.SetActive(true);
            _objectManager.HandPoint.GetComponent<ImageChanger>().SwapImage(_currentProduct);
        }

    }

    private void MoreProdAwait()
    {
        if (_objectManager.Summery[0].activeSelf)
        {
            if (_subCatManager.AllSubCatPressed())
            {
                _objectManager.MoreProdAwait.SetActive(true);
                _objectManager.MoreProdAwait.GetComponent<ImageChanger>().SwapImage(_currentProduct);
                RandomBubble();
            }
        }

    }

    private void RandomBubble()
    {
        int _temp = Random.Range(0, 2);

        switch (_temp)
        {
            case 0:
                _objectManager.PickMe.SetActive(true);
                StartCoroutine(FadeImage(_objectManager.PickMe));
                _objectManager.PickMe.GetComponent<ImageChanger>().SwapImage(_currentProduct);
                break;
            case 1:
                _objectManager.OnePlusOne.SetActive(true);
                StartCoroutine(FadeImage(_objectManager.OnePlusOne));
                _objectManager.OnePlusOne.GetComponent<ImageChanger>().SwapImage(_currentProduct);
                break;
            default:
                break;
        }
    }
  
    IEnumerator FadeImage(GameObject obj)
    {

        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
           
            yield return null;
        }
        obj.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
           
            // set color with i as alpha
            obj.GetComponent<Image>().color = new Color(1, 1, 1, i);
            yield return null;
        }
        obj.GetComponent<Image>().color = new Color(1, 1, 1, 0);

    }

    private void Transition(List<GameObject> ListToTurnOff, List<GameObject> ListToTurnOn)
    {
        DeActivateGO(ListToTurnOff);
        ActivateGO(ListToTurnOn);
    }

    private void ActivateGO(List<GameObject> GOList)
    {
        foreach (var obj in GOList)
        {
            obj.SetActive(true);
            if (obj.GetComponent<ImageChanger>())
            {
                obj.GetComponent<ImageChanger>().SwapImage(_currentProduct);
            }
            else if (obj.GetComponent<SubCatManager>())
            {
                obj.GetComponent<SubCatManager>().SetByEnum(_currentProduct);
            }
            else if (obj.GetComponent<StickerManager>() && obj.activeSelf)
            {
                StickerManager _mystickerManager = obj.GetComponent<StickerManager>();
                _mystickerManager.ResetClickedButtons();
                _mystickerManager.InitStickersText();
            }
        }
    }

    private void DeActivateGO(List<GameObject> gameObjects)
    {
        foreach (GameObject _gObject in gameObjects)
        {
            _gObject.SetActive(false);
        }
    }

    private void StartResetTimer()
    {
        _timeTillReset -= Time.deltaTime;
        if (_timeTillReset <= 90)
        {
            if (_idleSubCat)
            {
                _middleCatButton.onClick.Invoke();
            }
        }

        if (_timeTillReset <= 0)
        {
            ResetTransition();
            _countdownStarted = false;
            _timeTillReset = _resetTime;
        }
    }
    public bool GetLanguage()
    {
        return _english;
    }

}
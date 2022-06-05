using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour
{
    [SerializeField] public List<Product> products;
    [SerializeField] public TransitionManager transitionManager;
    [SerializeField] Animator _myAnimation;
    Product productInCart;

    private void Awake()
    {
        if (!_myAnimation)
            _myAnimation = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        foreach (Product prod in products)
        {
            prod.gameObject.SetActive(false);
        }
        _myAnimation.Rebind();
        _myAnimation.Update(0f);
        productInCart = null;
    }

    public void AddToCart(Product product)
    {
        RefreshCart(product);

        if (productInCart != null)
            _myAnimation.SetTrigger("Slide");

        transitionManager._countdownStarted = true;
    }

    public void ResetCart()
    {
        productInCart = null;
        foreach (Product prod in products)
        {
            prod.gameObject.SetActive(false);
        }
            _myAnimation.Play("CartDefault"); //todo

    }

    private void RefreshCart(Product product)
    {
        if (productInCart != null)
            productInCart.gameObject.SetActive(false);

        foreach (var _product in products)
        {
            //matching products
            if (_product.productName == product.productName)
            {
                //product found
                productInCart = _product;
               
                _product.gameObject.SetActive(true);

                transitionManager.UpdateEnum(productInCart.productName);
                transitionManager.FullCartTransition();

                break;
            }
        }
    }

}
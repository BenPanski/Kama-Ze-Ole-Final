using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerTrans : MonoBehaviour
{
    [SerializeField] TransitionManager transitionManager;
    [SerializeField] GameObject cart;

    public void PlayTransition()
    {
        cart.SetActive(false);
        transitionManager.StickerTransition();
    }

}
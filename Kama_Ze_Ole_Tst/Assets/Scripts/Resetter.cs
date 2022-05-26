using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CornerPos { BL, TL, BR, TR }
public class Resetter : MonoBehaviour
{
    [SerializeField] TransitionManager _transitionManager;
    BoxCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _collider.enabled = false;
    }

    private void OnEnable()
    {
        StartCoroutine(TurnColliderOn());
    }

    private void OnDisable()
    {
        _collider.enabled = false;
    }

    IEnumerator TurnColliderOn()
    {
        yield return new WaitForSeconds(0.5f);
        _collider.enabled = true;
    }

    public void ResetTrans()
    {
        _transitionManager.ResetTransition();
    }

    public void OpenSubHeadText()
    {
        _transitionManager.FadeInSubHeadText();
    }

    public void FadeOutSubHeadText()
    {
        _transitionManager.FadeOutSubHeadText();
    }

    //public void RotateProduct(Transform carriedProduct)
    //{
    //    if (carriedProduct.transform.rotation.z == 0)
    //    {
    //        switch (myPos)
    //        {
    //            case CornerPos.BL:
    //                carriedProduct.Rotate(0, 0, -41.5f);
    //                break;
    //            case CornerPos.TL:
    //                carriedProduct.Rotate(0, 0, -131.5f);
    //                break;
    //            case CornerPos.BR:
    //                carriedProduct.Rotate(0, 0, 41.5f);
    //                break;
    //            case CornerPos.TR:
    //                carriedProduct.Rotate(0, 0, 131.5f);
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //}

}
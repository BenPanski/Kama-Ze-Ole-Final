using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    internal List<GameObject> Allobjects = new List<GameObject>();
    [Header("Cart")]
    public GameObject Cart;
    [Header("FullCart")]
    public List<GameObject> FullCartList = new List<GameObject>();
    public Image SubHeaderImage;

    public List<GameObject> DelayedFullCart = new List<GameObject>();

    [Header("OpenHeader")]
    public List<GameObject> StickersAndStuff = new List<GameObject>();

    [Header("OpenSummery")]
    public List<GameObject> Summery = new List<GameObject>();
    public GameObject HandPoint;
    public GameObject FindOutYellowTxt;
    public GameObject MoreProdAwait;
    public GameObject PickCatToFindPrice;
    public GameObject OnePlusOne;
    public GameObject PickMe;

    [Header("Close Before Summery")]
    public List<GameObject> CloseBeforeSummery = new List<GameObject>();
    public List<GameObject> EnlargedImages = new List<GameObject>();
    public List<GameObject> EnlargedImageButtonCover = new List<GameObject>();

    private void Start()
    {
        Allobjects.AddRange(StickersAndStuff);
        Allobjects.AddRange(DelayedFullCart);
        Allobjects.AddRange(EnlargedImages);
        Allobjects.AddRange(EnlargedImageButtonCover);
        Allobjects.AddRange(FullCartList);
        Allobjects.AddRange(Summery);
        Allobjects.Add(PickMe);
        Allobjects.Add(HandPoint);
        Allobjects.Add(OnePlusOne);
        Allobjects.Add(MoreProdAwait);
        Allobjects.Add(FindOutYellowTxt);
        Allobjects.Add(PickCatToFindPrice);
    }

}
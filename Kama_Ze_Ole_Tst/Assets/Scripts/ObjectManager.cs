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

    [Header("Enlarged Images")]
    public List<GameObject> EnlargedImages = new List<GameObject>();

    private void Start()
    {
        Allobjects.AddRange(StickersAndStuff);
        Allobjects.AddRange(EnlargedImages);
        Allobjects.AddRange(FullCartList);
        Allobjects.AddRange(DelayedFullCart);
        Allobjects.AddRange(Summery);
        Allobjects.Add(HandPoint);
        Allobjects.Add(FindOutYellowTxt);
        Allobjects.Add(MoreProdAwait);
        Allobjects.Add(PickCatToFindPrice);
        Allobjects.Add(OnePlusOne);
        Allobjects.Add(PickMe);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnlargeImage : MonoBehaviour
{
    [SerializeField] Image MyImage;
    [SerializeField] ObjectManager myObjManager;

    public void ToggleEnlargedImage()
    {
        if (MyImage.enabled)
        {
            myObjManager.EnlargedImages.Remove(this.gameObject);
            MyImage.enabled = false;
        }
        else
        {
            CloseEnlargedImages();
            MyImage.enabled = true;
            myObjManager.EnlargedImages.Add(this.gameObject);
        }
    }

    public void CloseEnlargedImages()
    {
        if (myObjManager.EnlargedImages.Count > 0)
        {
            List<GameObject> toRemovelist = new List<GameObject>();

            foreach (GameObject obj in myObjManager.EnlargedImages)
            {
                //get other active myImage from Enlarge script and close it
                Image image;
                if (image = obj.GetComponent<EnlargeImage>().MyImage)
                {
                    image.enabled = false;
                }

                //add myImage GameObject to remove list
                toRemovelist.Add(obj);
            }

            //remove myImage GameObject from ObjManager list
            foreach (GameObject obj in toRemovelist)
            {
                myObjManager.EnlargedImages.Remove(obj);
            }
        }
    }

}
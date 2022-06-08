using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class FadeInOnEnable : MonoBehaviour
{
    [SerializeField] int fadeinTime = 1;

    private Image myImage;
    private Color full = new Color(1, 1, 1, 1);
    private Color transperant = new Color(1, 1, 1, 0);

    private void Awake()
    {
        myImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        StartCoroutine(FadeInImage(myImage, fadeinTime));
    }

    IEnumerator FadeInImage(Image obj, int time)
    {
        obj.color = transperant;

        for (float i = time; i >= 0; i -= Time.deltaTime)
        {
            if (!gameObject.activeSelf)
            {
                yield break;
            }
            // set color with i as alpha
            obj.color = new Color(1, 1, 1, i);
        }

        if (!gameObject.activeSelf)
        {
            yield break;
        }

        obj.color = full;
    }

}
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class FadeInOnEnable : MonoBehaviour
{
    [SerializeField] float fadeinTime = 1, delayTime = 0;

    private Image myImage;
    private Color full = new Color(1, 1, 1, 1);
    private Color transperant = new Color(1, 1, 1, 0);

    private void Awake()
    {
        myImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        StartCoroutine(FadeInImage(myImage, fadeinTime, delayTime));
    }

    IEnumerator FadeInImage(Image obj, float time, float delay)
    {
        obj.color = transperant;

        yield return new WaitForSeconds(delay);

        for (float i = 0; i <= time; i += Time.deltaTime)
        {
            if (!gameObject.activeSelf)
            {
                yield break;
            }

            yield return null;
            obj.color = new Color(1, 1, 1, i);
        }

        obj.color = full;
    }

}
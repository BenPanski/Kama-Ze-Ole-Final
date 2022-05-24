using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngToHebrewFix : MonoBehaviour
{
    [SerializeField]
    public bool IAmEng;
    [SerializeField]
    public TransitionManager tranManager;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (tranManager.GetLanguage() != IAmEng)
        {
            this.gameObject.SetActive(false);
        }
    }
}

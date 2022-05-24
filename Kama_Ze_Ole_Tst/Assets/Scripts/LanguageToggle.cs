using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageToggle : MonoBehaviour
{
    [SerializeField] TransitionManager transitionManager;

    public void UpdateLanguage()
    {
        transitionManager.ToggleLanguage();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    #region Singleton

    public static HeroManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject hero;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInMobileOnly : MonoBehaviour
{
    private void Start()
    {
#if !UNITY_EDITOR
        gameObject.SetActive(Application.isMobilePlatform);
#endif
    }
}

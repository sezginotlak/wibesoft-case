using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageButtons : MonoBehaviour
{
    Button button;

    [SerializeField]
    GameObject thisPage;

    [SerializeField]
    List<GameObject> otherPageList;

    private void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        thisPage.SetActive(true);

        foreach (GameObject page in otherPageList)
        {
            page.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MenuButtonSelected : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject UnderlineImage;
    Vector3 positionOffSet;
    private void Start()
    {
        positionOffSet = new Vector3(gameObject.transform.position.x - 20, gameObject.transform.position.y - 50, 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
        UnderlineImage.transform.position = positionOffSet;
        UnderlineImage.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().rect.width, 25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle ^= FontStyles.Bold;
    }
}

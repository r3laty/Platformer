using System.Collections;
using TMPro;
using UnityEngine;

public class RaisingItemController : MonoBehaviour
{
    [SerializeField] private BringKeyCard keyCardScript;
    [SerializeField] private TextMeshProUGUI raisedText;
    [SerializeField] private GameObject aboutItemMenu;
    private bool learnMore;
    private void Update()
    {
        //raising text activate
        if (keyCardScript.pickedUp)
        {
            StartCoroutine(RaisingTextActivating());
            learnMore = true;
        }
        //about item menu
        if (learnMore && Input.GetKeyDown(KeyCode.Tab))
        {
            aboutItemMenu.SetActive(true);
        }
        else if (learnMore && Input.GetKeyUp(KeyCode.Tab))
        {
            aboutItemMenu.SetActive(false);
        }
    }
    private IEnumerator RaisingTextActivating()
    {
        raisedText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);
        Vector3 newPosition = new Vector3(-221.9f, -129.7f, 0);
        Vector2 newScale = new Vector2(209.9684f, 30.1511f);

        raisedText.text = "ключ карта";
        raisedText.fontSize = 24;
        raisedText.transform.localPosition = newPosition;
        raisedText.rectTransform.sizeDelta = newScale;
    }

}

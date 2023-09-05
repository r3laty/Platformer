using System.Collections;
using UnityEngine;

public class Exploison : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private BoxCollider2D bunchOfDynamiteCollider;
    [SerializeField] private GameObject bunchOfDynamiteGO;
    [SerializeField] private Animator exploisonAnime;
    [SerializeField] private LeverSwitch leverSwitch;
    private bool _triggerOfExplosion;
    private Exploison _exploisonScript;
    private void Awake()
    {
        _exploisonScript = GetComponent<Exploison>();
    }
    private void Update() 
    {
        StartCoroutine(Boom());

        if (leverSwitch.toggleSwitch) Debug.Log("toggle switch");
    }
    private IEnumerator Boom()
    {
        if(leverSwitch.toggleSwitch && _triggerOfExplosion)
        {
            Debug.Log("Coroutine started");
            exploisonAnime.SetBool("Boom", true);
            bunchOfDynamiteGO.transform.position = new Vector3(31.5f, 9.08f, 0);
            bunchOfDynamiteGO.transform.localScale = new Vector3(0.3207118f, 0.3207118f, 0.3207118f);

            yield return new WaitForSeconds(0.3f);

            bunchOfDynamiteCollider.isTrigger = false;
            Destroy(wall);
            Destroy(bunchOfDynamiteGO);
            Destroy(_exploisonScript);
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerOfExplosion"))
        {
            _triggerOfExplosion = true;
            Debug.Log("Worked");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerOfExplosion"))
        {
            _triggerOfExplosion = false;
            Debug.Log("Doesnt work");
        }
    }
    private void OnDestroy()
    {
        Destroy(_exploisonScript);
    }
}

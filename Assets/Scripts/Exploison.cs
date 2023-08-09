using System.Collections;
using UnityEngine;

public class Exploison : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private BoxCollider2D bunchOfDynamiteCollider;
    [SerializeField] private GameObject bunchOfDynamiteGO;
    [SerializeField] private Animator exploisonAnime;
    private bool triggerOfExplosion;
    private LeverSwitch _leverSwitch;
    private Exploison _exploisonScript;
    private void Awake()
    {
        _leverSwitch = GetComponent<LeverSwitch>();
        _exploisonScript = GetComponent<Exploison>();
    }
    private void Update() 
    {
        StartCoroutine(Boom());
    }
    private IEnumerator Boom()
    {
        if(_leverSwitch.toggleSwitch && triggerOfExplosion)
        {
            exploisonAnime.SetBool("Boom", true);
            bunchOfDynamiteGO.transform.position = new Vector3(31.5f, 9.08f, 0);
            bunchOfDynamiteGO.transform.localScale = new Vector3(0.3207118f, 0.3207118f, 0.3207118f);

            yield return new WaitForSeconds(0.3f);

            bunchOfDynamiteCollider.isTrigger = false;
            Destroy(wall);
            Destroy(GameObject.FindGameObjectWithTag("Boom"));
            Destroy(gameObject.GetComponent<Exploison>());
        }   
    }
    private void OnDestroy()
    {
        Destroy(_exploisonScript);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("TriggerOfExplosion"))
        {
            triggerOfExplosion = true;
        }   
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("TriggerOfExplosion"))
        {
            triggerOfExplosion = false;
        }    
    }
}

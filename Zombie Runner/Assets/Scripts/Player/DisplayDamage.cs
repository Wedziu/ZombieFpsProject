using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas;
    [SerializeField] float damageTime = .3f;   // Start is called before the first frame update
    void Start()
    {
        damageCanvas.enabled = false;
    }
    public void ShowDamageCanvas()
    {
        StartCoroutine(showSplatter());
    }
    IEnumerator showSplatter()
    {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(damageTime);
        damageCanvas.enabled = false;
    }
}

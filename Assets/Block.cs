using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    public Image progressBar;
    private TextMeshProUGUI pBtext;
    public Color color1;
    public Color color2;
    public float holdTime = 3f;
    private float breakTime = 0.5f;
    private Coroutine holdCoroutine;
    public bool isDown = false;
    public bool finished = false;
    private void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        pBtext = progressBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ProgressBar(0f);
    }

    public void Tap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            spriteRenderer.color = color2;
            Debug.Log("Tap");
            isDown = true;
        }
  
    }

    public void Hold(InputAction.CallbackContext context)
    {
        
        if (context.started)
        {
            holdCoroutine = StartCoroutine(HoldForSeconds());
            Debug.Log("Hold Started");
            spriteRenderer.color = color2;
            isDown = true;
        }
        else if (context.canceled)
        {
            if (holdCoroutine != null)
            {
                StopCoroutine(holdCoroutine);
                holdCoroutine = null;
                Debug.Log("Hold Canceled");
                ProgressBar(0f);
            }
   
                isDown = false;
        }

    }

    private IEnumerator HoldForSeconds()
    {
        for(float time = 0f; time < holdTime + breakTime; time += Time.deltaTime)
        {
            ProgressBar(time / holdTime);
            if (time >= holdTime && time < holdTime + breakTime)
            {
                ActivateBlock();
                ProgressBar(1f);
                yield return new WaitForSeconds(breakTime);
                ProgressBar(0f);
                break;
            }
 
            yield return null;
        }
        Debug.LogWarning("HoldForSeconds Coroutine Finished block is broken");

 

        holdCoroutine = null;
    }

    private void ActivateBlock()
    {
        Debug.Log("Block Activated");
        spriteRenderer.color = color1;
    }

    private void ProgressBar(float value)
    {
        if(progressBar.gameObject.activeSelf)
        {
            progressBar.fillAmount = value;
            pBtext.text = value.ToString("P0");
            if (value == 0f)
            {
                pBtext.text = "";
                pBtext.color = Color.white;
                progressBar.color = Color.white;
                finished = false;
            }
            else if (value == 1f)
            {
                pBtext.color = Color.green;
                progressBar.color = Color.green;
                finished = true;


            }

        }
        else
        {
            return;
        }   

    }
    
}

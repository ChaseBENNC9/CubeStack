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
    public Color normalColor;
    bool ready = false;
    public Color readyColor;
    public Color activeColor;
    public Color brokenColor;
    public float holdTime = 3f;
    private float breakThreshold = 0.25f;
    private Coroutine holdCoroutine;
    public bool isDown = false;
    public bool finished = false;
    private void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        pBtext = progressBar.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ProgressBar(0f,false);
        SetColor(normalColor, 1f);
    }

    public void Tap(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SetColor(readyColor, 0f);
            isDown = true;
            Debug.Log("Tapped");
            ready = true;
        }
  
    }

    public void Hold(InputAction.CallbackContext context)
    {
        if (!ready)
            return;
        if (context.started)
        {
            holdCoroutine = StartCoroutine(HoldForSeconds());
            isDown = true;
            SetColor(readyColor, 0f);
        }
        else if (context.canceled)
        {
            if (holdCoroutine != null)
            {
                StopCoroutine(holdCoroutine);
                holdCoroutine = null;
                ProgressBar(0f, false);
            }
   
                isDown = false;
        }

    }

    private IEnumerator HoldForSeconds()
    {
        for(float time = 0f; time < holdTime + breakThreshold; time += Time.deltaTime)
        {
            ProgressBar(time / holdTime);
            if (time >= holdTime && time < holdTime + breakThreshold)
            {
                ActivateBlock();
                ProgressBar(1f);
                holdCoroutine = null;
            }
            yield return null;
 
        }
        if(isDown)
            BreakBlock();
 

        holdCoroutine = null;
    }

    private void ActivateBlock()
    {
        SetColor(activeColor, 1f);
    }



    public void BreakBlock()
    {
        SetColor(brokenColor, 1f);
    }
    private void ProgressBar(float value,bool affectSprite = true)
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
        
        if (affectSprite){
            SetColor(spriteRenderer.color, value);
        }   

    }

    private void SetColor(Color color, float alpha)
    {
        color.a = alpha;
        spriteRenderer.color = color;
    }
    
}

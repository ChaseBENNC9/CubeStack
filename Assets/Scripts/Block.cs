using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// Manages the behavior of a Block. 
/// </summary>
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

/// <summary>
/// Called when the player taps the screen. This will set the Block to ready.
/// </summary>
/// <param name="context"></param>
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

    /// <summary>
    /// Called when the player holds the screen. This will start the coroutine to manage the time to hold the Block.
    /// </summary>
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

    /// <summary>
    /// Coroutine to manage the time to hold the Block. It will activate the Block if the player holds it for the required time. and break it if the player holds it for too long.
    /// </summary>

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

/// <summary>
/// Activates the Block when the player holds it for the required time.
/// </summary>
    private void ActivateBlock()
    {
        SetColor(activeColor, 1f);
    }



/// <summary>
/// Breaks the Block when the player holds it for too long.
/// </summary>
    public void BreakBlock()
    {
        SetColor(brokenColor, 1f);
    }

/// <summary>
/// Changes the color and the progressbar based on how long the player has been holding the Block. will be changed to a better indicator in the future.
/// </summary>
/// <param name="value">The value</param>
/// <param name="affectSprite">Whether to change the sprite color or just the progress bar</param>
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


/// <summary>
/// Changes the color of the Block.
/// </summary>
/// <param name="color">The RGB Color</param>
/// <param name="alpha">The new transparency</param>
    private void SetColor(Color color, float alpha)
    {
        color.a = alpha;
        spriteRenderer.color = color;
    }
    
}

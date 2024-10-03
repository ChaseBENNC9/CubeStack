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
    private SpriteRenderer spriteRenderer,backgroundSprite;
    public Image progressBar;
    public Color normalColor;
    bool ready = false;
    public Color readyColor;
    public Color activeColor;
    public Color placedColor;
    public Color brokenColor;
    public float holdTime = 3f;
    private float breakThreshold = 0.25f;
    private Coroutine holdCoroutine;
    public bool isDown = false;
    public bool finished = false;
    private int blockStrength = 100;
    [SerializeField] private BlockState blockState;
    [SerializeField] private TextMeshProUGUI strengthtext;
    private PopUp popup;

    public BlockState BlockState
    {
        set
        {
            blockState = value;
            if (blockState == BlockState.Ready)
            {
                GetComponent<Rigidbody2D>().gravityScale = 1;
                BlockManager.instance.ghostBlock = null;
            }
            else if (blockState == BlockState.Moving)
            {
                GetComponent<Rigidbody2D>().gravityScale = 0;
            }


        }
        get
        {
            return blockState;
        }
    }


    public float BlockHeight()
    {
        Debug.Log("The Block Y " + gameObject.transform.position.y);
        return gameObject.transform.position.y;
    }
    private void Start()
    {
        BlockState = BlockState.Moving;
        StartCoroutine(MoveBlock());
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        backgroundSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        popup = transform.Find("Canvas").transform.Find("PopUp").GetComponent<PopUp>();
        popup.GetComponent<Animator>().enabled = false;
        ProgressBar(0f, false);
        SetColor(normalColor, 0f);
        SetColor(normalColor, 0.1f, true);
    }

    /// <summary>
    /// Called when the player taps the screen. This will set the Block to ready.
    /// </summary>
    /// <param name="context"></param>
    public void Tap(InputAction.CallbackContext context)
    {
        if (BlockState == BlockState.Moving)
        {
            if (context.performed)
            {
                SetColor(readyColor, 0f);
                SetColor(readyColor, 0.1f, true);
                isDown = true;
                Debug.Log("Tapped");
                ready = true;
                BlockState = BlockState.Ready;
            }
        }
        if (context.canceled)
        {
            Debug.Log("finger up");
        }

    }

    /// <summary>
    /// Called when the player holds the screen. This will start the coroutine to manage the time to hold the Block.
    /// </summary>
    public void Hold(InputAction.CallbackContext context)
    {
        if (!ready || BlockState != BlockState.Ready)
            return;
        if (context.started)
        {
            holdCoroutine = StartCoroutine(HoldForSeconds());
            isDown = true;
            SetColor(readyColor, 0f);
            SetColor(readyColor,0.1f,true);
        }
        else if (context.canceled)
        {
            if (holdCoroutine != null)
            {
                StopCoroutine(holdCoroutine);
                holdCoroutine = null;
                ProgressBar(blockStrength / 100f);
                PlaceWeakenedBlock();

            }

            isDown = false;
        }

    }

    /// <summary>
    /// Coroutine to manage the time to hold the Block. It will activate the Block if the player holds it for the required time. and break it if the player holds it for too long.
    /// </summary>

    private IEnumerator HoldForSeconds()
    {
        for (float time = 0f; time < holdTime + breakThreshold; time += Time.deltaTime)
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
        if (isDown)
            BreakBlock();
        else
            PlacePerfectBlock();



        holdCoroutine = null;
    }



/// <summary>
/// Places the Block in the stack and sets the color based on the score and the state of the Block.
/// </summary>
/// <param name="score">How Much score the placement is worth</param>
/// <param name="state">what state the placed block is in</param>
/// <param name="colorIntensity">tbe intensity of the block color</param>

private void PlaceBlock(int score, BlockState state, float colorIntensity)
    {
        DoPopup();
        ScoreManager.instance.AddScore(score);
        ready = false;
        BlockState = state;
        BlockManager.instance.AddToStack(this);
        BlockManager.instance.SetSpawnLevel();
        SetColor(placedColor, colorIntensity);
        BlockManager.instance.CreateBlock();
        progressBar.gameObject.SetActive(false);
    }

    /// <summary>
    /// Calls the PlaceBlock function for a weakened block.
    /// </summary>
    private void PlaceWeakenedBlock()
    {
        PlaceBlock(1, BlockState.Weakened, blockStrength / 100f);

    }
    /// <summary>
    /// Calls the PlaceBlock function for a perfectly placed block.
    /// </summary>
    private void PlacePerfectBlock()
    {
        PlaceBlock(2, BlockState.Placed, 1f);
    }



    private void DoPopup()
    {
        if (popup != null)
        {
            if(blockStrength == 100)
            {
                popup.CreatePopUp("Perfect", new Color(1,0.75f,0));
            }
            else if (blockStrength < 100 && blockStrength >= 75)
            {
                popup.CreatePopUp("Great", Color.green);
            }
            else if (blockStrength < 75 && blockStrength >= 50)
            {
                popup.CreatePopUp("Good", Color.blue);
            }
            else if (blockStrength < 50 && blockStrength >= 25)
            {
                popup.CreatePopUp("Okay", new Color(1f, 0.5f, 0f));
            }
            else if (blockStrength < 25)
            {

                popup.CreatePopUp("Needs Work", Color.red);
            }



        }
    }

    /// <summary>
    /// Activates the Block when the player holds it for the required time.
    /// </summary>
    private void ActivateBlock()
    {

        Debug.Log("Activated");	
        SetColor(activeColor, 1f);
    }



    /// <summary>
    /// Breaks the Block when the player holds it for too long.
    /// </summary>
    public void BreakBlock(bool fromWeakened = false)
    {
        SetColor(brokenColor, 1f);
        BlockState = BlockState.Broken;
        BlockManager.instance.RemoveFromStack(this);
        if (!fromWeakened)
        {
            BlockManager.instance.SetSpawnLevel();
            BlockManager.instance.CreateBlock();
            StrikeManager.instance.AddStrike();
        }
        Destroy(gameObject,0.25f);
    }

    /// <summary>
    /// Changes the color and the progressbar based on how long the player has been holding the Block. will be changed to a better indicator in the future.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="affectSprite">Whether to change the sprite color or just the progress bar</param>
    private void ProgressBar(float value, bool affectSprite = true)
    {
        if (progressBar.gameObject.activeSelf)
        {
            progressBar.fillAmount = value;
            blockStrength = (int)(value * 100);
            strengthtext.text = value.ToString("P0");
            if (value == 0f)
            {
                progressBar.color = Color.white;
                finished = false;
            }
            else if (value == 1f)
            {
                progressBar.color = Color.green;
                finished = true;


            }

        }

        if (affectSprite)
        {
            SetColor(spriteRenderer.color, value);
        }

    }
    private IEnumerator MoveBlock()
    {
        Vector2 target = new Vector2(1.75f, transform.position.y);
        BlockState = BlockState.Moving;
        while (BlockState == BlockState.Moving)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 2f * Time.deltaTime);
            if (transform.position.x >= 1.75)
            {
                target = new Vector2(-1.75f, transform.position.y);
            }
            else if (transform.position.x <= -1.75)
            {
                target = new Vector2(1.75f, transform.position.y);

            }
            yield return null;
        }
    }


    /// <summary>
    /// Changes the color of the Block.
    /// </summary>
    /// <param name="color">The RGB Color</param>
    /// <param name="alpha">The new transparency</param>
    private void SetColor(Color color, float alpha,bool background = false)
    {
        color.a = alpha;
        if (background)
        {
            backgroundSprite.color = color;
        }
        else
        {
            spriteRenderer.color = color;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") && BlockManager.instance.GetStackSize() > 0)
        {

            BreakBlock();
        }
        if (collision.gameObject.CompareTag("Block") && BlockState == BlockState.Weakened && collision.gameObject.GetComponent<Block>().BlockState != BlockState.Broken)
        {
          HandleRandomBreak();
        }

    }

    private void HandleRandomBreak()
    {
        int random = Random.Range(0, 100);
        if (random >= blockStrength)
        {
            BreakBlock(true);
        }
        Debug.Log(random +  " " + blockStrength);
        
    }
}

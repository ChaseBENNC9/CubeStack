using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Base class for all powerups
/// </summary>
public abstract class Powerup : MonoBehaviour
{
    public float cooldown; //cooldown time in seconds
    public Image foreGroundIcon;
    public Image backgroundIcon;
    public Image bannedOverlay;
    public Image counterIcon;
    public int count; //number of uses available
    public bool inUse = false;
    public PowerupTypes powerupType;




    /// <summary>
    /// Updates the button UI
    /// </summary>
    public virtual void UpdateButton()
    {
                counterIcon.gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = count.ToString();
        if(PowerupRequirements())
        {
                bannedOverlay.gameObject.SetActive(false);
            if (count > 0)
            {
                GetComponent<Button>().interactable = true;

            }
            else
            {
                GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            GetComponent<Button>().interactable = false;
            bannedOverlay.gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// Activates the powerup functionality varies by powerup
    /// </summary>
    protected abstract void ActivatePowerup();
    /// <summary>
    /// Checks if the powerup can be used varies by powerup
    /// </summary>
    protected abstract bool PowerupRequirements();

    /// <summary>
    /// Called when the powerup button is pressed
    /// </summary>
    public virtual void PowerupPressed()
    {
        if (!inUse && count > 0 )
        {
            ActivatePowerup();
            count--;
        }
    }

    /// <summary>
    /// Begins the cooldown animation
    /// </summary>
    protected void BeginCooldown()
    {
        foreGroundIcon.fillAmount = 0;
        inUse = true;
        StartCoroutine(CooldownAnimation());
    }

    /// <summary>
    /// Cooldown animation circle fiils up over time
    private IEnumerator CooldownAnimation()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < cooldown)
        {
            foreGroundIcon.fillAmount = elapsedTime / cooldown;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        foreGroundIcon.fillAmount = 1;
        inUse = false;
    }




}

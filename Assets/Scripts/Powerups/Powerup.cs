using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Base class for all powerups
/// </summary>
public abstract class Powerup : MonoBehaviour
{
    public float cooldown;
    public Image foreGroundIcon;
    public Image backgroundIcon;
    public Image bannedOverlay;
    public bool inUse = false;
    public PowerupTypes powerupType;



    public virtual void UpdateButton()
    {
        if(PowerupRequirements())
        {
            GetComponent<Button>().interactable = true;
            bannedOverlay.gameObject.SetActive(false);
        }
        else
        {
            GetComponent<Button>().interactable = false;
            bannedOverlay.gameObject.SetActive(true);
        }
    }
    protected abstract void ActivatePowerup();
    protected abstract bool PowerupRequirements();

    public void PowerupPressed()
    {
        if (!inUse)
        {
            ActivatePowerup();
        }
    }

    protected void BeginCooldown()
    {
        foreGroundIcon.fillAmount = 0;
        inUse = true;
        StartCoroutine(CooldownAnimation());
    }

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

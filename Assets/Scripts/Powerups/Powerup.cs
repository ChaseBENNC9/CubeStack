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
    public float cooldown;
    public Image foreGroundIcon;
    public Image backgroundIcon;
    public Image bannedOverlay;
    public Image counterIcon;
    public int count;
    public bool inUse = false;
    public PowerupTypes powerupType;




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
    protected abstract void ActivatePowerup();
    protected abstract bool PowerupRequirements();

    public void PowerupPressed()
    {
        if (!inUse && count > 0 )
        {
            ActivatePowerup();
            count--;
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

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
    public bool usable = true;
    public bool active = false;
    public PowerupTypes powerupType;



    public abstract void UpdateButton();
    protected abstract void ActivatePowerup();

    public void PowerupPressed()
    {
        if (usable)
        {
            ActivatePowerup();
        }
    }

    protected void BeginCooldown()
    {
        foreGroundIcon.fillAmount = 0;
        usable = false;
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
        usable = true;
    }




}

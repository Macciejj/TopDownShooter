using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAmmo : MonoBehaviour
{
    [SerializeField] Text bullletsText;
    [SerializeField] Text AmmoText;
    private PlayerCombat playerCombat;
    
    private void Start()
    {
        playerCombat = FindObjectOfType<PlayerCombat>();
        playerCombat.AmmoAndBulletsChanged += UpdateText;
    }

    public void UpdateText(Weapon weapon)
    {
        if (weapon is Granade)
        {
            Granade weaponRange = weapon as Granade;
            bullletsText.text = weaponRange.CurrentBullets.ToString();
            AmmoText.text = "-";
            return;
        }
        if (weapon is WeaponRange)
        {
            WeaponRange weaponRange = weapon as WeaponRange;
            bullletsText.text = weaponRange.CurrentBullets.ToString();
            AmmoText.text = weaponRange.CurrentMagazines.ToString();
            return;
        } 
        else if(weapon is WeaponMelee)
        {
            bullletsText.text = "-";
            AmmoText.text = "-";
        }
    }
}

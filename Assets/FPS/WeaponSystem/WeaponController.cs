using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Weapon currentWeapon;

    List<Weapon> weapons;

    [SerializeField]
    private GameObject ReloadCrosshair;

    [SerializeField]
    private GameObject NormalCrosshair;


    // Start is called before the first frame update
    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>(true).ToList();
        ChangeWeapon();
    }

    public void ChangeWeapon()
    {
        if (currentWeapon != null)
        {
            currentWeapon.PossibleToAttackChanged -= OnPossibleToAttackChanged;
        }

        currentWeapon = weapons[0];
        currentWeapon.PossibleToAttackChanged += OnPossibleToAttackChanged;
    }

    // TODO: Pøiøadit reference na canvas a vyvolat události v ranged weapon!

    private void OnPossibleToAttackChanged(bool isPossibleToAttack)
    {
        NormalCrosshair.SetActive(isPossibleToAttack);
        ReloadCrosshair.SetActive(!isPossibleToAttack);
    }

    // Update is called once per frame
    void Update()
    {/*
        if(currentWeapon.UsesControl("Fire1"))
        {
            currentWeapon.Attack();
        }*/
    }
}

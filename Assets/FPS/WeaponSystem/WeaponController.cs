using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    Weapon currentWeapon;

    List<Weapon> weapons;

    [SerializeField]
    private GameObject ReloadCrosshair;

    [SerializeField]
    private GameObject NormalCrosshair;

    [SerializeField]
    private Image reloadImage;

    [SerializeField]
    private Grenade grenadePrefab;
    [SerializeField]
    private Transform grenadeThrowPosition;
    [SerializeField]
    private Transform cameraRef;


    // Start is called before the first frame update
    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>(true).ToList();
        ChangeWeapon(weapons.First());
    }

    public void ChangeWeapon(Weapon weapon)
    {
        if (currentWeapon != null)
        {
            if (currentWeapon.IsReloading())
                currentWeapon.ResetReload();
            currentWeapon.gameObject.SetActive(false);
            currentWeapon.PossibleToAttackChanged -= OnPossibleToAttackChanged;
        }

        currentWeapon = weapon;
        currentWeapon.gameObject.SetActive(true);
        currentWeapon.PossibleToAttackChanged += OnPossibleToAttackChanged;
        
        OnPossibleToAttackChanged(!currentWeapon.IsReloading());
        Debug.Log("Current weapon is" + currentWeapon);
    }

    private void OnPossibleToAttackChanged(bool isPossibleToAttack)
    {
        NormalCrosshair.SetActive(isPossibleToAttack);
        ReloadCrosshair.SetActive(!isPossibleToAttack);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWeapon.UsesControl("Fire1"))
        {
            currentWeapon.Attack();
        }

        if (currentWeapon.IsReloading())
        {
            reloadImage.fillAmount = currentWeapon.GetReloadProgress();
        }

        if (Input.GetKey(KeyCode.G))
        {
            ThrowGrenade();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeWeapon(weapons.ElementAt(0));
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeWeapon(weapons.ElementAt(1));
        if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeWeapon(weapons.ElementAt(2));
    }

    private void ThrowGrenade()
    {
        var g = Instantiate(grenadePrefab, grenadeThrowPosition.position, grenadeThrowPosition.rotation);
        var rb = g.GetComponent<Rigidbody>();
        g.transform.Rotate(Vector3.right, 45, Space.Self);
        rb.AddForce(grenadeThrowPosition.transform.forward * 10, ForceMode.Impulse);
    }

}

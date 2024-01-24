using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]       //gpt pasiulymo editorius neatvaizduoja tai jis pasiule sita inicijuot kad matytusi editoriuje ir lengvai galeciau idet ginklus
public class WeaponArray
{
    public GameObject[] weapons;        //scuffed
}

public interface IWeapon {
    void Shoot();
    void Cleanup();
}

public class WeaponManager : MonoBehaviour {
    [Header("Weapon List")]
    public List<WeaponArray> weaponArrays = new List<WeaponArray>();        //gpt pasiule dviguba masyva cia kazkodel daryt
    // manau galima buvo tiesiog public GameObject[] weaponArray daryt

    private int curWeaponIndex = 0;
    private IWeapon[] curWeapon;

    void Start() {
        if (weaponArrays.Count > 0) {
            // Initialize with the first weapon array
            SwitchWeaponArray(0);
        } else {
            Debug.LogError("No weapon arrays assigned to WeaponManager.");
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            CycleWeaponArrays();
        }

        if (Input.GetButtonDown("Fire1") && curWeapon != null) {
            foreach (var weapon in curWeapon)
            {
                weapon.Shoot();
            }
        }
    }

    void SwitchWeaponArray(int newIndex) {
        if (newIndex >= 0 && newIndex < weaponArrays.Count)
        {
            curWeaponIndex = newIndex;

            // Retrieve and initialize the weapons from the current array
            GameObject[] curArray = weaponArrays[curWeaponIndex].weapons;
            curWeapon = new IWeapon[curArray.Length];

            for (int i = 0; i < curArray.Length; i++)
            {
                curWeapon[i] = curArray[i].GetComponent<IWeapon>();
            }
        } else {
            Debug.LogError("Invalid weapon array index.");
        }
    }

    void CycleWeaponArrays() {
        int newIndex = (curWeaponIndex + 1) % weaponArrays.Count;
        SwitchWeaponArray(newIndex);
    }

    void SwitchWeapon(int weaponIndex)
    {
        if (curWeapon != null && weaponIndex >= 0 && weaponIndex < curWeapon.Length) {
            Debug.Log("Switching to weapon " + weaponIndex);
        } else {
            Debug.LogError("Invalid weapon index.");
        }
    }
}


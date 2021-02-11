using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShootHandler : MonoBehaviour, IPointerDownHandler
{
    internal bool shootButtonClicked;
    [SerializeField] private Slider lasersCountSlider, bigBlastSlider;
    [SerializeField] private GameObject greenShell, redShell;


    public void OnPointerDown(PointerEventData eventData)
    {
        if (PermanentFunctions.instance.canShootBigBlast == true)
        {
            GameObject bigBlastObj = ObjectPooler.current.GetPooledBigBlastObject();
            if (bigBlastObj == null)
            {
                return;
            }

            bigBlastObj.transform.position = ObjectPooler.current.firePositionObject.transform.position;
            bigBlastObj.transform.rotation = ObjectPooler.current.firePositionObject.transform.rotation;
            bigBlastObj.SetActive(true);

            PermanentFunctions.instance.laserBigBlastCount--;
            bigBlastSlider.value = PermanentFunctions.instance.laserBigBlastCount;
            redShell.SetActive(false);
            if (PermanentFunctions.instance.laserCount > 0)
            {
                PermanentFunctions.instance.canShoot = true;
            }

        }

        else if (PermanentFunctions.instance.canShoot == true && PermanentFunctions.instance.canShootBigBlast == false)
        {
            GameObject laserObj = ObjectPooler.current.GetPooledLaserObject();
            if (laserObj == null)
            {
                return;
            }
           
            laserObj.transform.position = ObjectPooler.current.firePositionObject.transform.position;
            laserObj.transform.rotation = ObjectPooler.current.firePositionObject.transform.rotation;
            laserObj.SetActive(true);
            PermanentFunctions.instance.laserCount--;
            lasersCountSlider.value = PermanentFunctions.instance.laserCount;
            if (PermanentFunctions.instance.laserCount == 0)
            {
                greenShell.SetActive(false);
            }
        }

      
    }

}

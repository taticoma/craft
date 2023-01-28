using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    public GameObject objSelected = null;
    public GameObject[] slots;
    public GameObject placeToReturn;
    public GameObject particleMagic;
    public GameObject objTemp;

    public float snapSensitivity = 10f;

    public bool playParticle = false;
    public float timeToPlayParticle;

    private void Start()
    {
       
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObj();
         
        }

        if ((Input.GetMouseButton(0) && objSelected != null) && (objSelected.tag == "items" || objSelected.tag == "block"))
        {
            DragObj();
        }
        
        if (Input.GetMouseButtonUp(0) && objSelected != null && objSelected.tag == "items")
        {
            DropObj();
        }

        if (Input.GetMouseButtonUp(0) && objSelected != null && objSelected.tag == "block")
        {
            DropBlock();
        }
        //

        if (timeToPlayParticle >= 0)
         {
            timeToPlayParticle -= Time.deltaTime;
            particleMagic.SetActive(true);
            particleMagic.GetComponent<ParticleSystem>().Play(true);
           

        } else
         {
            playParticle = false;
            particleMagic.SetActive(false);
            particleMagic.GetComponent<ParticleSystem>().Stop(true);

            if (objTemp != null)
            {
                objTemp.GetComponent<Rigidbody2D>().simulated = true;
                objTemp = null;
            }
        }
      
    }

    void CheckHitObj()
    {
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));


        if (hit.collider != null )
        {
            objSelected = hit.transform.gameObject;

        }
        
    }

    void DragObj()
    {
        objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
       
    }

    void DropObj()
    {
        Rigidbody2D rb = objSelected.GetComponent<Rigidbody2D>();
      
        rb.simulated = true;

        foreach (var slot in slots) 
        {
            if (Vector2.Distance(slot.transform.position, objSelected.transform.position) < snapSensitivity)
            {
                var slotSlot = slot.GetComponent<Slot>();
                if (slotSlot.item == null)
                {
                    slotSlot.item = objSelected;
                    rb.simulated = false;
                    objSelected.transform.position = new Vector3(slot.transform.position.x, slot.transform.position.y, slot.transform.position.z);

                    objSelected = null;
                    return;
                } else
                {
                    slotSlot.item.transform.position = placeToReturn.transform.position;
                    slotSlot.item.GetComponent<Rigidbody2D>().simulated = true;

                    slotSlot.item = objSelected;
                    rb.simulated = false;
                    objSelected.transform.position = new Vector3(slot.transform.position.x, slot.transform.position.y, slot.transform.position.z);

                    objSelected = null;
                    return;

                }
            }   
        
         }
 
        particleMagic.transform.position = objSelected.transform.position;
        playParticle = true;
        timeToPlayParticle = 0.3f;
        objSelected.GetComponent<Rigidbody2D>().simulated = false;

        objSelected.transform.position = placeToReturn.transform.position;

        objTemp = objSelected;
        objSelected = null;       
    }

    void DropBlock()
    {
        var pos = objSelected.transform.position;
        pos.z = 0;
        objSelected.transform.position = pos;

        objSelected = null; 
    }

}

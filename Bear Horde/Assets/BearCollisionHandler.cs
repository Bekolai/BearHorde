using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearCollisionHandler : MonoBehaviour
{
    MovementController movementController;
    void Awake()
    {
        movementController = GetComponent<MovementController>();
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("ChangeSize"))
        {
                IncDecSize incDecSize = other.gameObject.GetComponent<IncDecSize>();
                switch (incDecSize.getChangeType())
                {
                    case "Increase": MinionController.Instance.IncreaseMinion(incDecSize.getChangeNumber()); break;
                    case "Decrease": MinionController.Instance.DecreaseMinion(incDecSize.getChangeNumber()); break;
                    case "Multiple": MinionController.Instance.MultipleMinion(incDecSize.getChangeNumber()); break;
                    case "Divison":  MinionController.Instance.DivisonMinion(incDecSize.getChangeNumber()); break;

                }
            Destroy(other.gameObject);
       }
        if (other.CompareTag("ColorChanger"))
        {
            ColorChanger colorChanger = other.gameObject.GetComponent<ColorChanger>();
            MinionController.Instance.changeColor(colorChanger.set_BearColor);
        }
        if (other.CompareTag("Collider"))
        {
            movementController.StopMovement();
            MinionController.Instance.removeMinion(gameObject);
        }
        if (other.CompareTag("Push"))
        {
            
            PushMinion pushMinion = other.gameObject.GetComponent<PushMinion>();
            movementController.StopMovement();
            transform.position = new Vector3(other.transform.position.x,transform.position.y,transform.position.z);
            if(pushMinion.MinionColor==MinionController.Instance.currentColor())
            {
                movementController.StartVerticalMovement();
                pushMinion.sameColorPush();
                StartCoroutine(movementReset());
            }
            else
            {
                if(pushMinion.MinionCount()>=MinionController.Instance.Minions.Count)
                {
                 pushMinion.differentColorPush();
                }
                else
                {
                StartCoroutine(startVertical());
                pushMinion.differentColorPush();
                }
            

            }
        }

    }
    IEnumerator movementReset()
    {
        yield return new WaitForSeconds(1f);
        movementController.StartMovement();
    }
    IEnumerator startVertical()
    {
        yield return new WaitForSeconds(1f);
        movementController.StartVerticalMovement();
        yield return new WaitForSeconds(1f);
        movementController.StartMovement();
    }


}

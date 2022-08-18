using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
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
       }

     }
    
}

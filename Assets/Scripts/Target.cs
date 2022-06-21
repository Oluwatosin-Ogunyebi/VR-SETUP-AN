using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Target : MonoBehaviour
{
    public Collider targetAreaCollider;
    public GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var objectCollidedWith = collision.gameObject.GetComponent<XRGrabInteractable>();

        if (objectCollidedWith != null && GameManager.Instance.checkIsGameRunning())
        {
            Destroy(collision.gameObject);
            ChangeTargetPosition(targetAreaCollider);

            GameManager.Instance.AddScore();
            GameManager.Instance.SpawnFoodItem();
        }
    }
        
    private void  ChangeTargetPosition(Collider targetArea)
    {
        float x = Random.Range(targetArea.bounds.min.x, targetArea.bounds.max.x);
        float y = Random.Range(targetArea.bounds.min.y, targetArea.bounds.max.y);
        float z = Random.Range(targetArea.bounds.min.z, targetArea.bounds.max.z);

        transform.position = new Vector3(x, y, z);
    }
}

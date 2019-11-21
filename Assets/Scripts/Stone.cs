using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] float minPositionY;
    [SerializeField] float maxPositionY;

    private void Start()
    {
        ChangeHeight();
    }

    public void ChangeHeight()
    {
        float positionY = Random.Range(minPositionY,maxPositionY);
        transform.localPosition = new Vector3(transform.localPosition.x, positionY, transform.localPosition.z);
    }
}

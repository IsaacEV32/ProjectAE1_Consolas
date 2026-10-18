using System.Collections;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    Vector3 startPoint;
    [SerializeField] Vector3 endPoint;

    [SerializeField] float platformSpeed = 2;
    [SerializeField] float delaySeconds = 1;

    [SerializeField] Collider walkableCollider;
    IEnumerator Start()
    {
        startPoint = transform.position;
        while (true)
        {
            yield return StartMoveLoop(transform, endPoint, platformSpeed);

            yield return new WaitForSeconds(delaySeconds);

            yield return StartMoveLoop(transform, startPoint, platformSpeed);

            yield return new WaitForSeconds(delaySeconds);
        }
    }
    private IEnumerator StartMoveLoop(Transform platformPosition, Vector3 target, float _platformSpeed)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(platformPosition.position, target, _platformSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = target;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController player) 
            && this.gameObject.GetComponent<Collider>() == walkableCollider)
        {
            player.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerController player)
            && this.gameObject.GetComponent<Collider>() == walkableCollider)
        {
            player.transform.SetParent(null);
        }
    }
}

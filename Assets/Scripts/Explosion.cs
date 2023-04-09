
using System.Collections;
using UnityEngine;

internal class Explosion : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private void Awake()
    {
        StartCoroutine(WaitDestroy());
    }

    private IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
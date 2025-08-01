using System.Collections;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeOfDestroy;
    [SerializeField] private float _speed;
    
    private void Start() => StartCoroutine(nameof(Enumerator));
    private void Update()
    {
        transform.position += -transform.right * _speed * Time.deltaTime;
    }

    private IEnumerator Enumerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeOfDestroy);
            DestroyBullet();
        }
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public class Factory : PlaceholderFactory<Bullet> { }

}

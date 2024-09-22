using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _projectileSpawnPlace;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private Transform _spoonTransform;
    [SerializeField] private float _reloadTime = 2f;
    [SerializeField] private float _spring = 500f;

    private Quaternion _spoonLoadState;

    public void Shoot()
    {
        _spoonTransform.GetComponent<Rigidbody>().WakeUp();
        _springJoint.spring = _spring;
    }

    public void Reload()
    {
        _springJoint.spring = 0;

        StartCoroutine(Reloading());
    }

    private IEnumerator Reloading()
    {
        Quaternion startRotation = _spoonTransform.rotation;
        Quaternion targetRotation = Quaternion.FromToRotation(_spoonTransform.forward, Vector3.up);
        float time = 0;

        while (_spoonTransform.rotation != targetRotation)
        {
            time += Time.deltaTime;
            _spoonTransform.rotation = 
                Quaternion.Lerp(startRotation, targetRotation, time / _reloadTime);

            yield return null;
        }

        Instantiate(_projectile, _projectileSpawnPlace.position, Quaternion.identity);
    }
}

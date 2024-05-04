using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    FollowPlayer[] followPlayer;
    public GameObject bulletPrefab;
    public bool canProjectile;
    Transform target;
    Transform baseTarget;
    Vector3 direction;
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (canProjectile)
        {
            if (other.gameObject.tag == "Player")
            {
                print("Hey");
                followPlayer = FindObjectsOfType<FollowPlayer>();
                int counter = FindObjectsOfType<FollowPlayer>().Length;
                int i = 0;
                while (counter > 0)
                {
                    direction = (followPlayer[i].transform.position - transform.position).normalized;
                    
                    GameObject bullet = Instantiate(bulletPrefab, other.transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                    StartCoroutine(Projectile(bullet, followPlayer[i].transform.position, direction));
                    i++;
                    counter--;

                }

            }
        }

    }

    IEnumerator Projectile(GameObject bullet, Vector3 target,Vector3 distance)
    {
        while(Vector3.Distance(bullet.transform.position, target) > .5f)
        {
            bullet.transform.position += distance * 45f * Time.deltaTime;
            bullet.transform.LookAt(target);
            yield return null;
        }
        Destroy(bullet,1);
        

    }
}

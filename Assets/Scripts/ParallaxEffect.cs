using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam; // ambil obj cam
    public Transform player;
    Vector2 startPosition;
    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosition; //ini buat tau seberapa jauh cameranya udah gerak dari start
    float distanceFromPlayer => transform.position.z - player.position.z; //ini buat tau jarak player
    float clippingPlane => (cam.transform.position.z + (distanceFromPlayer > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(distanceFromPlayer) / clippingPlane;

    public void Start(){
        startPosition = transform.position; // ini buat ambil position awal
        startZ = transform.position.z; // ambil position buat znya

    }

    public void Update(){
        Vector2 newPos = startPosition + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }
}

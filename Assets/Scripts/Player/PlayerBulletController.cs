using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public enum DirectionForBulletSpawn
    {
        Up,
        Down,
        Left,
        Right
    }
    public class PlayerBulletController : MonoBehaviour
    {
        [SerializeField] private float speed;
        Rigidbody2D rb;
        [SerializeField] private DirectionForBulletSpawn directionForBulletSpawn;

        public Vector3 DirectionToMove
        {
            get
            {
                switch (directionForBulletSpawn)
                {
                    case DirectionForBulletSpawn.Up:
                        return Vector2.up;
                    case DirectionForBulletSpawn.Down:
                        return Vector2.down;
                    case DirectionForBulletSpawn.Left:
                        return Vector2.left;
                    case DirectionForBulletSpawn.Right:
                        return Vector2.right;

                    default:
                        return Vector2.zero;
                }
            }
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            rb.velocity = DirectionToMove * Time.fixedDeltaTime * speed;
        }
    }
}
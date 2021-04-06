using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathClasses;

namespace Project2D
{
    class Player : GameObject
    {
        Turret turret = null;
        Vector2 objectVelocity;

        public Player(string fileName) : base(fileName)
        {
            LocalTransform.m[6] = 640;
            LocalTransform.m[7] = 480;
            turret = new Turret("../Images/turret.png");
            turret.SetParent(this);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            float Speed = 100f;
            Vector2 force = new Vector2();
            float rotation = 0;
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                
                force.y = -Speed;
            }

            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                
                force.y = +Speed;
            }

            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                rotation = 1 * deltaTime;
                
            }

            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                rotation = -1 * deltaTime;
                 
            }
            objectVelocity += force * deltaTime;

            Vector2 displacement;
            displacement.x = objectVelocity.x * deltaTime;
            displacement.y = objectVelocity.y * deltaTime;

            Matrix3 translation = new Matrix3(true);
            translation.m[6] = displacement.x;
            translation.m[7] = displacement.y;

            LocalTransform *= translation;
            Matrix3 rotationMatrix = new Matrix3(true);
            rotationMatrix.SetRotateZ(rotation);
            LocalTransform *= rotationMatrix;


        }
        public override void OnCollision()
        {
            LocalTransform.m[6] = LastSafe.x;
            LocalTransform.m[7] = LastSafe.y;
            UpdateTransforms();
            objectVelocity.x = 0;
            objectVelocity.y = 0;

        }
    }
}

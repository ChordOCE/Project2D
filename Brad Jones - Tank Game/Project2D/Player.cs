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

        //setting the position that the tank will start in
        //and rendering the turret and adding player as the parent to turret
        public Player(string fileName) : base(fileName)
        {
            LocalTransform.m[6] = 640;
            LocalTransform.m[7] = 480;
            turret = new Turret("../Images/turret.png");
            turret.SetParent(this);
        }

        //update function for movement
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            float Speed = 400f;
            float drag = 1f;
            Vector2 force = objectVelocity * -drag;
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

            if (IsKeyDown(KeyboardKey.KEY_R))
            {
                ResetPos();
            }
            objectVelocity += force * deltaTime;

            //tank speeds up depending on how long the key is pressed down
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
            objectVelocity.x *= -0.5f;
            objectVelocity.y *= -0.5f;
        }

        public void ResetPos()
        {
            LocalTransform.m[6] = 640;
            LocalTransform.m[7] = 400;
            objectVelocity.x = 0;
            objectVelocity.y = 0;
        }
    }
}

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
            Vector2 objectVelocity;
        public Player(string fileName) : base(fileName)
        {
            LocalTransform.m[6] = 300;
            LocalTransform.m[7] = 300;

        }

        public override void Update(float deltaTime)
        {
            float Speed = 100f;
            Vector2 force = new Vector2();
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                force.x = 0f;
                force.y = -Speed;
            }

            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                force.x = 0f;
                force.y = +Speed;
            }

            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                force.x = -Speed;
                force.y = 0f;
            }

            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                force.x = +Speed;
                force.y = 0f;
            }
            objectVelocity += force * deltaTime;

                Vector2 displacement;
                displacement.x = objectVelocity.x * deltaTime;
                displacement.y = objectVelocity.y * deltaTime;

                Matrix3 translation = new Matrix3(true);
                translation.m[6] = displacement.x;
                translation.m[7] = displacement.y;

                LocalTransform *= translation;
            
        }
    }
}

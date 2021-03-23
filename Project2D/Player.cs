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
        Image logo;
        Texture2D texture;
        public override void Update()
        {
            
            float Speed = 10f;
            Vector2 objectPos;
            objectPos.x = 0;
            objectPos.y = 0;
            Vector2 objectVelocity;
            objectVelocity.x = 0;
            objectVelocity.y = 0;
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                Vector2 force;
                force.x = 0f;
                force.y = -Speed;

                objectVelocity.x += force.x * deltaTime;
                objectVelocity.y *= objectVelocity.y * force.y;

                Vector2 displacement;
                displacement.x = objectVelocity.x * deltaTime;
                displacement.y = objectVelocity.y * deltaTime;


                objectPos.x += displacement.x;
                objectPos.y += displacement.y;

            }
        }
    }
}


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
    class Turret : GameObject
    {
        public Turret(string fileName) : base(fileName)
        {
            LocalTransform.m[6] = 0;
            LocalTransform.m[7] = 0;
            EnableCollision = false;
        }

        public override void Update(float deltaTime)
        {
            float rotation = 0;

            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                rotation = 1 * deltaTime;

            }

            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                rotation = -1 * deltaTime;

            }

            Matrix3 rotationMatrix = new Matrix3(true);
            rotationMatrix.SetRotateZ(rotation);
            LocalTransform *= rotationMatrix;
        }
    }
}

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
        public float rotation = 0;
        //turret position set to zero because it follows the main body of the tank
        public Turret(string fileName) : base(fileName)
        {
            LocalTransform.m[6] = 0;
            LocalTransform.m[7] = 0;
            EnableCollision = false;
        }

        public void ResetRotation(float deltaTime)
        {
            rotation = 0 * deltaTime;
        }
        //update function for the turret so that it can rotate
        public override void Update(float deltaTime)
        {

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

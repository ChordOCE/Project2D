using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClasses;

namespace Project2D
{
    class Crate : GameObject
    {
        //crate position and adding it to collision manager
        public Crate(string fileName, Vector2 Position) : base(fileName)
        {
            LocalTransform.m[6] = Position.x;
            LocalTransform.m[7] = Position.y;
            CollisionManager.AddObject(this);
        }

        public override void Update(float deltaTime)
        {

        }

    }
}

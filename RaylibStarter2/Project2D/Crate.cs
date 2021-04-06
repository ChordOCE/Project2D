using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    class Crate : GameObject
    {
        //crate position and adding it to collision manager
        public Crate(string fileName) : base(fileName)
        {
            LocalTransform.m[6] = 1000;
            LocalTransform.m[7] = 700;
            CollisionManager.AddObject(this);
        }

        public override void Update(float deltaTime)
        {

        }
    }
}

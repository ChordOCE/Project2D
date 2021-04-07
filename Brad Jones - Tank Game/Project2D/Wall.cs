using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClasses;

namespace Project2D
{
    class Wall : GameObject
    {
        public Wall(string fileName, float width, float height, Vector2 pos) : base(fileName)
        {
            objMin.x = - width /2;
            objMin.y = - height /2;
            objMax.x = width /2;
            objMax.y = height /2;
            LocalTransform.m[6] = pos.x;
            LocalTransform.m[7] = pos.y;
            CollisionManager.AddObject(this);
        }
    }
}

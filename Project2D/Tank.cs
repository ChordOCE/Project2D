using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    class Tank
    {
        public override void OnCollision()
        {
            Vector2 v2Normal = OtherObj.GetPosition() - GetPosition();
            v2Normal.Normalize();

            Vector2 reflection = 2.0f * 2Velocity.Dot(v2Normal) * v2Normal * Velocity;

            2Velocity = reflection;
        }
    }
}

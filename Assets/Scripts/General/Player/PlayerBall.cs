using System;

namespace General
{
    public class PlayerBall: Player
    {
        private void FixedUpdate()
        {
            Move();
        }
    }
}
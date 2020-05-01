using System;
using System.Collections.Generic;
using System.Text;

namespace Felli
{
    public struct Position
    {
        private byte X { get; }
        private byte Y { get; }

        public Position(byte x = 0, byte y = 0)
        {
            X = x;
            Y = y;
        }
    }
}

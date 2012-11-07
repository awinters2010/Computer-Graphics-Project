using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.DirectInput;

namespace Graphics
{
    public static class Input
    {
        private static DirectInput input;
        private static Keyboard keyBoard;
        private static Mouse mouse;

        public static void Initialize()
        {
            input = new DirectInput();
            keyBoard = new Keyboard(input);
            keyBoard.Acquire();
            mouse = new Mouse(input);
            mouse.Acquire();
        }
    }
}

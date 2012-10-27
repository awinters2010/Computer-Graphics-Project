using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.DirectInput;

namespace Graphics
{
    public static class Input
    {
        DirectInput input;
        static Keyboard keyBoard;
        Mouse mouse;

        public Input()
        {
            input = new DirectInput();
            keyBoard = new Keyboard(input);
        }

        public static bool KeyPress()
        {
            if (keyBoard.)
            {
                
            }
        }
    }
}

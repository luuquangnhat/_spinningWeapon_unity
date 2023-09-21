using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Singleton
{
    internal class CharacterMovement
    {
        private static CharacterMovement _instance;

        protected CharacterMovement() {
            input.CharacterControls.Enable();
        }
        public PlayerInput input;
        public static CharacterMovement Instance()
        {
            if (_instance == null)
            {
                _instance = new CharacterMovement();
            }
            return _instance;
        }
    }
}

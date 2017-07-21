using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HearthstoneHotkeys
{
    public class Hotkey
    {
        public Keys Key { get; set; }

        public Keys KeyModifier { get; set; }

        public IAction Action { get; set; }

        public Hotkey(Keys key, Keys keyModifier, IAction action)
        {
            if (keyModifier != Keys.None &&
                keyModifier != Keys.ControlKey &&
                keyModifier != Keys.ShiftKey &&
                keyModifier != Keys.Alt)
            {
                throw new Exception("KeyModifier musí být Ctrl, Shift nebo Alt");
            }

            Key = key;
            KeyModifier = keyModifier;
            Action = action;

            string hotkeyText = (KeyModifier != Keys.None) ? Enum.GetName(typeof(Keys), KeyModifier).ToString() + " + " : "";
            hotkeyText += Enum.GetName(typeof(Keys), Key).ToString();
            Console.WriteLine("{0,22} - {1}", hotkeyText, Action.GetDescription());
        }

        public virtual void Execute()
        {
            if (Action != null)
            {
                Action.Execute();
            }
        }

        public virtual bool CanExecute()
        {
            bool modifier = true;
            if (KeyModifier != Keys.None)
            {
                modifier = Keyboard.CheckDown(KeyModifier);
            }
            return modifier && Keyboard.CheckPressed(Key);
        }
    }
}

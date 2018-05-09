using HearthstoneHotkeys.Actions;
using HearthstoneHotkeys.IO;
using System;
using System.Threading.Tasks;

namespace HearthstoneHotkeys
{
    public class Hotkey
    {
        public Hotkey(Keys keyModifier, Keys key, IAction action)
        {
            if (keyModifier != Keys.None &&
                keyModifier != Keys.ControlKey &&
                keyModifier != Keys.ShiftKey &&
                keyModifier != Keys.Alt)
            {
                throw new ArgumentException($"{nameof(keyModifier)} has to be Ctrl, Shift or Alt", nameof(keyModifier));
            }

            KeyModifier = keyModifier;
            Key = key;
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public Keys KeyModifier { get; set; }

        public Keys Key { get; set; }

        public IAction Action { get; set; }

        public async Task ExecuteAsync()
        {
            await Action?.ExecuteAsync();
        }

        public bool CanExecute()
        {
            var isKeyPressed = Keyboard.CheckPressed(Key);
            if (KeyModifier != Keys.None)
            {
                return isKeyPressed && Keyboard.CheckDown(KeyModifier);
            }
            return isKeyPressed;
        }

        public override string ToString()
        {
            var keyModifierText = (KeyModifier != Keys.None)
                ? Enum.GetName(typeof(Keys), KeyModifier) + " + "
                : "";
            var keyText = Enum.GetName(typeof(Keys), Key);

            return $"{keyModifierText + keyText} - {Action.Name}";
        }
    }
}

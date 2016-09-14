/*
 * This file is part of the project ClickMaster, licensed under the
 * Creative Commons Attribution-NoDerivatives 4.0 International license.
 * 
 * Copyright (c) 2016 Justin Vogel <dernoki77@gmail.com>
 * 
 * You should have received a copy of the license along with this
 * work. If not, see <http://creativecommons.org/licenses/by-nd/4.0/>.
 * 
 * THIS SOFTWARE IS PROVIDED UNDER THE TERMS
 * OF THIS CREATIVE COMMONS PUBLIC LICENSE ("CCPL" OR "LICENSE").
 * THE SOFTWARE IS PROTECTED BY COPYRIGHT AND/OR OTHER APPLICABLE LAW.
 * ANY USE OF THE WORK OTHER THAN AS AUTHORIZED UNDER THIS LICENSE
 * OR COPYRIGHT LAW IS PROHIBITED.
 * 
 * BY EXERCISING ANY RIGHTS TO THE SOFTWARE PROVIDED HERE,
 * YOU ACCEPT AND AGREE TO BE BOUND BY THE TERMS OF THIS LICENSE.
 * TO THE EXTENT THIS LICENSE MAY BE CONSIDERED TO BE A CONTRACT,
 * THE LICENSOR GRANTS YOU THE RIGHTS CONTAINED HERE IN CONSIDERATION
 * OF YOUR ACCEPTANCE OF SUCH TERMS AND CONDITIONS.
 */

using ClickMaster.Util;
using System.Reflection;
using System.Windows.Forms;

namespace ClickMaster {
    static class Keynames {
        public static TypedHashtable<int, string> KeyNames { get; private set; }
        public static TypedHashtable<string, int> KeyCodes { get; private set; }

        public static void InitKeynames() {
            KeyNames = new TypedHashtable<int, string>();
            KeyCodes = new TypedHashtable<string, int>();

            foreach (FieldInfo Field in typeof(Keys).GetFields()) {
                if (Field.IsStatic) {
                    KeyNames.Set((int) Field.GetValue(null), Field.Name);
                    KeyCodes.Set(Field.Name, (int) Field.GetRawConstantValue());
                }
            }
        }

        public static string GetKeyName(int KeyCode) {
            return KeyNames.Get(KeyCode);
        }

        public static int GetKeyCode(string KeyName) {
            return KeyCodes.Get(KeyName);
        }
    }
}

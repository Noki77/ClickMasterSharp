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

using System;
using System.Windows.Forms;

namespace ClickMaster.Gui.Components {
    public class ActionList : ListView {
        public int Add(Action a) {
            ListViewItem Item = new ActionItem(a);
            if (!this.Items.Contains(Item)) {
                this.Items.Add(Item);
                return this.Items.IndexOf(Item);
            }

            return -1;
        }

        public Action Get(int Index) {
            if (this.Items.Count > Index) {
                return ((ActionItem) this.Items[Index]).Parent;
            }
            return null;
        }

        public void Remove(int Index) {
            this.Items.RemoveAt(Index);
        }

        public Action[] GetAll() {
            Action[] Actions = new Action[this.Items.Count];
            for (int i = 0; i < this.Items.Count; i++) {
                Actions[i] = ((ActionItem) this.Items[i]).Parent;
            }

            return Actions;
        }
    }

    class ActionItem : ListViewItem {
        public Action Parent { get; }

        public ActionItem(Action a) {
            this.Parent = a;
            this.Text = a.ToString();
        }
    }
}

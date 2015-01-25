using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VM_FormUtils.Extensions
{
    public static class ListBoxExtentsions
    {
        /// <summary>
        /// Fills the Listbox with items from a list
        /// </summary>
        /// <param name="lstBox">The Listbox you are filling</param>
        /// <param name="list">the source list</param>
        public static void PopulateFromEnumerable(this ListBox lstBox, IEnumerable<string> list)
        {
            lstBox.BackColor = Color.LemonChiffon;
            foreach (var item in list)
            {
                lstBox.Items.Add(item);
            }
        }
    }
}

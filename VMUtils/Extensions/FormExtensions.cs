using System;
using System.Linq;
using System.Windows.Forms;

namespace VMUtils.Extensions
{
    /// <summary>
    /// Extensions for opening forms and doing a check
    /// NOTE: This has been placed here because this is shared between VM_Main & VM_ScenarioEditor
    /// </summary>
    public static class FormExtensions
    {
        /// <summary>
        /// Opens Form as an independent form and does a check if another instance of the form is already open
        /// </summary>
        /// <param name="form"></param>
        public static void OpenForm(this Form form)
        {
            if (!IsOpenAlready(form.Name))
            {
                form.TopLevel = false;
                form.Show();
            }
            
        }

        /// <summary>
        /// Opens Form as an MDI child and does a check if another instance of the form is already open
        /// </summary>
        /// <param name="form"></param>
        /// <param name="mdiParent"></param>
        public static void OpenFormInMdi(this Form form, Form mdiParent)
        {
            if (!IsOpenAlready(form.Name))
            {
                form.TopLevel = false;
                form.MdiParent = mdiParent;
                form.Show();
            }

        }

        /// <summary>
        /// Check if there is another instance of this form open already
        /// </summary>
        /// <param name="formName">The name of the form</param>
        /// <returns></returns>
        private static bool IsOpenAlready(string formName)
        {
            try
            {
                var openAlready = false;
                foreach (var frm in Application.OpenForms.Cast<Form>().Where(frm => String.Equals(frm.Name, formName, StringComparison.CurrentCultureIgnoreCase)))
                {
                    frm.BringToFront();
                    openAlready = true;
                    break;
                }
                return openAlready;
            }
            catch (Exception error)
            {
                throw;
            }
        }

    }
}

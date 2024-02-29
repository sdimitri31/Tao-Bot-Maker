using LogFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tao_Bot_Maker.Controller
{
    internal class Log
    {
        /// <summary>
        /// Write a message in debug logs if settings allows it
        /// </summary>
        /// <param name="level">LogFramework level</param>
        /// <param name="message">string containing info for debugging</param>
        public static void Write(string message, int level = LogFramework.Log.INFO) 
        { 
            if(SettingsController.IsSaveLogs())
                LogFramework.Log.Write(level, message);
        }

        public static void Write(string message, ListBox listBox, int level = LogFramework.Log.INFO, bool isthread = false, bool isTemporary = false)
        {
            DateTime dateTime = DateTime.Now;
            String log = dateTime.ToString() + " : " + message;

            if (isthread == false)
            {
                listBox.Items.Add(log);
                listBox.TopIndex = listBox.Items.Count - 1;
            }
            else
            {
                if (isTemporary)
                {
                    MethodInvoker mainthread = delegate
                    {
                        listBox.Items.RemoveAt(listBox.Items.Count - 1);
                        listBox.Items.Add(log);
                        listBox.TopIndex = listBox.Items.Count - 1;
                    };
                    listBox.BeginInvoke(mainthread);
                }
                else
                {
                    MethodInvoker mainthread = delegate
                    {
                        listBox.Items.Add(log);
                        listBox.TopIndex = listBox.Items.Count - 1;
                    };
                    listBox.BeginInvoke(mainthread);
                }
            }

            Log.Write(message, level);
        }
    }
}

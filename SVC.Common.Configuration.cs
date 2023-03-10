using System;
using System.Configuration;
using System.IO;


namespace SVC.MessageReceiver
{
    public class SVCCommon
    {
        public static string AppConfigValue(string Key)
        {
            try
            {
                return ConfigurationManager.AppSettings[Key].ToString();

            }
            catch (Exception ex)
            {
                //   LogWriter logwriter = new LogWriter("Read Configuration error:" + ex.Message);
                throw new Exception("Read Configuration Key:" + Key + " has error: " + ex.Message);
            }
        }

        public static string GetSolutionPath()
        {
            //string path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            try
            {
                string str = AppDomain.CurrentDomain.BaseDirectory.ToString();
                /*    for (int i = 0; i <= 3; i++)
                    {
                        str = str.Remove(str.LastIndexOf("\\"));
                    }  */
                //    LogWriter logwriter = new LogWriter("Application path:" + path);
                return str;
            }
            catch (Exception ex)
            {
                //   LogWriter logwriter = new LogWriter("Read Configuration error:" + ex.Message);
                throw new Exception("GetSolutionPath has error:" + ex.Message);
            }
        }

        public static string GetFullPath(String AppKeyName)
        {
            string str = "";
            try
            {
                str = GetSolutionPath().ToString() + AppConfigValue(AppKeyName).ToString();
            }
            catch (Exception ex)
            {
                //   LogWriter logwriter = new LogWriter("Read Configuration error:" + ex.Message);
                throw new Exception("GetFullPath for " + AppKeyName + " has error:" + ex.Message);
            }
            return str;
        }
    }
}

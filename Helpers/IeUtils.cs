using mshtml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommandTestAutomation.Helpers
{   
        public class Utils
        {
            //static String BaseUrl = @"http://www.1000pass.com/sites_users/extension_add";
            ////static String BaseUrl = @"http://10.0.0.53/thousandpass/sites_users/extension_add";
            ////static String BaseUrl = @"http://192.168.0.8/thousandpass/sites_users/extension_add";
            //public static String PluginFileName = @"1000pass_com_plugin.txt";
            //public static String ControlFileName = @"1000pass_com_control.txt";
            //public static String TokenFileName = @"1000pass_com_token.txt";
            public static String LogFileName = @"BetaTestLog.txt";


            public static void log(Exception e)
            {
                string log = Environment.NewLine;
                log += @"=========================================================" + Environment.NewLine;
                log += DateTime.Now + Environment.NewLine;
                log += @"=========================================================" + Environment.NewLine;
                log += e.Message + Environment.NewLine;
                log += @"=========================================================" + Environment.NewLine;
                log += e.StackTrace + Environment.NewLine;
                //Utils.l(log);
                Utils.WriteToFile(Utils.LogFileName, log);
            }


            public static string decode64(string data)
            {
                try
                {
                    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                    System.Text.Decoder utf8Decode = encoder.GetDecoder();

                    byte[] todecode_byte = Convert.FromBase64String(data);
                    int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                    char[] decoded_char = new char[charCount];
                    utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                    string result = new String(decoded_char);
                    return result;

                }
                catch (Exception e)
                {
                    throw new Exception("Error in base64Decode" + e.Message);
                }
            }


            public static void log(string msg)
            {
                System.Windows.Forms.MessageBox.Show(msg);
            }


            public static string GetDomain(String url)
            {
                Regex pattern = new Regex("(?<protocol>http(s)?|ftp)://(?<server>([A-Za-z0-9-]+\\.)*(?<basedomain>[A-Za-z0-9-]+\\.[A-Za-z0-9]+))+((:)?(?<port>[0-9]+)?(/?)(?<path>(?<dir>[A-Za-z0-9\\._\\-]+)(/){0,1}[A-Za-z0-9.-/]*)){0,1}");

                //string url = "http://my.domain.com:8000?arg1=this&arg2=that";
                System.Uri uri = new System.Uri(url);

                // get the port
                int port = uri.Port;

                // get the host name (my.domain.com)
                string host = uri.Host;

                // get the protocol
                //string protocol = uri.Scheme;

                // get everything before the query:
                //string cleanURL = uri.Scheme + "://" + uri.GetComponents(UriComponents.HostAndPort, UriFormat.UriEscaped);

                return host; //.ToLower().Replace(@"http://", "").Replace(@"https://", "");
            }

       
            public static void WriteToFile(string FileName, string line)
            {
                try
                {
                    TextWriter tw = new StreamWriter(System.IO.Path.GetTempPath() + FileName);
                    tw.WriteLine(line);
                    tw.Close();
                }
                catch (Exception e)
                {
                    Utils.log(e);
                }
            }


            public static string ReadFromFile(string FileName)
            {
                string line = "";
                try
                {
                    TextReader tr = new StreamReader(System.IO.Path.GetTempPath() + FileName);
                    line = tr.ReadLine();
                    tr.Close();
                }
                catch (Exception e)
                {
                    Utils.log(e);
                }
                return line;
            }



}//cls
}//ns

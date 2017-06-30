using mshtml;
using CommandTestAutomation.DAL;
using CommandTestAutomation.Models;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using CommandTestAutomation.Helpers;
using CommandTestAutomation.Interfaces;
using CommandTestAutomation.Enums;
using CommandTestAutomation.Models;
using CommandTestAutomation.Helpers;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;

namespace CommandTestAutomation.Helpers
{

    public class IeBrowserAutomationHelper : IBrowserAutomationHelper
    {
        static AutoResetEvent documentComplete = new AutoResetEvent(false);
        static InternetExplorer ieInstanceWebBrowser = null;
        static IHTMLDocument3 document3 = null;        
        static Process process = null;
        // tabs

        public static string LogFileName = @"BetaTestLog.txt";

        //constructor
        public IeBrowserAutomationHelper()
        {
            OpenBroswer();
        }

        //event handler
        private static void ie_DocumentComplete(object pDisp, ref object URL)
        {
            documentComplete.Set();
        }

        /// <summary>
        /// open browser and get its proccess and store it as iebrowserinstance
        /// </summary>
        /// <returns></returns>
        [STAThread]
        public StepRunStatus OpenBroswer()
        {
            try
            {

                //Console.WriteLine("\nLaunching an instance of IE");
                process = Process.Start("iexplore.exe", "-nomerge about:blank");
                process.WaitForInputIdle();
                int j = 0;
                for (int ix = 0; ix < 500; ix++)
                {
                    j = ix;
                    Thread.Sleep(1000);
                    process.Refresh();
                    if (process.MainWindowHandle != IntPtr.Zero) break;
                }
                //  MessageBox.Show(j.ToString());
                if (process == null)
                    throw new Exception("Could not launch IE");
                //MessageBox.Show("Process handle = " + p.MainWindowHandle.ToString());
                //Thread.Sleep(4000);
                SetIEInstance();
                return StepRunStatus.PASSED;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error: " + ex.Message);
            }
            return StepRunStatus.FAILED;

        }

        [ComVisible(true)]
        private InternetExplorer GetIEInstance()
        {
            return ieInstanceWebBrowser;
        }

        [ComVisible(true)]
        private InternetExplorer SetIEInstance()
        {
            ieInstanceWebBrowser = null;
            ShellWindows allBrowsers = new ShellWindows();
            //Console.WriteLine("Number active browsers = " + allBrowsers.Count);

            if (allBrowsers.Count == 0)
            {
                //MessageBox.Show(p.Handle.ToString());
                throw new Exception("Cannot find IE");
            }

            if ((int)process.MainWindowHandle == 0)
            {

                process.Refresh();
                while (!process.HasExited)
                {
                    process.Refresh();
                    if (process.MainWindowHandle.ToInt32() != 0)
                    {

                        break;
                    }
                }
            }

            // MessageBox.Show("Attaching to IE" + p.MainWindowHandle.ToInt32().ToString());

            bool success = false;
            int elapsed = 0;
            TimeSpan TimeOut = TimeSpan.FromSeconds(60);
            while ((!success) && (elapsed < TimeOut.TotalMilliseconds))
            {
                Thread.Sleep(1000);
                elapsed += 1000;


                int i = 0; // attach to correct browser
                while (i < allBrowsers.Count && ieInstanceWebBrowser == null)
                {

                    InternetExplorer e = (InternetExplorer)allBrowsers.Item(i);
                    if (e != null && Path.GetFileNameWithoutExtension(e.FullName).ToLower().Equals("iexplore") && e.HWND == (int)process.MainWindowHandle)
                    {
                        ieInstanceWebBrowser = e;
                       
                        break;
                    }
                    ++i;
                    if (process.MainWindowHandle == IntPtr.Zero && i >= allBrowsers.Count)
                    {
                        Thread.Sleep(2000);
                        i = 0;
                    }
                }
                if (ieInstanceWebBrowser != null)
                {
                    Win32ApiHelper.ShowWindow(process.MainWindowHandle);
                    break;
                }
                allBrowsers = new ShellWindows();
            }
            IntPtr[] hWnds = Win32ApiHelper.GetProcessWindows(process.Id);

            if (ieInstanceWebBrowser == null)
                throw new Exception("Failed to attach to IE");
            else
            {
                do
                {

                } while ((ieInstanceWebBrowser.Busy) || (ieInstanceWebBrowser.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE));
            }
            //ready state
            ieInstanceWebBrowser.DocumentComplete += new DWebBrowserEvents2_DocumentCompleteEventHandler(ie_DocumentComplete);
            return ieInstanceWebBrowser;
        }

        private void SetNewPageInstance(string PageName)
        {
            ieInstanceWebBrowser = null;
            ShellWindows allBrowsers = new ShellWindows();
            //Console.WriteLine("Number active browsers = " + allBrowsers.Count);

            if (allBrowsers.Count == 0)
            {
                //MessageBox.Show(p.Handle.ToString());
                throw new Exception("Cannot find IE");
            }


            bool success = false;
            int elapsed = 0;
            TimeSpan TimeOut = TimeSpan.FromSeconds(60);
            while ((!success) && (elapsed < TimeOut.TotalMilliseconds))
            {
                Thread.Sleep(1000);
                elapsed += 1000;


                int i = 0; // attach to correct browser
                while (i < allBrowsers.Count )//&& ieInstanceWebBrowser == null)
                {

                    InternetExplorer iExplorer = (InternetExplorer)allBrowsers.Item(i);
                    //System.Windows.MessageBox.Show((iExplorer.Document as mshtml.IHTMLDocument2).title);
                    //System.Windows.MessageBox.Show((iExplorer.Document as mshtml.IHTMLDocument2).location.href);
                    //System.Windows.MessageBox.Show((iExplorer.Document as mshtml.IHTMLDocument2).url);
                    if (iExplorer != null && Path.GetFileNameWithoutExtension(iExplorer.FullName).ToLower().Equals("iexplore") 
                         && (iExplorer.Document as mshtml.IHTMLDocument2).title.Equals(PageName) //&& iExplorer.HWND == (int)process.MainWindowHandle
                        )
                    {
                       // string title = "";// ((HTMLDocument)ieInstanceWebBrowser.Document).title;
                        //mshtml.IHTMLDocument2 doc = ieInstanceWebBrowser.Document as mshtml.IHTMLDocument2;
                        //title = doc.title;
                        ieInstanceWebBrowser = iExplorer;
                        break;
                    }
                    ++i;
                    if ( i >= allBrowsers.Count)
                    {
                        Thread.Sleep(2000);
                        i = 0;
                        allBrowsers = new ShellWindows();
                    }
                }//eof while

                if (ieInstanceWebBrowser != null)
                {
                    Win32ApiHelper.ShowWindow((IntPtr)ieInstanceWebBrowser.HWND);
                    break;
                }
                
            }
          //  IntPtr[] hWnds = Win32ApiHelper.GetProcessWindows(process.Id);

            if (ieInstanceWebBrowser == null)
                throw new Exception("Failed to attach to IE");
            else
            {
                do
                {

                } while ((ieInstanceWebBrowser.Busy) || (ieInstanceWebBrowser.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE));
            }
            //ready state
            ieInstanceWebBrowser.DocumentComplete += new DWebBrowserEvents2_DocumentCompleteEventHandler(ie_DocumentComplete);
           // return ieInstanceWebBrowser;
        }


        [STAThread]
        [ComVisible(true)]
        public StepRunStatus Navigate(string url)
        {
            try
            {

                //Console.WriteLine("\nNavigating to the Web app");

                object nil = new object();
                
                //InternetExplorer ieInstanceWebBrowser = GetIEInstance();
                //ieInstance.FullScreen = true;
                ieInstanceWebBrowser.Navigate(url, ref nil, ref nil, ref nil, ref nil);
                Thread.Sleep(5000);
                documentComplete.WaitOne(5000);
                ieInstanceWebBrowser = GetIEInstance();
                do
                {
                    System.Windows.Forms.Application.DoEvents();

                } while ((ieInstanceWebBrowser.Busy) || (ieInstanceWebBrowser.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE));

                //Console.WriteLine("Setting IE to size 450x360");
                //ie.Width = 450;
                //ie.Height = 360;
                //Thread.Sleep(1000);
                //document3 = (IHTMLDocument3)ieInstance.Document;
                return StepRunStatus.PASSED;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public static string GetInnerText(IHTMLDOMNode node)
        {
            IHTMLElement elem = (IHTMLElement)node;
            return elem.innerText;
        }

        public static string GetClassName(IHTMLDOMNode node)
        {
            IHTMLElement elem = (IHTMLElement)node;
            return elem.className;
        }


        public static string FindXPath(IHTMLElement node)
        {
            if (node == null)
            {
                return "";
            }

            string xpath = @"##id=" + node.id;
            try
            {
                try
                {
                    xpath += @";name=" + node.getAttribute("name").ToString();
                }
                catch (Exception e)
                {
                    xpath += @";name=";
                }
                xpath += @";class=" + node.className;

                while (node.parentElement != null)
                {
                    IHTMLElementCollection elements = (IHTMLElementCollection)node.parentElement.children;
                    int c = 1;
                    foreach (IHTMLElement child in elements)
                    {
                        if (node.Equals(child))
                        {
                            break;
                        }
                        else if (node.tagName == child.tagName)
                        {
                            c++;
                        }
                    }

                    // ie bug??
                    if (node.tagName.ToUpper() == "BODY")
                    {
                        c--;
                    }

                    if (c > 1)
                    {
                        xpath = "/" + node.tagName + "[" + c + "]" + xpath;
                    }
                    else
                    {
                        xpath = "/" + node.tagName + xpath;
                    }

                    node = node.parentElement;
                }
            }
            catch (Exception e)
            {
                Utils.log(e);
            }

            return xpath;
        }

        IHTMLElement FindElementByXPath(string xPath, HTMLDocument doc)
        {
            IHTMLElement theElement = null;
            // http://www.w3schools.com/xml/xpath_syntax.asp
            // Two ways we can solve this.
            // 1. using javascript and webbdrowser
            // 2 . diret parsing with out own logic
            string[] xPathParts = xPath.Split('/');
            string elementTagName = xPathParts[xPathParts.Length - 1];
            if (elementTagName.Contains("["))
            {
                elementTagName = elementTagName.Split('[')[0];
            }
            return theElement;
        }

            IHTMLElement FindElementByXPath2(string xPath, HTMLDocument doc)
        {
            //  http://www.bing.com/
            //  form[@id='sb_form']/div/input   - 
            //  input                           -
            //  input[@id='sb_form_q']          -

         
            IHTMLElement theElement = null;

            try
            {
                string[] tmp = xPath.Split(new string[] { "##" }, StringSplitOptions.None);

                string elementAttributes = tmp[1];
                string[] attributes = elementAttributes.Split(new string[] { ";" }, StringSplitOptions.None);
                string attributeId = attributes[0].Replace(@"id=", "");
                string attributeName = attributes[1].Replace(@"name=", "");
                string attributeClass = attributes[2].Replace(@"class=", "");

                string[] xPathParts = tmp[0].Split('/');
                string elementTagName = xPathParts[xPathParts.Length - 1];
                if (elementTagName.Contains("["))
                {
                    elementTagName = elementTagName.Split('[')[0];
                }


                // try in first place the id (if it's unique)
                theElement = doc.getElementById(attributeId);
                if (theElement != null && !String.IsNullOrEmpty(attributeId))
                {
                    int c = 0;
                    IHTMLElementCollection possibleElements = doc.getElementsByTagName(elementTagName);
                    foreach (IHTMLElement possibleElement in possibleElements)
                    {
                        if (possibleElement.id == attributeId)
                        {
                            c++;
                        }
                    }

                    if (c > 1)
                    {
                        theElement = null;
                    }
                }


                if (theElement == null && !String.IsNullOrEmpty(attributeName))
                {
                    IHTMLElementCollection possibleElements = doc.getElementsByName(attributeName);
                    if (possibleElements.length == 1)
                    {
                        theElement = (IHTMLElement)possibleElements.item(null, 0);
                    }
                }


                // try next, the exact xpath
                try
                {
                    if (theElement == null)
                    {
                        IHTMLElementCollection possibleElements = doc.getElementsByTagName(elementTagName);
                        foreach (IHTMLElement possibleElement in possibleElements)
                        {
                            string possibleXPath = "";
                            try
                            {
                                possibleXPath = FindXPath(possibleElement);
                                //Utils.l(possibleXPath);
                            }
                            catch (Exception e)
                            {
                                //Utils.l(e);
                            }

                            if (possibleXPath == xPath)
                            {
                                theElement = possibleElement;
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.log(ex);
                }


                try
                {
                    // next, try the path skipping attributes
                    if (theElement == null)
                    {
                        string cleanXPath = tmp[0];
                        IHTMLElementCollection possibleElements = doc.getElementsByTagName(elementTagName);
                        foreach (IHTMLElement possibleElement in possibleElements)
                        {
                            if (possibleElement.tagName == "INPUT")
                            {
                                IHTMLInputElement tmpInput = (IHTMLInputElement)possibleElement;
                                if (tmpInput.type == "hidden" || tmpInput.type == "text" || tmpInput.type == "password")
                                {
                                    continue;
                                }
                            }

                            string possibleXPath = FindXPath(possibleElement);
                            string[] possibleTmp = possibleXPath.Split(new string[] { "##" }, StringSplitOptions.None);
                            string cleanPossibleXPath = possibleTmp[0];

                            if (cleanPossibleXPath == cleanXPath)
                            {
                                theElement = possibleElement;
                                break;
                            }
                        }
                    }
                }
                catch (Exception ee)
                {
                    Utils.log(ee);
                }

            }
            catch (Exception e)
            {
                Utils.log(e);
            }

            return theElement;
        }


        //public IHTMLElement FindElement(UIFieldNode FieldIdentifierData)
        //{
        //    //IHTMLElement element = null;
        //    PropertyNameValueModel FindById = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.id.ToString().ToString()).SingleOrDefault();
        //    if (FindById.PropertyValue != null && FindById.PropertyValue != string.Empty)
        //    {
        //        IHTMLElement element = document3.getElementById(FindById.PropertyValue);
        //        //element = document.getElementById(FindById.PropertyValue);
        //        return element;
        //    }
        //    return null;
        //}

        // id lb-lst "ioc concept"
        public StepRunStatus SetText(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
            List<object> arrElements = FindElement(FieldIdentifierData);
            //lets  get all 
            if ((arrElements.Count == 0) && (FieldIdentifierData.UIFieldType != WebUIElementType.DoNotKnow))
            {
                FieldIdentifierData.UIFieldType = WebUIElementType.DoNotKnow;
                return Click(FieldIdentifierData, FieldActionValue);
            }

            //still 0 matches or more than one match fail the test
            if (arrElements.Count == 0 || arrElements.Count > 1)
                return StepRunStatus.FAILED;
            else
            {
                foreach (IHTMLElement elementToClick in arrElements)
                {
                    // IHTMLElement elementToClick = (IHTMLElement)arrElements[0];
                    SetMouseHover((IHTMLElement2)elementToClick);
                    elementToClick.scrollIntoView(true);
                    elementToClick.setAttribute("value", FieldActionValue);
                }

                return StepRunStatus.PASSED;
            }

        }

        public StepRunStatus SetActive(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
            SetNewPageInstance(FieldActionValue);
            return StepRunStatus.PASSED;
            

        }

        // id lb-lst "ioc concept"
        public StepRunStatus SetCheckBox(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
            //sometimes user may think it will select by defaultt and no need to say true explicitly
            if (FieldActionValue == string.Empty)
            {
                FieldActionValue = "true";
            }
            List<object> arrElements = FindElement(FieldIdentifierData);
            //lets  get all 
            if ((arrElements.Count == 0) && (FieldIdentifierData.UIFieldType != WebUIElementType.DoNotKnow))
            {
                FieldIdentifierData.UIFieldType = WebUIElementType.DoNotKnow;
                return Click(FieldIdentifierData, FieldActionValue);
            }

            //still 0 matches or more than one match fail the test
            if (arrElements.Count == 0 || arrElements.Count > 1)
                return StepRunStatus.FAILED;
            else
            {
                foreach (IHTMLElement checkBox in arrElements)
                {
                    SetMouseHover((IHTMLElement2)checkBox);
                    checkBox.scrollIntoView(true);
                    checkBox.setAttribute("checked", Convert.ToBoolean(FieldActionValue));
                    // or below code also works
                    //HTMLInputElement radioButton2 = (HTMLInputElement)radioButton;
                    //radioButton2.@checked = Convert.ToBoolean(FieldActionValue);
                }

                return StepRunStatus.PASSED;
            }
        }

        //verufy h1 to h6, hgroup, label for
        public StepRunStatus VerifyLabelText(UIFieldNode FieldIdentifierData, string FieldAactionValue)
        {
            return StepRunStatus.FAILED;
        }

        public StepRunStatus SelectRadioButton(UIFieldNode FieldIdentifierData, string FieldActionValue )
        {
            //sometimes user may think it will select by defaultt and no need to say true explicitly
            if (FieldActionValue==string.Empty)
            {
                FieldActionValue = "true";
            }
            List<object> arrElements = FindElement(FieldIdentifierData);
            //lets  get all 
            if ((arrElements.Count == 0) && (FieldIdentifierData.UIFieldType != WebUIElementType.DoNotKnow))
            {
                FieldIdentifierData.UIFieldType = WebUIElementType.DoNotKnow;
                return Click(FieldIdentifierData, FieldActionValue);
            }

            //still 0 matches or more than one match fail the test
            if (arrElements.Count == 0 || arrElements.Count > 1)
                return StepRunStatus.FAILED;
            else
            {
                foreach (IHTMLElement radioButton in arrElements)
                {
                    SetMouseHover((IHTMLElement2)radioButton);
                    radioButton.scrollIntoView(true);
                    radioButton.setAttribute("checked", Convert.ToBoolean(FieldActionValue));
                    // or below code also works
                    //HTMLInputElement radioButton2 = (HTMLInputElement)radioButton;
                    //radioButton2.@checked = Convert.ToBoolean(FieldActionValue);
                }

                return StepRunStatus.PASSED;
            }
            
        }//eom

        public StepRunStatus Click(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
            List<object> arrElements = FindElement(FieldIdentifierData);
            //lets  get all if there is no match
            if ((arrElements.Count == 0) && (FieldIdentifierData.UIFieldType != WebUIElementType.DoNotKnow))  
            {
                FieldIdentifierData.UIFieldType = WebUIElementType.DoNotKnow;
                return Click(FieldIdentifierData, FieldActionValue);
            }

            //still 0 matches or more than one match fail the test
            if (arrElements.Count == 0 || arrElements.Count > 1)
                return StepRunStatus.FAILED;
            else
            {
                foreach (IHTMLElement elementToClick in arrElements)
                {

                    SetMouseHover((IHTMLElement2)elementToClick);
                    elementToClick.scrollIntoView(true);
                    elementToClick.click();
                }

                return StepRunStatus.PASSED;
            }
        }//eom

        public StepRunStatus SelectItem(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
            List<object> arrElements = FindElement(FieldIdentifierData);
            //lets  get all 
            if ((arrElements.Count == 0) && (FieldIdentifierData.UIFieldType != WebUIElementType.DoNotKnow))
            {
                FieldIdentifierData.UIFieldType = WebUIElementType.DoNotKnow;
                return Click(FieldIdentifierData, FieldActionValue);
            }

            //still 0 matches or more than one match fail the test
            if (arrElements.Count == 0 || arrElements.Count > 1)
                return StepRunStatus.FAILED;
            else
            {
                foreach (IHTMLElement comboBox in arrElements)
                {
                    SetMouseHover((IHTMLElement2)comboBox);
                    // loop through all elements , find index and use it to select the same
                    IHTMLSelectElement selElement = comboBox as IHTMLSelectElement;
                    for (int i = 0; i < selElement.length; i++)
                    {
                        HTMLOptionElement optionElement = selElement.options[i];
                        //System.Windows.MessageBox.Show(optionElement.text);
                        //System.Windows.MessageBox.Show(optionElement.title);
                        //System.Windows.MessageBox.Show(optionElement.selected.ToString());
                        if (optionElement.text == FieldActionValue)
                        {
                            selElement.selectedIndex = i;
                            IHTMLElement3 comboBox3 = comboBox as IHTMLElement3;
                            comboBox3.FireEvent("onchange", null);
                            // or works never tested
                            //comboBox.setAttribute("value", FieldActionValue);
                            break;
                        }
                    }
                    break;
                }
            }
            return StepRunStatus.PASSED;

        }//m

        //public List<object> FindElement(UIFieldNode FieldIdentifierData, string FieldActionValue)
        //{
        //    //InternetExplorer ieInstanceWebBrowser = GetIEInstance();
        //    // Obtain the document interface
        //    IHTMLDocument3 document3 = (IHTMLDocument3)ieInstanceWebBrowser.Document;
        //    PropertyNameValueModel FindById = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.id.ToString()).SingleOrDefault();
        //    PropertyNameValueModel FindByName = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.name.ToString()).SingleOrDefault();
        //    PropertyNameValueModel FindByType = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.type.ToString()).SingleOrDefault();
        //    PropertyNameValueModel FindByMultiple = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.multiple.ToString()).SingleOrDefault();
        //    PropertyNameValueModel FindByValue = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.value.ToString()).SingleOrDefault();

        //    PropertyNameValueModel FindByClass = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.Class.ToString()).SingleOrDefault();
        //    PropertyNameValueModel FindByHref = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.href.ToString()).SingleOrDefault();
        //    PropertyNameValueModel FindByTitle = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.title.ToString()).SingleOrDefault();

        //    PropertyNameValueModel FindByLabelFor = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.labelfor.ToString()).SingleOrDefault();
           

        //    IHTMLElementCollection elements = null;

        //    Win32Api.SetForegroundWindow(process.MainWindowHandle);
        //    // first get all the elements of one of type usre has chosen
        //    if (FieldIdentifierData.UIFieldType == WebUIElementType.Link)
        //    {
        //        elements = document3.getElementsByTagName("a");
        //    }
        //    if (FieldIdentifierData.UIFieldType == WebUIElementType.Label)
        //    {
        //        elements = document3.getElementsByTagName("label");
        //    }
        //    else if (FieldIdentifierData.UIFieldType == WebUIElementType.Input || FieldIdentifierData.UIFieldType == WebUIElementType.TextBox)
        //    {
        //        elements = document3.getElementsByTagName("input");
        //    }
        //    else if (FieldIdentifierData.UIFieldType == WebUIElementType.Button)
        //    {
        //        elements = document3.getElementsByTagName("button");
        //    }
        //    else if (FieldIdentifierData.UIFieldType == WebUIElementType.CheckBox)
        //    {
        //        elements = document3.getElementsByTagName("input");
        //    }
        //    else if (FieldIdentifierData.UIFieldType == WebUIElementType.ComboBox)
        //    {
        //        elements = document3.getElementsByTagName("select");
        //    }
        //    else if (FieldIdentifierData.UIFieldType == WebUIElementType.DropDown)
        //    {
        //        elements = document3.getElementsByTagName("select");
        //    }
        //    else if (FieldIdentifierData.UIFieldType == WebUIElementType.RadioButton)
        //    {
        //        elements = document3.getElementsByTagName("input");
        //    }
        //    else if (FieldIdentifierData.UIFieldType == WebUIElementType.Tab)
        //    {
        //        elements = document3.getElementsByTagName("li");
        //    }
        //    else if (FieldIdentifierData.UIFieldType == WebUIElementType.Div)
        //    {
        //        elements = document3.getElementsByTagName("div");
        //    }
        //    else
        //    {
        //        //// Extract all elements
        //        elements = ((IHTMLDocument2)document3).all;


        //        #region frames scenario
        //        ////worst case scenario is a page may contain frmaes where each frame is a document
        //        //// Each <frame> element can hold a separate documen
        //        //// FramesCollection frm = ((IHTMLDocument2)document3).frames;
        //        //// or specifc like below
        //        //HTMLIFrame frm = ((IHTMLDocument2)document3).frames.item(0);
        //        //int readyState = 0;

        //        //while (frm.readyState != 4)
        //        //{
        //        //    // do nothing. be careful to not create an endless loop
        //        //}

        //        //if (frm.readyState == 4)
        //        //{
        //        //    // get your content now
        //        //}
        //        #endregion
        //    }

        //    List<object> arrElements = new List<object>();
        //    // ArrayList arrElements = new ArrayList();
        //    //move them to arrayList
        //    // Now examine each "child" in the "childrenCollection"
        //    IEnumerator childrenEnumerator = elements.GetEnumerator();
        //    foreach (IHTMLElement element in elements)
        //    {
        //        arrElements.Add(element);
        //    }


        //    //user could give one or a combination of below. so first collect elements by each property and filter them until all the properties user specified are exhauseted.
        //    if (arrElements.Count > 0 && FindById != null && FindById.PropertyValue != null && FindById.PropertyValue != string.Empty)
        //    {
        //        List<object> tempArrElements = new List<object>();
        //        foreach (IHTMLElement elementToClick in arrElements)
        //        {
        //            //first criteria met and take all matches with id into temp array
        //            if (elementToClick.getAttribute("id") == FindById.PropertyValue)
        //            {
        //                tempArrElements.Add(elementToClick);
        //            }
        //        }
        //        //narrow the search criteria by overwriting with first set of values
        //        if (tempArrElements.Count > 0)
        //        {
        //            arrElements = tempArrElements;
        //        }

        //    }

        //    if (arrElements.Count > 0 && FindByClass != null && FindByClass.PropertyValue != null && FindByClass.PropertyValue != string.Empty)
        //    {

        //        List<object> tempArrElements = new List<object>();
        //        foreach (IHTMLElement elementToClick in arrElements)
        //        {
        //            //first criteria met and take all matches with name into temp array
        //            if (elementToClick.getAttribute("className") == FindByClass.PropertyValue)
        //            {
        //                tempArrElements.Add(elementToClick);
        //            }
        //        }
        //        //narrow the search criteria by overwriting with first set of values
        //        if (tempArrElements.Count > 0)
        //        {
        //            arrElements = tempArrElements;
        //        }

        //    }

        //    if (arrElements.Count > 0 && FindByHref != null && FindByHref.PropertyValue != null && FindByHref.PropertyValue != string.Empty)
        //    {

        //        List<object> tempArrElements = new List<object>();
        //        foreach (IHTMLElement elementToClick in arrElements)
        //        {
        //            //first criteria met and take all matches with name into temp array
        //            if (elementToClick.getAttribute("href") == FindByHref.PropertyValue)
        //            {
        //                tempArrElements.Add(elementToClick);
        //            }
        //        }
        //        //narrow the search criteria by overwriting with first set of values
        //        if (tempArrElements.Count > 0)
        //        {
        //            arrElements = tempArrElements;
        //        }

        //    }
        //    if (arrElements.Count > 0 && FindByTitle!= null && FindByTitle.PropertyValue != null && FindByTitle.PropertyValue != string.Empty)
        //    {

        //        List<object> tempArrElements = new List<object>();
        //        foreach (IHTMLElement elementToClick in arrElements)
        //        {
        //            //first criteria met and take all matches with name into temp array
        //            if (elementToClick.title == FindByTitle.PropertyValue)
        //            {
        //                tempArrElements.Add(elementToClick);
        //            }
        //        }
        //        //narrow the search criteria by overwriting with first set of values
        //        if (tempArrElements.Count > 0)
        //        {
        //            arrElements = tempArrElements;
        //        }

        //    }

        //    if (arrElements.Count > 0 && FindByLabelFor != null && FindByLabelFor.PropertyValue != null && FindByLabelFor.PropertyValue != string.Empty)
        //    {

        //        List<object> tempArrElements = new List<object>();
        //        foreach (IHTMLElement elementToClick in arrElements)
        //        {
        //            //first criteria met and take all matches with name into temp array
        //            if (elementToClick.getAttribute("for") == FindByLabelFor.PropertyValue)
        //            {
        //                tempArrElements.Add(elementToClick);
        //            }
        //        }
        //        //narrow the search criteria by overwriting with first set of values
        //        if (tempArrElements.Count > 0)
        //        {
        //            arrElements = tempArrElements;
        //        }

        //    }
        //    if (arrElements.Count > 0 && FindByValue != null && FindByValue.PropertyValue != null && FindByValue.PropertyValue != string.Empty)
        //    {

        //        List<object> tempArrElements = new List<object>();
        //        foreach (IHTMLElement elementToClick in arrElements)
        //        {
        //            //first criteria met and take all matches with name into temp array
        //            if (elementToClick.getAttribute("value") == FindByValue.PropertyValue)
        //            {
        //                tempArrElements.Add(elementToClick);
        //            }
        //        }
        //        //narrow the search criteria by overwriting with first set of values
        //        if (tempArrElements.Count > 0)
        //        {
        //            arrElements = tempArrElements;
        //        }

        //    }

        //    if (arrElements.Count > 0 && FindByName != null && FindByName.PropertyValue != null && FindByName.PropertyValue != string.Empty)
        //    {

        //        List<object> tempArrElements = new List<object>();
        //        foreach (IHTMLElement elementToClick in arrElements)
        //        {
        //            //first criteria met and take all matches with name into temp array
        //            if (elementToClick.getAttribute("name") == FindByName.PropertyValue)
        //            {
        //                tempArrElements.Add(elementToClick);
        //            }
        //        }
        //        //narrow the search criteria by overwriting with first set of values
        //        if (tempArrElements.Count > 0)
        //        {
        //            arrElements = tempArrElements;
        //        }

        //    }
        //    if (arrElements.Count > 0 && FindByType != null && FindByType.PropertyValue != null && FindByType.PropertyValue != string.Empty)
        //    {

        //        List<object> tempArrElements = new List<object>();
        //        foreach (IHTMLElement elementToClick in arrElements)
        //        {
        //            //first criteria met and take all matches with name into temp array
        //            if (elementToClick.getAttribute("type") == FindByType.PropertyValue)
        //            {
        //                tempArrElements.Add(elementToClick);
        //            }
        //        }
        //        //narrow the search criteria by overwriting with first set of values
        //        if (tempArrElements.Count > 0)
        //        {
        //            arrElements = tempArrElements;
        //        }

        //    }
        //    return arrElements;
        //}

        public List<object> FindElement(UIFieldNode FieldIdentifierData)
        {
            //InternetExplorer ieInstanceWebBrowser = GetIEInstance();
            // Obtain the document interface
            IHTMLDocument3 document3 = (IHTMLDocument3)ieInstanceWebBrowser.Document;
            PropertyNameValueModel FindById = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.id.ToString()).SingleOrDefault();
            PropertyNameValueModel FindByName = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.name.ToString()).SingleOrDefault();
            PropertyNameValueModel FindByType = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.type.ToString()).SingleOrDefault();
            PropertyNameValueModel FindByMultiple = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.multiple.ToString()).SingleOrDefault();
            PropertyNameValueModel FindByValue = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.value.ToString()).SingleOrDefault();

            PropertyNameValueModel FindByxPath = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.xpath.ToString()).SingleOrDefault();

            PropertyNameValueModel FindByClass = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.Class.ToString()).SingleOrDefault();

            PropertyNameValueModel FindByClassName = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.className.ToString()).SingleOrDefault();
            PropertyNameValueModel FindByHref = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.href.ToString()).SingleOrDefault();
            PropertyNameValueModel FindByTitle = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.title.ToString()).SingleOrDefault();

            PropertyNameValueModel FindByLabelFor = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.labelfor.ToString()).SingleOrDefault();


            IHTMLElementCollection elements = null;

            Win32Api.SetForegroundWindow(process.MainWindowHandle);
            if (FindByxPath!=null)
            {
                FindElementByXPath(FindByxPath.PropertyValue, ieInstanceWebBrowser.Document);
            }
            // first get all the elements of one of type usre has chosen
            if (FieldIdentifierData.UIFieldType == WebUIElementType.Link)
            {
                elements = document3.getElementsByTagName("a");
            }
            if (FieldIdentifierData.UIFieldType == WebUIElementType.Label)
            {
                elements = document3.getElementsByTagName("label");
            }
            else if (FieldIdentifierData.UIFieldType == WebUIElementType.Input || FieldIdentifierData.UIFieldType == WebUIElementType.TextBox)
            {
                elements = document3.getElementsByTagName("input");
            }
            else if (FieldIdentifierData.UIFieldType == WebUIElementType.Button)
            {
                elements = document3.getElementsByTagName("button");
            }
            else if (FieldIdentifierData.UIFieldType == WebUIElementType.CheckBox)
            {
                elements = document3.getElementsByTagName("input");
            }
            else if (FieldIdentifierData.UIFieldType == WebUIElementType.ComboBox)
            {
                elements = document3.getElementsByTagName("select");
            }
            else if (FieldIdentifierData.UIFieldType == WebUIElementType.DropDown)
            {
                elements = document3.getElementsByTagName("select");
            }
            else if (FieldIdentifierData.UIFieldType == WebUIElementType.RadioButton)
            {
                elements = document3.getElementsByTagName("input");
            }
            else if (FieldIdentifierData.UIFieldType == WebUIElementType.Tab)
            {
                elements = document3.getElementsByTagName("li");
            }
            else if (FieldIdentifierData.UIFieldType == WebUIElementType.Div)
            {
                elements = document3.getElementsByTagName("div");
            }

            else
            {
                //// Extract all elements
                elements = ((IHTMLDocument2)document3).all;


                #region frames scenario
                ////worst case scenario is a page may contain frmaes where each frame is a document
                //// Each <frame> element can hold a separate documen
                //// FramesCollection frm = ((IHTMLDocument2)document3).frames;
                //// or specifc like below
                //HTMLIFrame frm = ((IHTMLDocument2)document3).frames.item(0);
                //int readyState = 0;

                //while (frm.readyState != 4)
                //{
                //    // do nothing. be careful to not create an endless loop
                //}

                //if (frm.readyState == 4)
                //{
                //    // get your content now
                //}
                #endregion
            }

            List<object> arrElements = new List<object>();
            // ArrayList arrElements = new ArrayList();
            //move them to arrayList
            // Now examine each "child" in the "childrenCollection"
            IEnumerator childrenEnumerator = null;
            try
            {
                 childrenEnumerator = elements.GetEnumerator();
            }
            catch { }

            if (childrenEnumerator!=null)
            {
                foreach (IHTMLElement element in elements)
                {
                    arrElements.Add(element);
                }
            }

            if (arrElements.Count == 0)
            {
                FieldIdentifierData.UIFieldType = WebUIElementType.DoNotKnow;
                return FindElement(FieldIdentifierData);
            }

            //user could give one or a combination of below. so first collect elements by each property and filter them until all the properties user specified are exhauseted.
            if (arrElements.Count > 0 && FindById != null && FindById.PropertyValue != null && FindById.PropertyValue != string.Empty)
            {
                List<object> tempArrElements = new List<object>();
                foreach (IHTMLElement elementToClick in arrElements)
                {
                    object oElement = elementToClick.getAttribute("id");// class doesnt work .use "className' instead of "class"
                    if (!(oElement is DBNull || oElement == null))
                    {
                        //first criteria met and take all matches with name into temp array
                        if (oElement.ToString().Equals(FindById.PropertyValue))
                        {
                            tempArrElements.Add(elementToClick);
                        }
                    }
                }
                //narrow the search criteria by overwriting with first set of values
                if (tempArrElements.Count > 0)
                {
                    arrElements = tempArrElements;
                }

            }

            if (arrElements.Count > 0 && FindByClassName != null && FindByClassName.PropertyValue != null && FindByClassName.PropertyValue != string.Empty && FindByClassName.PropertyName.ToLower().Equals("classname"))
            {

                List<object> tempArrElements = new List<object>();
                foreach (IHTMLElement elementToClick in arrElements)
                {
                    object oElement = elementToClick.getAttribute("classname");// class doesnt work .use "className' instead of "class"
                    if (!(oElement is DBNull || oElement == null))
                    {
                        //first criteria met and take all matches with name into temp array
                        if (oElement.ToString().Equals(FindByClassName.PropertyValue))
                        {
                            tempArrElements.Add(elementToClick);
                        }
                    }
                }
                //narrow the search criteria by overwriting with first set of values
                if (tempArrElements.Count > 0)
                {
                    arrElements = tempArrElements;
                }

            }

            if (arrElements.Count > 0 && FindByClass != null && FindByClass.PropertyValue != null && FindByClass.PropertyValue != string.Empty &&  FindByClass.PropertyName.ToLower().Equals("class"))
            {

                List<object> tempArrElements = new List<object>();
                foreach (IHTMLElement elementToClick in arrElements)
                {
                    object oElement = elementToClick.getAttribute("classname");// class doesnt work .use "className' instead of "class"
                    if (!(oElement is DBNull || oElement == null))
                    {
                        //first criteria met and take all matches with name into temp array
                        if (oElement.ToString().Equals(FindByClass.PropertyValue))
                        {
                            tempArrElements.Add(elementToClick);
                        }
                    }
                }
                //narrow the search criteria by overwriting with first set of values
                if (tempArrElements.Count > 0)
                {
                    arrElements = tempArrElements;
                }

            }

            if (arrElements.Count > 0 && FindByHref != null && FindByHref.PropertyValue != null && FindByHref.PropertyValue != string.Empty)
            {

                List<object> tempArrElements = new List<object>();
                foreach (IHTMLElement elementToClick in arrElements)
                {
                    //first criteria met and take all matches with name into temp array
                    object oElement = elementToClick.getAttribute("href");// class doesnt work .use "className' instead of "class"
                    if (!(oElement is DBNull || oElement == null))
                    {
                        //first criteria met and take all matches with name into temp array
                        if (oElement.ToString().Equals(FindByHref.PropertyValue))
                        {
                            tempArrElements.Add(elementToClick);
                        }
                    }
                }
                //narrow the search criteria by overwriting with first set of values
                if (tempArrElements.Count > 0)
                {
                    arrElements = tempArrElements;
                }

            }
            if (arrElements.Count > 0 && FindByTitle != null && FindByTitle.PropertyValue != null && FindByTitle.PropertyValue != string.Empty)
            {

                List<object> tempArrElements = new List<object>();
                foreach (IHTMLElement elementToClick in arrElements)
                {
                    //first criteria met and take all matches with name into temp array
                    //first criteria met and take all matches with name into temp array
                    object oElement = elementToClick.title;// class doesnt work .use "className' instead of "class"
                    if (!(oElement is DBNull || oElement == null))
                    {
                        //first criteria met and take all matches with name into temp array
                        if (oElement.ToString().Equals(FindByTitle.PropertyValue))
                        {
                            tempArrElements.Add(elementToClick);
                        }
                    }
                }
                //narrow the search criteria by overwriting with first set of values
                if (tempArrElements.Count > 0)
                {
                    arrElements = tempArrElements;
                }

            }

            if (arrElements.Count > 0 && FindByLabelFor != null && FindByLabelFor.PropertyValue != null && FindByLabelFor.PropertyValue != string.Empty)
            {

                List<object> tempArrElements = new List<object>();
                foreach (IHTMLElement elementToClick in arrElements)
                {
                    //first criteria met and take all matches with name into temp array
                    //first criteria met and take all matches with name into temp array
                    object oElement = elementToClick.getAttribute("for");// class doesnt work .use "className' instead of "class"
                    if (!(oElement is DBNull || oElement == null))
                    {
                        //first criteria met and take all matches with name into temp array
                        if (oElement.ToString().Equals(FindByLabelFor.PropertyValue))
                        {
                            tempArrElements.Add(elementToClick);
                        }
                    }
                }
                //narrow the search criteria by overwriting with first set of values
                if (tempArrElements.Count > 0)
                {
                    arrElements = tempArrElements;
                }

            }
            if (arrElements.Count > 0 && FindByValue != null && FindByValue.PropertyValue != null && FindByValue.PropertyValue != string.Empty)
            {

                List<object> tempArrElements = new List<object>();
                foreach (IHTMLElement elementToClick in arrElements)
                {
                    //first criteria met and take all matches with name into temp array
                    object oElement = elementToClick.getAttribute("value");// class doesnt work .use "className' instead of "class"
                    if (!(oElement is DBNull || oElement == null))
                    {
                        //first criteria met and take all matches with name into temp array
                        if (oElement.ToString().Equals(FindByValue.PropertyValue))
                        {
                            tempArrElements.Add(elementToClick);
                        }
                    }
                }
                //narrow the search criteria by overwriting with first set of values
                if (tempArrElements.Count > 0)
                {
                    arrElements = tempArrElements;
                }

            }

            if (arrElements.Count > 0 && FindByName != null && FindByName.PropertyValue != null && FindByName.PropertyValue != string.Empty)
            {

                List<object> tempArrElements = new List<object>();
                foreach (IHTMLElement elementToClick in arrElements)
                {
                    //first criteria met and take all matches with name into temp array
                    object oElement = elementToClick.getAttribute("name");// class doesnt work .use "className' instead of "class"
                    if (!(oElement is DBNull || oElement == null))
                    {
                        //first criteria met and take all matches with name into temp array
                        if (oElement.ToString().Equals(FindByName.PropertyValue))
                        {
                            tempArrElements.Add(elementToClick);
                        }
                    }
                }
                //narrow the search criteria by overwriting with first set of values
                if (tempArrElements.Count > 0)
                {
                    arrElements = tempArrElements;
                }

            }
            if (arrElements.Count > 0 && FindByType != null && FindByType.PropertyValue != null && FindByType.PropertyValue != string.Empty)
            {

                List<object> tempArrElements = new List<object>();
                foreach (IHTMLElement elementToClick in arrElements)
                {
                    object oElement = elementToClick.getAttribute("type");// class doesnt work .use "className' instead of "class"
                    if (!(oElement is DBNull || oElement == null))
                    {
                        //first criteria met and take all matches with name into temp array
                        if (oElement.ToString().Equals(FindByType.PropertyValue))
                        {
                            tempArrElements.Add(elementToClick);
                        }
                    }
                }
                //narrow the search criteria by overwriting with first set of values
                if (tempArrElements.Count > 0)
                {
                    arrElements = tempArrElements;
                }

            }
            return arrElements;
        }


        private static void SetMouseHover(IHTMLElement2 rectElement)
        {
            //IHTMLElement2 rectElement = null;
            //if (FindBy.Key == By.Id)
            //{
            //    rectElement = (IHTMLElement2)document3.getElementById(FindBy.Value);
            //}
            //if (FindBy.Key == By.name)
            //{
            //    rectElement = (IHTMLElement2)document3.getElementByI(FindBy.Value);
            //}
            IHTMLRect rect = rectElement.getBoundingClientRect();
            Cursor.Position = new System.Drawing.Point(rect.left, rect.top);
            Win32Api.SetCursorPos(rect.left, rect.top);
            Thread.Sleep(1000);

        }

        public StepRunStatus Quit()
        {
           
            ieInstanceWebBrowser.Quit();
            ieInstanceWebBrowser = null;
            return StepRunStatus.PASSED;
        }

        public StepRunStatus Wait(TimeSpan timeSpan)
        {
            Thread.Sleep(timeSpan);
            return StepRunStatus.PASSED;
        }
        public StepRunStatus VerifyText(UIFieldNode FieldIdentifierData, string TextToVerify)
        {

            List<object> arrElements = FindElement(FieldIdentifierData);
            //lets  get all 
            if ((arrElements.Count == 0) && (FieldIdentifierData.UIFieldType != WebUIElementType.DoNotKnow))
            {
                FieldIdentifierData.UIFieldType = WebUIElementType.DoNotKnow;
                return VerifyText(FieldIdentifierData, TextToVerify);
            }

            //still 0 matches or more than one match fail the test
            if (arrElements.Count == 0 || arrElements.Count > 1)
                return StepRunStatus.FAILED;
            else
            {
                foreach (IHTMLElement htmlElement in arrElements)
                {
                    SetMouseHover((IHTMLElement2)htmlElement);
                    htmlElement.scrollIntoView(true);
                    String actualText = "";
                    if (htmlElement is IHTMLDivElement)
                    {
                         actualText = htmlElement.getAttribute("innerText");
                    }
                    else
                    {
                        actualText = htmlElement.getAttribute("value");
                    }
                    if (actualText.Equals( TextToVerify))
                    {
                        return StepRunStatus.PASSED;
                    }
                    
                    // or below code also works
                    //HTMLInputElement radioButton2 = (HTMLInputElement)radioButton;
                    //radioButton2.@checked = Convert.ToBoolean(FieldActionValue);
                }

                return StepRunStatus.PASSED;
            }
           
        }//eom

        public StepRunStatus VerifyListItem(UIFieldNode FieldIdentifierData, string TextToVerify)
        {

            List<object> arrElements = FindElement(FieldIdentifierData);
            //lets  get all 
            if ((arrElements.Count == 0) && (FieldIdentifierData.UIFieldType != WebUIElementType.DoNotKnow))
            {
                FieldIdentifierData.UIFieldType = WebUIElementType.DoNotKnow;
                return VerifyText(FieldIdentifierData, TextToVerify);
            }

            //still 0 matches or more than one match fail the test
            if (arrElements.Count == 0 || arrElements.Count > 1)
                return StepRunStatus.FAILED;
            else
            {
                foreach (IHTMLElement comboBox in arrElements)
                {
                    SetMouseHover((IHTMLElement2)comboBox);
                    comboBox.scrollIntoView(true);
                    SetMouseHover((IHTMLElement2)comboBox);
                    // loop through all elements , find index and use it to select the same
                    IHTMLSelectElement selElement = comboBox as IHTMLSelectElement;
                    for (int i = 0; i < selElement.length; i++)
                    {
                        HTMLOptionElement optionElement = selElement.options[i];
                        //System.Windows.MessageBox.Show(optionElement.text);
                        //System.Windows.MessageBox.Show(optionElement.title);
                        //System.Windows.MessageBox.Show(optionElement.selected.ToString());
                        if (optionElement.text == TextToVerify)
                        {                           
                            break;
                        }
                    }

                }

                return StepRunStatus.PASSED;
            }

        }//eom

        //public StepRunStatus VerifyText(UIFieldNode FieldIdentifierData, string TextToVerify)
        //{

        //    Win32Api.SetForegroundWindow(process.MainWindowHandle);
        //   // InternetExplorer ieInstanceWebBrowser = GetIEInstance();
        //    //Manipulating HTML element
        //    IHTMLDocument3 document3 = (IHTMLDocument3)ieInstanceWebBrowser.Document;
        //    PropertyNameValueModel FindById = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.id.ToString()).SingleOrDefault();
        //    PropertyNameValueModel FindByClass = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.Class.ToString()).SingleOrDefault();

        //    PropertyNameValueModel FindByName = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.name.ToString()).SingleOrDefault();
        //    PropertyNameValueModel FindByType = FieldIdentifierData.UIFieldPropCollection.Where(x => x.PropertyName == WebAttributeBy.type.ToString()).SingleOrDefault();
        //    IHTMLElementCollection elements = null;

        //    if (FieldIdentifierData.UIFieldType == WebUIElementType.Link)
        //    {
        //        elements = document3.getElementsByTagName("a");
        //    }
        //    else if (FieldIdentifierData.UIFieldType == WebUIElementType.TextBox)
        //    {
        //        elements = document3.getElementsByTagName("input");
        //    }
        //    else
        //    {
        //        elements = ((IHTMLDocument2)document3).all;
        //    }

        //    if (FindByClass != null && FindByClass.PropertyValue != null && FindByClass.PropertyValue != string.Empty)
        //    {

        //        foreach (IHTMLElement element in ((IHTMLDocument2)ieInstanceWebBrowser.Document).all)
        //        {
        //            if (element.getAttribute("class") == FindByClass.PropertyValue)
        //            {
        //                SetMouseHover((IHTMLElement2)element);
        //                element.scrollIntoView(true);
        //                if (element.innerText.IndexOf(TextToVerify) != -1)
        //                {

        //                    return StepRunStatus.PASSED;

        //                }
        //            }
        //        }

        //    }
        //    else if (FindById != null && FindById.PropertyValue != null && FindById.PropertyValue != string.Empty)
        //    {

        //        foreach (IHTMLElement element in elements)
        //        {
        //            if (element.getAttribute("id") == FindById.PropertyValue)
        //            {
        //                SetMouseHover((IHTMLElement2)element);
        //                element.scrollIntoView(true);
        //                if (element.innerText.IndexOf(TextToVerify) != -1)
        //                {

        //                    return StepRunStatus.PASSED;

        //                }
        //            }
        //        }

        //    }
        //    else if (FindByName != null && FindByName.PropertyValue != null && FindByName.PropertyValue != string.Empty)
        //    {

        //        foreach (IHTMLElement element in elements)
        //        {
        //            if (element.getAttribute("name") == FindByName.PropertyValue)
        //            {
        //                SetMouseHover((IHTMLElement2)element);
        //                element.scrollIntoView(true);
        //                if (element is IHTMLInputElement)
        //                {
        //                    if (element.getAttribute("value").IndexOf(TextToVerify) != -1)
        //                    {
        //                        return StepRunStatus.PASSED;

        //                    }
        //                }

        //            }
        //        }

        //    }
        //    else if (FindByType != null && FindByType.PropertyValue != null && FindByType.PropertyValue != string.Empty)
        //    {

        //        foreach (IHTMLElement element in elements)
        //        {
        //            if (element.getAttribute("type") == FindByType.PropertyValue)
        //            {
        //                SetMouseHover((IHTMLElement2)element);
        //                element.scrollIntoView(true);
        //                if (element.innerText.IndexOf(TextToVerify) != -1)
        //                {
        //                    return StepRunStatus.PASSED;

        //                }
        //            }
        //        }

        //    }


        //    return StepRunStatus.FAILED;
        //}

    }//class end
}//eon

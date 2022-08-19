//
// SettingsManager.cs
//
// Author:
//       melquiceded balbi villanueva <mbv@projects.com>
//
// Copyright (c) 2022 MIT
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using QuickTools; 
using System.Configuration; 
namespace cnote
{
        /// <summary>
        /// Manage All the Settings from the app 
        /// </summary>
    public class Settings
    {



        /// <summary>
        /// Reads all settings.
        /// </summary>
        public  static void ReadAll()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                  Color.Green($"Key: {key} Value: {appSettings[key]}");
                      
                       
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Get.Alert("Error reading app settings");
            }
        }
        /// <summary>
        /// Reads the setting.
        /// </summary>
        /// <param name="Key">Key.</param>
     public   static string Read(object Key)
        {
            string result = null;
            string key = Key.ToString();
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException e)
            {
                Get.Alert("Error reading app settings \n\n"+e);
            }
            return result; 
        }
        /// <summary>
        /// Adds the or update app settings.
        /// </summary>
        /// <param name="Key">Key.</param>
        /// <param name="Value">Value.</param>
   public static void AddOrChange(object Key, object Value)
        {
            string key = Key.ToString();
            string value = Value.ToString();

            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Get.Alert("Error writing app settings");
            }
        }
    

        /// <summary>
        /// Not Implemented Yet 
        /// Initializes a new instance of the <see cref="T:cchat.SettingsManager"/> class.
        /// </summary>
        public Settings()
        {
        }
        /// <summary>
        /// This Inisialization can modify or add any settings ////////////////
        /// Initializes a new instance of the <see cref="T:cchat.SettingsManager"/> class.
        /// </summary>
        /// <param name="settingsToAddOrModify">Settings to add or modify.</param>
        /// <param name="valudeToAddOrModify">Valude to add or modify.</param>
        public Settings(object settingsToAddOrModify,object valudeToAddOrModify )
        {
            AddOrChange(settingsToAddOrModify.ToString(), valudeToAddOrModify.ToString());
        }
    }
}

using System;
using System.IO;
using QuickTools;
namespace cnote
{
  class Delete
  {

            public void DeleteFile()
            {
                  var app = new Open();
                  Do.Cle();
                  // this will display all the files or notes
                  app.DisplayExcistingFiles();
                  // this will ask to which file you want to open 

                  Do.W("Please Type the number of the Note that you would like to delete");
                  string file;
                  string onlyName;
                  string path = Directory.GetCurrentDirectory()+"/"; 
                  try
                  {
                        Do.Input();

                        file = app.file[Do.Number -1];
                        onlyName = file.Substring(file.LastIndexOf("/") + 1);

                        Do.Back_Red("YOU WILL NOT BE ABLE TO GET THIS FILE BACK PLEASE CONFIM IF YOU ARE SURE");




                        // this delete the file that is been selected
                        Do.Yellow("Note that you are deleting:   '" + onlyName + "'");
                        Do.Yellow("1. Confirm   2. Cancell");
                        Get.KeyNumber();// question to confirm if you would like to permanetly delete that file 

                        if (Do.Number == 1)
                        {
                              // this has to be corrected for the Final version
                              // since this needs to have the current directory and 
                              // also needs to add some details like the directory for 
                              // the notes 
                              //Get.Box(file);
                              //Get.Box(path + file); 
                              File.Delete(path+file);
                              //int location;
                           //   string bar = "/";
                             // string nameOnly = file.Substring(file.IndexOf(bar+1));
                            //  Get.Wait(nameOnly); 
                               
                              Do.Yellow("Note Delted Sucessfully  " + onlyName);
                              Get.WaitTime(1000);

                        } if (Do.Number == 2)
                        {
                              Do.W("Process Cancelled");
                              Get.WaitTime(100);
                              AppOptions.Final();
                        }

                        AppOptions.Final();
                  }catch(Exception e)
                  {
                        Get.WrongIn(e);
                        DeleteFile();
      }
}
    
  }
}


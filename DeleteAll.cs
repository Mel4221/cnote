using System;
using QuickTools; 
using System.IO; 
using System.Collections.Generic;

namespace cnote
{
      public class DeleteAll
      {

            private static List<string> FilesColected = new List<string>();

            public static void CollectFiles()
            {
                  //variables
                  string path, type, staticPath; 
                  string[] files; 
                  // get current path 
                  path = Directory.GetCurrentDirectory() + "/";
                  // this path can not be changed 
                  staticPath = @"data/notes/";
                  // type of files
                  type = "*.txt";
                  // get array of files 
                  files = Directory.GetFiles(staticPath, type);

                  foreach (string file in files )
                  {
                        //Get.Box(path+file);
                        Color.Red(file.Substring(file.LastIndexOf("/")+1));
                        FilesColected.Add(path+file); 
                  }
                  Files(FilesColected);
            }

            public static void Files(List<string> files)
            {
                 // CollectFiles(); 
                  var goTo = new AppOptions();
               //   var app = new Open();
                // app.DisplayExcistingFiles(); // this will also loud all the data 
                  // that i need to save up 

                  Get.Yellow("All these notes will be deleted!!!");
                  Get.Yellow("1. Comfirm "+" "+" 2.Cancell" );
                  Get.Input(); 
                   try
                  {


                        switch (Get.Number)
                        {
                              case 1:
                                    // here all the notes will be deleted 
                                    foreach (string file in files)
                                    {
                                          //Get.Box(file);
                                          File.Delete(file);
                                   
                                    }
                                    Get.Yellow("Deletion Completed , Files Deleted: " + FilesColected.Count);
                                    FilesColected = new List<string>();
                                    AppOptions.Final();
                                    break;
                              case 2:
                                    Get.Green("Deletion Cancelled");
                                    Get.WaitTime(1000);
                                    FilesColected = new List<string>();
                                    goTo.Option();
                                    break;
                              default:
                                    Color.Yellow("Wrong input ");
                                    FilesColected = new List<string>();
                                    goTo.Option();
                                    break;
                        }
                  }
                  catch(Exception e)
                  {
                        Color.Yellow("it seems that there was something that went wrong with the last imput"+e);
                        FilesColected = new List<string>();
                        AppOptions.Final(); 
                  }
            }
        
      }
}

//
// Program.cs
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


/*
This system has been created by MBV  which  has created this System 
as a Beta version with the aim of creatting a note saver by putting on practice 
object oriented programming  , this system is supposed to create file notes along with 
the avility to delete  , update , rename , save in the cloud all this notes it may not look
so pretty because is literally a console application but ti can be used on differents aspects of it.

as this program has been crated while im at work , some times i just document the changes
or the funtionality that it does , from now on i will also be adding more stuff such as dates and the changes added
during that date , today  is 03/04/2022
1.  Open 
2.  Options
3.  Delete 

    Final version of this sysstem is been relased under my public license 
    03/05/2022  Was done the Completed version and it is ready to be compiled
    Prior Compilation there are a couple of things that needs to be ajusted , so please refer to 
    Delete
    NewDoc
    Open 
    ____________________________________________________________
    in there is included the corrections that needs to be added 
    lastly there is a general path that needs to be added
    like a fild  of one class just to have the path for all the notes created 
    on a single spot 

              this class is completly useless 
              but it was easier to add this class
              than overritten all the codes 
*/


using System;
using System.IO; 
using QuickTools;
using System.Text;

using System.Threading;
namespace cnote
{
  

      class MainProgram
  {
            static void LoadPath()
            {     
                  string dir = Get.Path+"data/notes/"; 
                  if (Directory.Exists(dir)== false)
                  {
                        Directory.CreateDirectory(dir);
                  }
            }




            // this method just use the methods W that was previusly C
            // along with the method Input and the field Text 
            // to verified and make sure that the caracter does not contain any of the 
            // current simbols 
            public const string Version = "M1.0.0.1F";
    static void Main (string[] args)
    {


                  //   Log.Event("log", Get.Input());
                  //   Get.Wait(Reader.Read(Get.Path+"data/qt/logs/log"));

                  var start = new AppOptions();
                  try
                  {

                        LoadPath(); 
                        start.Option();
                  }
                  catch(Exception e)
                  {
                        Get.Alert("Something Went really wrong , and the ConsoleNotepad could not be stopped it, more details : \n"+e);
                        Log.Event("Exeptions", e);
                       
                  }
                 
                 
            }
            // this is the program exit
            public static void Exit ()
    {
      Do.Cle ();
      Do.Green ("Bye");
      Thread.Sleep (1000);
      Environment.Exit(0);

    }

  }
}



/*
HERE IS LOCATED NOTES FROM THE SYSTEM THAT COULD BE used
AS REFERENCESS TO GET SOME STUFF DONE
NOTHING IMPORTANTNT IS WRITTEN HERE 
JUST IN CASE 
*/



/*
      string currentPath = Directory.GetCurrentDirectory ();
       
        // check if home exist 
        Console.WriteLine (Directory.Exists ("notes"));
        // this create the directory notes
       //  DirectoryInfo newDirectory = Directory.CreateDirectory("notes");
         
        Console.WriteLine (Directory.GetCurrentDirectory());
        
       string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        DirectoryInfo dirs = new DirectoryInfo(docPath);
        foreach (var files in dirs.EnumerateFiles())
        {
            Console.WriteLine(files);
        }*/

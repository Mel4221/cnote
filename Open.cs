using System.IO;
using QuickTools;
using System.Collections.Generic;
namespace cnote
{
    

      class Open
  {
    public int CurrentFileNumber = 1;
    public List < string > file = new List < string > ();

    public void OpenFile ()
    {
        
      // first display all the current files
      if(this.file.Count <= 0) { 
                  this.DisplayExcistingFiles();
                  }
                  else
                  {
                        file = new List<string>();
                        this.DisplayExcistingFiles(); 
                  }
                  // her we will open the file that is introduced by the name 

                  /*  
                      foreach(string doc in file)
                      {
                          Console.WriteLine(doc);
                      }
                  */


                  Do.W("Please Enter the number of the Note that you would like to Open");
                   if(Get.IsNumber(Get.Input()) == false)
                  {
                        Get.Alert("Wrong input");
                        Get.Clear();
                        // this ensure that the list start to 0 again 
                        file = new List<string>();
                        // this ensure that the list indexer will start by 1 again 
                        CurrentFileNumber = 1;
                        // then will try to open files again  
                        OpenFile();  
                  }
                  // this change was added on the 03/04/2022
                  // the indexer has to be less 1 , because the indexer
                  // will start by 0 and for it to match it has to be one smaller 
                  int number = Get.Number - 1;

                  //Get.Box(file[0]);
                 // Get.Wait(Get.Number); 
                  // using(StreamReader reader = new StreamReader(list[]))
      using(StreamReader reader = new StreamReader(file[number]))
            { 
                string line = reader.ReadLine();
                while(line != null){
                    
                
                Do.Back_Blue(line);
                line = reader.ReadLine();
                }
            }
     Do.Wait();
      var goTo = new AppOptions();
        goTo.Option ();
    }
    
            public void DisplayExcistingFiles()
            {
                  string bank = "DataBank";
                  if (File.Exists(bank) == false)
                  {
                        Color.Yellow("No Files To Display");
                  }
                  else
                  {

                  }
            }
            // this method brings all the notes saved
            //But this one will be deprecated until i find a better
            // way to store all the notes 
            public void _DisplayExcistingFiles()
    {
      Do.Cle ();// clear the console 
      // creatting an input to find the file name 
      Do.W("All the notes Saved: ");

                  // here is where all the files are going to be display and listed

                  // here im trying to create a list of files that will be 
                  // interacted with later on  . 
                  //________________________________________________________
                  // this has to be corrected for the Final version
                  // since this needs to have the current directory and 
                  // also needs to add some details like the directory for 
                  // the notes
                  //________________________________________________________
                  string path = @"data/notes/";
                  string fileType = "*.txt";
          //       Get.Wait(path+fileType);
        string[] textlist = Directory.GetFiles(path,fileType);
                  try
                  {
                        if (textlist.Length <= 0)
                        {
                              Get.Write("no notes were found");
                              AppOptions.Final(); 
                        }
                        foreach (string fileList in textlist)
        {
          int fileNumber = CurrentFileNumber;//indexer for the file number 
          // keep only the name of the text 
           string textFile = fileList.Substring(path.Length);
           // add the file to the list
           file.Add(path+textFile);
           CurrentFileNumber++;// This will increment the number of the file
           Color.Green(fileNumber.ToString()+". "+textFile);
	         
	    
        }
        }catch{
            Do.Wrong("There Was an error while opening the files in the system.");
                        AppOptions.Final(); 
        }

    }

  }
}

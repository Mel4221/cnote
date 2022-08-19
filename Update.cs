using System;
using System.IO;
using QuickTools;
namespace cnote
{
  class Update
  {
        public void FileUpdate(string file)
        {   
            Get.Clear();
            // getting data from the current document 
            Console.WriteLine("Note Content");
            
            using(StreamReader reader = new StreamReader(file))
            { 
                string line = reader.ReadLine();
                while(line!=null){
                    
                
                Console.WriteLine(line);
                line = reader.ReadLine();
                }
            }
            Do.Yellow("Copy The Previus notes if you would like to keep the Previus Text");
            Do.Yellow("Remember the notes above are going to Be overrided");
            Do.Input();
             using(StreamWriter writer = new StreamWriter(file))
            {
                   writer.WriteLine(Do.Text);
            } 
            Color.Green("Updated Successfully!!!");
            Do.WaitTime(100);
            // this is supposed to direct you back to the options 
            var goTo =  new AppOptions();
            goTo.Option();
        }
       
  }
}


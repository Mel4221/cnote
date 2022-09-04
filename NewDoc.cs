using System;
using System.IO;
using QuickTools;
namespace cnote
{
  class NewDoc
  {
      
      /*
       *
       *
       *
       *
       *
       *
       *
       *
       *
       *
       * */
      
 
    public void DocFile()
    {
        Do.Cle(); 
            
        Console.WriteLine("Please Type The Name of the Note?");
       
          
            // validate the name of the file 
         if(Do.Check() == true)
         {

                        // here i need to validate that the 
                        // name type is a valid name for a document 
                        // maybe with Rejex validation it will be enough
        string path = "data/notes/";
        string doc = path+Do.Text+".txt";
        string notes;
        string onlyName = doc.Substring(doc.LastIndexOf("/") + 1);

                        if (File.Exists(doc))// if the file existe do not override it 
        {
            Console.WriteLine("This Note: '{0}'  already exist , would you like to override it",onlyName);
            // if the file existe and they want to override it lets direct the user 
            Do.W("1. Yes   2. No");
           Do.NumberInput();
            //answer to the question
                if(Do.Number ==1)
                    {
                         var process  = new Update();
                        //Console.WriteLine("Previus added");
                         process.FileUpdate(doc);
                    }if(Do.Number == 2 )
                    {
                        // go back to create a new document 
                        this.DocFile();
                    }
           
        }
        else
        {  
            Console.WriteLine("Type your notes Please");
             notes = Console.ReadLine();
            
            
            // FileStream to create the file
            using(FileStream fs = File.Create(doc)){}
                // StreamWriter to write the file 
                // Do not confuse FileSTream with StreamWriter
                // there  is not FileWriter nor FileReader;
            using(StreamWriter writer = new StreamWriter(doc))
            {
                   writer.WriteLine(notes);
            } 
            
            //when everything is done lets just direct 
            // you to the options 
            Do.Cle();
            Color.Green("Notes Saved Sucessfully!!! ");
            Get.Green("File Created : "+onlyName);
            Get.WaitTime(1000);
                              AppOptions.Final();
           
        }
            
            
         }else
         {
             Do.Back_Red("This is Not A Valid Name , Please try other name");
             Do.Wait();
             Do.Cle();
             this.DocFile();
         }
     
        
        
        
    }
    
    
    
  }
}


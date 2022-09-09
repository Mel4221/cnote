using System;
using QuickTools;


namespace cnote
{
  public class AppOptions
  {


            
    public void Option ()
    {
      Get.Clear();



                  Get.Title($"cnote version: {MainProgram.Version} ");
                  Options.SelectorL = " ";
                  Options.SelectorR = " ";
                  Options.Label = $"cnote version: {MainProgram.Version} \n" +
                  DateTime.Now;

            string[] options =
                       {
                             "1. New Note",
                             "2. Open Note",
                             "3. Delete Note",
                             "4. Delete All Notes",
                             "5. Exit"
                       }; 
                             
                 //var app = new Options();
                 // app.ClearOptions(); 
                  var option = new Options(options);
           
                

                  int answer = option.Pick()+1;
                  switch (answer)
	    {
	    case 1:		// new doc
	      var create = new NewDoc ();
	      create.DocFile ();
	      break;
                        
	      case 2:		//Open
	      var file = new Open ();
	      file.OpenFile ();
	      break;

	      case 3:		//Delete
	      var docFile = new Delete ();
	      docFile.DeleteFile ();
	      break;
                              case 4:
                                    // here im passing all the files to be deleted
                                    var listOf = new Open();
                                    DeleteAll.CollectFiles(); 
                                    break; 
	      case 5:		// exit
	      MainProgram.Exit ();
	      break;

	      default:
            //Do.
	//Yellow("Incorrect selection , please press one of the Fallowing ONLY");
	      //Do.Wait ();
	      // go back to options 
	      this.Option ();
	      break;
	    }
	}

    // whis method was added on the 03/04/2022
    // to improve flexsibi
    public static void Final ()
    {
      
      
     
      Do.W ("Options");
      Do.W ("1. Go Back");
      Do.W ("2. Exit");
      // this will give me the number for the anser

                  var goTo = new AppOptions();
      switch (Get.KeyNumber())
	{
	case 1:		// Go Back 
	 
	  goTo.Option ();
	  break;

	case 2:           //EXitcle

                              MainProgram.Exit();
                          break;

	default:
	 // Do.Yellow ("Not Valid Option Try Again Please");
	  //Get.WaitTime(1000);		// wait for a key being pressed 
	  Do.Cle ();            //clear de console 
                              goTo.Option();  

	  break;
	}
    }




  }
}

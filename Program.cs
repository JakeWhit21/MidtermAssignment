using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string file = "Tickets.txt";
string choice;

do
{
    //ask user a question
    Console.WriteLine("1) Read data from file.");
    Console.WriteLine("2) Create file from data.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        
    }
    else if (choice == "2")
    {
        // create file from data
        StreamWriter sw = new StreamWriter(file, append: true);
        for (int i = 0; i <= 7; i++)
        {
            // ask a question
            Console.WriteLine("Enter a ticket (Y/N)?");
            // input the response
            string resp = Console.ReadLine().ToUpper();
            //if the response is anything other than "Y", stop asking
            if(resp != "Y") { break; }
            //prompt for Ticket ID
            Console.WriteLine("Enter the Ticket ID: ");
            string id = Console.ReadLine();
            //prompt for Summary
            Console.WriteLine("Enter the Summary: ");
            string summary = Console.ReadLine();
            //prompt for Status
            Console.WriteLine("Enter the Status: ");
            string status = Console.ReadLine();
            //prompt for Priority
            Console.WriteLine("Enter the Priority: ");
            string priority = Console.ReadLine();
            //prompt for submitter
            Console.WriteLine("Enter the Submitter: ");
            string submitter = Console.ReadLine();
            //prompt for assigned
            Console.WriteLine("Enter who is it Assigned to: ");
            string assigned = Console.ReadLine();
            //prompt for watching
            Console.WriteLine("Enter who is Watching: ");
            string watching = Console.ReadLine();
            sw.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", id, summary, status, priority, submitter, assigned, watching);
            
        }
        sw.Close();
    }
} while (choice == "1" || choice == "2");


logger.Info("Program ended");
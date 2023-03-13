using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string bugFile = "BugTickets.txt";
string enhancementsFile = "EnhancementsTickets.txt";
string taskFile = "TaskTickets.txt";
string choice;
string ticketChoice;

TicketsFile ticketsFile = new TicketsFile();

do 
{
    //ask user a question
    Console.WriteLine("1) Read data from file.");
    Console.WriteLine("2) Create file from data or add ticket to file.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.WriteLine("Which ticket do you want to enter?");
        Console.WriteLine("1) Bug");
        Console.WriteLine("2) Enhancement");
        Console.WriteLine("3) Task");
        ticketChoice = Console.ReadLine();

        if(ticketChoice == "1")
        {
        ticketsFile.ReadBugTicket(bugFile);
        foreach (Bug b in ticketsFile.tickets)
        {
            Console.WriteLine(b.Display());
        }
        }

        
    }
    else if (choice == "2")
    {
        Console.WriteLine("Which ticket do you want to enter?");
        Console.WriteLine("1) Bug");
        Console.WriteLine("2) Enhancement");
        Console.WriteLine("3) Task");
        ticketChoice = Console.ReadLine();

        if (ticketChoice == "1")
        {
            Bug bug = new Bug();

            Console.WriteLine("Enter ticket ID");
        bug.ticketId = Console.ReadLine();

        Console.WriteLine("Enter the summary for the ticket: ");
        bug.summary = Console.ReadLine();

        Console.WriteLine("Enter status: ");
        bug.status = Console.ReadLine();

        Console.WriteLine("Enter priority: ");
        bug.priority = Console.ReadLine();

        Console.WriteLine("Enter submitter: ");
        bug.submitter = Console.ReadLine();

        Console.WriteLine("Enter person assigned to: ");
        bug.assigned = Console.ReadLine();

        Console.WriteLine("Enter person watching: ");
        bug.watching = Console.ReadLine();

        Console.WriteLine("Enter severity: ");
        bug.severity = Console.ReadLine();

        ticketsFile.AddBug(bug);
        }


        // Ticket ticket = new Ticket();

        // Console.WriteLine("Enter ticket ID");
        // ticket.ticketId = Console.ReadLine();

        // Console.WriteLine("Enter the summary for the ticket: ");
        // ticket.summary = Console.ReadLine();

        // Console.WriteLine("Enter status: ");
        // ticket.status = Console.ReadLine();

        // Console.WriteLine("Enter priority: ");
        // ticket.priority = Console.ReadLine();

        // Console.WriteLine("Enter submitter: ");
        // ticket.submitter = Console.ReadLine();

        // Console.WriteLine("Enter person assigned to: ");
        // ticket.assigned = Console.ReadLine();

        // Console.WriteLine("Enter person watching: ");
        // ticket.watching = Console.ReadLine();

        // ticketsFile.AddTicket(ticket);
    }
} while (choice == "1" || choice == "2");


logger.Info("Program ended");
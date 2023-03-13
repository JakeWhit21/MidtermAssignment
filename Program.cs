using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string file = "Tickets.txt";
string choice;

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
        ticketsFile.ReadTicket(file);
        foreach (Ticket t in ticketsFile.tickets)
        {
            Console.WriteLine(t.Display());
        }
    }
    else if (choice == "2")
    {
        string ticketChoice;

        Console.WriteLine("Which ticket do you want to enter?");
        Console.WriteLine("1) Bug");
        Console.WriteLine("2) Enhancement");
        Console.WriteLine("3) Task");
        ticketChoice = Console.ReadLine();

        if (ticketChoice == "1")
        {
            
        }


        Ticket ticket = new Ticket();

        Console.WriteLine("Enter ticket ID");
        ticket.ticketId = Console.ReadLine();

        Console.WriteLine("Enter the summary for the ticket: ");
        ticket.summary = Console.ReadLine();

        Console.WriteLine("Enter status: ");
        ticket.status = Console.ReadLine();

        Console.WriteLine("Enter priority: ");
        ticket.priority = Console.ReadLine();

        Console.WriteLine("Enter submitter: ");
        ticket.submitter = Console.ReadLine();

        Console.WriteLine("Enter person assigned to: ");
        ticket.assigned = Console.ReadLine();

        Console.WriteLine("Enter person watching: ");
        ticket.watching = Console.ReadLine();

        ticketsFile.AddTicket(ticket);
    }
} while (choice == "1" || choice == "2");


logger.Info("Program ended");
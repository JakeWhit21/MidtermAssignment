using NLog;

public class TicketsFile
{
    public string filePath { get; set; }
    public List<Ticket> tickets { get; set; }

    public TicketsFile()
    {
        
    }

    public void ReadBugTicket(string ticketFile)
    {

        tickets = new List<Ticket>();
        // read data from file
        if (File.Exists(ticketFile))
        {
            // read data from file
            StreamReader sr = new StreamReader(ticketFile);
            while (!sr.EndOfStream)
            {
                Bug bugTicket = new Bug();
                string line = sr.ReadLine();
                //convert string to array
                string[] ticketDetails = line.Split('|');
                //display array data
                //Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                bugTicket.ticketId = ticketDetails[0];
                bugTicket.summary = ticketDetails[1];
                bugTicket.status = ticketDetails[2];
                bugTicket.priority = ticketDetails[3];
                bugTicket.submitter = ticketDetails[4];
                bugTicket.assigned = ticketDetails[5];
                bugTicket.watching = ticketDetails[6];
                bugTicket.severity = ticketDetails[7];

                tickets.Add(bugTicket);
            }
        
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }

    public void ReadEnhancementTicket(string ticketFile) 
    {
        tickets = new List<Ticket>();
        // read data from file
        if (File.Exists(ticketFile))
        {
            // read data from file
            StreamReader sr = new StreamReader(ticketFile);
            while (!sr.EndOfStream)
            {
                Enhancement enhancementTicket = new Enhancement();
                string line = sr.ReadLine();
                //convert string to array
                string[] ticketDetails = line.Split('|');
                //display array data
                //Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                enhancementTicket.ticketId = ticketDetails[0];
                enhancementTicket.summary = ticketDetails[1];
                enhancementTicket.status = ticketDetails[2];
                enhancementTicket.priority = ticketDetails[3];
                enhancementTicket.submitter = ticketDetails[4];
                enhancementTicket.assigned = ticketDetails[5];
                enhancementTicket.watching = ticketDetails[6];
                enhancementTicket.software = ticketDetails[7];
                enhancementTicket.cost = ticketDetails[8];
                enhancementTicket.reason = ticketDetails[9];
                enhancementTicket.estimate = ticketDetails[10];

                tickets.Add(enhancementTicket);
            }
        
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }

    public void ReadTaskTicket(string ticketFile)
    {
        tickets = new List<Ticket>();
        // read data from file
        if (File.Exists(ticketFile))
        {
            // read data from file
            StreamReader sr = new StreamReader(ticketFile);
            while (!sr.EndOfStream)
            {
                Task taskTicket = new Task();
                string line = sr.ReadLine();
                //convert string to array
                string[] ticketDetails = line.Split('|');
                //display array data
                //Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                taskTicket.ticketId = ticketDetails[0];
                taskTicket.summary = ticketDetails[1];
                taskTicket.status = ticketDetails[2];
                taskTicket.priority = ticketDetails[3];
                taskTicket.submitter = ticketDetails[4];
                taskTicket.assigned = ticketDetails[5];
                taskTicket.watching = ticketDetails[6];
                taskTicket.projectName = ticketDetails[7];
                taskTicket.dueDate = ticketDetails[8];

                tickets.Add(taskTicket);
            }
        
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }

    public void AddBug(Bug bug)
    {
        filePath = "BugTickets.txt";
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine($"{bug.ticketId}|{bug.summary}|{bug.status}|{bug.priority}|{bug.submitter}|{bug.assigned}|{bug.watching}|{bug.severity}");
        sw.Close();
    }

    public void AddEnhancement(Enhancement enhancement)
    {
        filePath = "EnhancementTickets.txt";
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine($"{enhancement.ticketId}|{enhancement.summary}|{enhancement.status}|{enhancement.priority}|{enhancement.submitter}|{enhancement.assigned}|{enhancement.watching}|{enhancement.software}|{enhancement.cost}|{enhancement.reason}|{enhancement.estimate}");
        sw.Close();
    }

    public void AddTask(Task task)
    {
        filePath = "TaskTickets.txt";
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine($"{task.ticketId}|{task.summary}|{task.status}|{task.priority}|{task.submitter}|{task.assigned}|{task.watching}|{task.projectName}|{task.dueDate}");
        sw.Close();
    }
}
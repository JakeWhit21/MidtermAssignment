using NLog;

public class TicketsFile
{
    public string filePath { get; set; }
    public List<Ticket> tickets { get; set; }

    public TicketsFile()
    {
        
    }

    public void ReadTicket(string ticketFile)
    {
        filePath = ticketFile;

        tickets = new List<Ticket>();
        // read data from file
        if (File.Exists(ticketFile))
        {
            // read data from file
            StreamReader sr = new StreamReader(ticketFile);
            while (!sr.EndOfStream)
            {
                Ticket ticket = new Ticket();
                string line = sr.ReadLine();
                //convert string to array
                string[] ticketDetails = line.Split('|');
                //display array data
                //Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                ticket.ticketId = ticketDetails[0];
                ticket.summary = ticketDetails[1];
                ticket.status = ticketDetails[2];
                ticket.priority = ticketDetails[3];
                ticket.submitter = ticketDetails[4];
                ticket.assigned = ticketDetails[5];
                ticket.watching = ticketDetails[6];

                tickets.Add(ticket);
            }
        
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }

    public void AddTicket(Ticket ticket)
    {
        filePath = "Tickets.txt";
        StreamWriter sw = new StreamWriter(filePath, true);
        sw.WriteLine($"{ticket.ticketId}|{ticket.summary}|{ticket.status}|{ticket.priority}|{ticket.submitter}|{ticket.assigned}|{ticket.watching}");
        sw.Close();
    }
}
using System;
using System.IO;

namespace TicketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Ticket.csv";
            string choice;
            StreamWriter sw = new StreamWriter(file, true);
            sw.Close();
            do
            {
                Console.Clear();
                Console.WriteLine("1) View current tickets");
                Console.WriteLine("2) Submit new ticket");
                Console.WriteLine("3) Remove ticket");
                //input
                choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        if(File.Exists(file))
                        {
                            Console.Clear();
                            StreamReader sr = new StreamReader(file);
                            while(!sr.EndOfStream)
                            {
                                //Pull File and Read Line
                                string line = sr.ReadLine();
                                //Split Line by Comma
                                string[] arr = line.Split(",");
                                Console.WriteLine("---------------------------------");
                                Console.WriteLine("{0}) {1}\nStatus) {2}\nPriority) {3}\nSubmitter) {4}\nAssigned) {5}\nWatching) {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                            }
                            sr.Close();
                        }
                        else
                        {
                            Console.WriteLine("No Tickets Currently Exist");
                        }
                    break;
                    case "2":
                        string[] newTicket = new string[7];
                        //Read the file and pull each individual ticket
                        int i = 1;
                        if(File.Exists(file))
                        {
                            StreamReader sr = new StreamReader(file);
                            while(!sr.EndOfStream)
                            {
                                sr.ReadLine();
                                i++;
                            }
                            sr.Close();
                        }
                        //Makes ticket num next in line
                        newTicket[0] = i.ToString();
                        
                        Console.WriteLine("Enter ticket summary: ");
                        newTicket[1] = Console.ReadLine();

                        Console.WriteLine("Ticket status: ");
                        newTicket[2] = Console.ReadLine();

                        Console.WriteLine("Ticket priority: ");
                        newTicket[3] = Console.ReadLine();

                        Console.WriteLine("Submitted by: ");
                        newTicket[4] = Console.ReadLine();

                        Console.WriteLine("Assigned to: ");
                        newTicket[5] = Console.ReadLine();

                        Console.WriteLine("Watched by: ");
                        newTicket[6] = Console.ReadLine();
                        //Adding new ticket to file
                        sw = new StreamWriter(file, true);
                        if(i != 1)
                        {
                            sw.WriteLine();
                        }
                        sw.Write(newTicket[0]);
                        for(int x = 1; x < 7; x++) 
                        {
                            sw.Write(",{0}",newTicket[x]);
                        }
                        sw.Close();
                    break;
                    case "3":
                        if(File.Exists(file))
                        {
                            Console.WriteLine("Enter ticket ID to remove: ");
                            string ticketID = Console.ReadLine();

                            string[] tickets = new string[999];
                            int totalTickets = 0;
                            int removedTicket = 0;
                            //Reads through the current list of tickets, and identifies which ticket in the array of tickets that will be removed
                            StreamReader sr = new StreamReader(file);
                            while(!sr.EndOfStream)
                            {
                                tickets[totalTickets] = sr.ReadLine();
                                string[] arr = tickets[totalTickets].Split(',');

                                if(arr[0] == ticketID) removedTicket = totalTickets;

                                totalTickets++;
                            }
                            sr.Close();
                            //Writes the tickets back into the file, just excluding the removed ticket
                            sw = new StreamWriter(file);
                            for(int x = 0; x < totalTickets; x++)
                            {
                                if(x!=removedTicket)
                                {
                                    sw.WriteLine(tickets[x]);
                                }
                            }
                            sw.Close();
                        }
                    break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            while(choice == "1" || choice == "2" || choice == "3");
        }
    }
}

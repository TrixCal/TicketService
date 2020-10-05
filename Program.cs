using System;
using System.IO;
using System.Collections.Generic;
using NLog.Web;

namespace TicketService
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Info("Program started");
            //Initalize
            string file = "Ticket.csv";
            string choice;
            //Creates a ticket list from file to use during program
            List<Ticket> tickets = new List<Ticket>();
            if(File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(",");
                    tickets.Add(new Ticket(arr));
                }
            }
            else
            {
                logger.Warn("File does not exist. {file}");
            }
            do
            {
                Console.Clear();
                Console.WriteLine("1) View current tickets");
                Console.WriteLine("2) Submit new ticket");
                Console.WriteLine("3) Remove ticket");
                //input
                choice = Console.ReadLine();
                logger.Info("Program ended");
                switch(choice)
                {
                    case "1":
                        if(tickets.Count > 0)
                        {
                            Console.Clear();
                            foreach(Ticket t in tickets)
                            {
                                t.Display();
                                Console.WriteLine("----------------------");
                            }
                        }
                        else
                        {
                            logger.Warn("No Tickets Available");
                        }
                    break;
                    case "2":
                        string[] newTicket = new string[7];
                        //Makes ticket num next in line
                        newTicket[0] = (tickets.Count + 1).ToString();
                        
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
                        //Add new ticket to List
                        tickets.Add(new Ticket(newTicket));
                        logger.Info($"New ticket added. Id:{newTicket[0]}");                 
                    break;
                    case "3":
                        if(tickets.Count > 0)
                        {
                            Console.WriteLine("Enter ticket ID to remove: ");
                            string ticketID = Console.ReadLine();
                            logger.Info($"Ticket to remove: {ticketID}");
                            foreach(Ticket ticket in tickets)
                            {
                                if(ticket.ticketID == Int32.Parse(ticketID))
                                {
                                    tickets.Remove(ticket);
                                    logger.Info($"Ticket Removed. {ticket}");
                                }
                            }
                        }
                        else
                        {
                            logger.Warn("No Tickets Available");
                        }
                    break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            while(choice == "1" || choice == "2" || choice == "3");
            logger.Info("Program ended");
        }
    }
}

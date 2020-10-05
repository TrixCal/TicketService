using System;
using System.IO;
using System.Linq;
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

            TicketFile ticketFile = new TicketFile(Directory.GetCurrentDirectory() + "\\Ticket.csv");
            string choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1) View current tickets");
                Console.WriteLine("2) Submit new ticket");
                Console.WriteLine("3) Remove ticket");
                //input
                choice = Console.ReadLine();
                logger.Info("Program ended");
                switch(choice)
                {
                    case "1":
                        if(ticketFile.tickets.Count > 0)
                        {
                            Console.Clear();
                            foreach(Ticket t in ticketFile.tickets)
                            {
                                Console.WriteLine("----------------------");
                                Console.WriteLine(t.Display());
                            }
                        }
                        else
                        {
                            logger.Warn("No Tickets Available");
                        }
                    break;
                    case "2":
                        string[] newTicket = new string[6];

                        Console.WriteLine("Enter ticket summary: ");
                        newTicket[0] = Console.ReadLine();

                        Console.WriteLine("Ticket status: ");
                        newTicket[1] = Console.ReadLine();

                        Console.WriteLine("Ticket priority: ");
                        newTicket[2] = Console.ReadLine();

                        Console.WriteLine("Submitted by: ");
                        newTicket[3] = Console.ReadLine();

                        Console.WriteLine("Assigned to: ");
                        newTicket[4] = Console.ReadLine();

                        Console.WriteLine("Watched by: ");
                        newTicket[5] = Console.ReadLine();

                        ticketFile.AddTicket(new Ticket(newTicket));               
                    break;
                    case "3":
                        if(ticketFile.tickets.Count > 0)
                        {
                            Console.WriteLine("Enter ticket ID to remove: ");
                            int ticketID;
                            if(!int.TryParse(Console.ReadLine(), out ticketID))
                            {
                                logger.Error("ticketID not int");
                            }
                            ticketFile.RemoveTicket(ticketID);
                        }
                        else
                        {
                            logger.Warn("No Tickets Available");
                        }
                    break;
                }
            }
            while(choice == "1" || choice == "2" || choice == "3");
        }
    }
}

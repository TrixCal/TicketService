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
                        if(ticketFile.bugs.Count > 0)
                        {
                            Console.Clear();
                            foreach(Bug t in ticketFile.bugs)
                            {
                                Console.WriteLine("----------------------");
                                Console.WriteLine(t.Display());
                            }
                        }
                        else
                        {
                            logger.Warn("No Bugs Available");
                        }
                        if(ticketFile.enhancements.Count > 0)
                        {
                            Console.Clear();
                            foreach(Enhancement t in ticketFile.enhancements)
                            {
                                Console.WriteLine("----------------------");
                                Console.WriteLine(t.Display());
                            }
                        }
                        else
                        {
                            logger.Warn("No Enhancement Available");
                        }
                        if(ticketFile.tasks.Count > 0)
                        {
                            Console.Clear();
                            foreach(Task t in ticketFile.tasks)
                            {
                                Console.WriteLine("----------------------");
                                Console.WriteLine(t.Display());
                            }
                        }
                        else
                        {
                            logger.Warn("No Tasks Available");
                        }
                    break;
                    case "2":
                        Console.WriteLine("1)Bugs\n2)Enhancments\n3)Tasks");
                        Console.WriteLine("Select Ticket Group (Enter #):");
                        string submitChoice = Console.ReadLine();
                        if(submitChoice == "1"){
                            var ticket = new Bug();
                            ticket.TicketSubmit();
                            ticketFile.AddTicket(ticket);
                        }
                        else if(submitChoice == "2"){
                            var ticket = new Enhancement();
                            ticket.TicketSubmit();
                            ticketFile.AddTicket(ticket);
                        }
                        else if(submitChoice == "3"){
                            var ticket = new Task();
                            ticket.TicketSubmit();
                            ticketFile.AddTicket(ticket);
                        }
                    break;
                    case "3":
                        Console.WriteLine("1)Bugs\n2)Enhancments\n3)Tasks");
                        Console.WriteLine("Select Ticket Group (Enter #):");
                        string group = Console.ReadLine();
                        switch(group){
                            case "1":
                            if(ticketFile.bugs.Count > 0)
                            {
                                Console.WriteLine("Enter ticket ID to remove: ");
                                int ticketID;
                                if(!int.TryParse(Console.ReadLine(), out ticketID))
                                {
                                    logger.Error("ticketID not int");
                                }
                                Bug ticket = new Bug();
                                ticket.ticketID = ticketID;
                                ticketFile.RemoveTicket(ticket);
                            }
                            else
                            {
                                logger.Warn("No Bugs Available");
                            }
                            break;
                            case "2":
                            if(ticketFile.enhancements.Count > 0)
                            {
                                Console.WriteLine("Enter ticket ID to remove: ");
                                int ticketID;
                                if(!int.TryParse(Console.ReadLine(), out ticketID))
                                {
                                    logger.Error("ticketID not int");
                                }
                                Enhancement ticket = new Enhancement();
                                ticket.ticketID = ticketID;
                                ticketFile.RemoveTicket(ticket);
                            }
                            else
                            {
                                logger.Warn("No Enhancements Available");
                            }
                            break;
                            case "3":
                            if(ticketFile.tasks.Count > 0)
                            {
                                Console.WriteLine("Enter ticket ID to remove: ");
                                int ticketID;
                                if(!int.TryParse(Console.ReadLine(), out ticketID))
                                {
                                    logger.Error("ticketID not int");
                                }
                                Task ticket = new Task();
                                ticket.ticketID = ticketID;
                                ticketFile.RemoveTicket(ticket);
                            }
                            else
                            {
                                logger.Warn("No Tasks Available");
                            }
                            break;
                        }
                    break;
                }
            }
            while(choice == "1" || choice == "2" || choice == "3");
        }
    }
}

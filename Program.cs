﻿using System;
using System.IO;
using System.Collections.Generic;

namespace TicketService
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Ticket.csv";
            string choice;
            //Creates a ticket list from file to use during program
            List<Ticket> tickets = new List<Ticket>();
            StreamReader sr = new StreamReader(file);
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(",");
                tickets.Add(new Ticket(arr));
            }
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
                        if(tickets.Count > 0)
                        {
                            Console.Clear();
                            foreach(Ticket t in tickets)
                            {
                                t.Display();
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Tickets Currently Exist");
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
                    break;
                    case "3":
                        if(tickets.Count > 0)
                        {
                            Console.WriteLine("Enter ticket ID to remove: ");
                            string ticketID = Console.ReadLine();

                            foreach(Ticket ticket in tickets)
                            {
                                if(ticket.ticketID == Int32.Parse(ticketID))
                                {
                                    tickets.Remove(ticket);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Tickets Currently Exist");
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

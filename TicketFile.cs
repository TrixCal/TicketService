using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NLog.Web;

namespace TicketService
{
    public class TicketFile
    {
        public string filePath { get; set; }
        public List<Ticket> tickets { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        public TicketFile(string ticketFilePath)
        {
            filePath = ticketFilePath;
            tickets = new List<Ticket>();
            //Add tickets from data file to list
            try
            {
                StreamReader sr = new StreamReader(filePath);
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(",");
                    //Add ticket through data in arr
                    if(arr.Count() == 8)
                    {

                    }
                    else if(arr.Count() == 11)
                    {

                    }
                    else if(arr.Count() == 9)
                    {

                    }
                }
                sr.Close();
                logger.Info($"Tickets in file {tickets.Count}.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        public void AddTicket(string type, Ticket ticket)
        {
            try
            {
                //Generate ticket ID
                ticket.ticketID = tickets.Any() ? tickets.Max(m => m.ticketID) + 1 : 1;
                //Add ticket to file
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{ticket.ticketID},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|", ticket.watching)}");
                sw.Close();
                //Add ticket to list
                tickets.Add(ticket);
                logger.Info($"Ticket ID {ticket.ticketID} Added.");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        public void RemoveTicket(int ticketId)
        {
            //Removes ticket from List
            for(int i = 0; i < tickets.Count; i++)
            {
                if(tickets[i].ticketID == ticketId) tickets.RemoveAt(i);
            }
            logger.Info($"Ticket ID {ticketId} Removed.");
            //Rewrites file based on new list
            StreamWriter sw = new StreamWriter(filePath);
            foreach(Ticket ticket in tickets)
            {
                sw.WriteLine($"{ticket.ticketID},{ticket.summary},{ticket.status},{ticket.priority},{ticket.submitter},{ticket.assigned},{string.Join("|", ticket.watching)}");
            }
            sw.Close();
        }
    }
}
using Microsoft.Win32;

using practice.Database;
using practice.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Parser
{
    public class Pars
    {
        public static void ParseEvent()
        {
            var path = @"F:\ПБ-41\Практика\Задание к УП03\Ресурсы\Мероприятие.csv";
            if (!File.Exists(path))
            {
                return;
            }

            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            List<Ivent> list = new List<Ivent>();
            foreach (var line in lines)
            {
                string[] temp = line.Split(';');
                list.Add(
                    new Ivent()
                    {
                        IventName = temp[0],
                        DateBegin = DateOnly.Parse(temp[1]),
                        DurationDays = Int32.Parse(temp[2]),
                        Winner = temp[3],
                        Image = temp[4]
                    });
                
            }

            using (var con = new PracticeContext())
            {
                con.Ivent.AddRange(list);
                con.SaveChanges();
            }
        }

        public static void ParseAction()
        {
            var path = @"F:\ПБ-41\Практика\Задание к УП03\Ресурсы\Активности_import.csv";
            if (!File.Exists(path))
            {
                return;
            }

            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            List<Models.Action> list = new List<Models.Action>();
            foreach (var line in lines)
            {
                string[] temp = line.Split(';');
                list.Add(
                    new Models.Action()
                    {
                        ActionName = temp[0],
                        DayNumber = Int32.Parse(temp[1]),
                        TimeBegin = TimeOnly.Parse(temp[2]),
                        OrganizerID = Int32.Parse(temp[3]),
                        ModeratorName = temp[4],
                        IdIvent = Int32.Parse(temp[5])
                    });
                
            }

            using (var con = new PracticeContext())
            {
                con.Action.AddRange(list);
                con.SaveChanges();
            }
        }
        
        public static void ParseActivitiesInformationSecurity()
        {
            var path = @"F:\ПБ-41\Практика\Задание к УП03\Ресурсы\Мероприятия_Информационная безопасность.csv";
            if (!File.Exists(path))
            {
                return;
            }

            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            List<ActivitiesInformationSecurity> list = new List<ActivitiesInformationSecurity>();
            foreach (var line in lines)
            {
                string[] temp = line.Split(';');
                list.Add(
                    new ActivitiesInformationSecurity()
                    {
                        Ivent = temp[0],
                        Data = DateOnly.Parse(temp[1]),
                        Days = Int32.Parse(temp[2]),
                        City = Int32.Parse(temp[3])
                    });
                
            }

            using (var con = new PracticeContext())
            {
                con.ActivitiesInformationSecurity.AddRange(list);
                con.SaveChanges();
            }
        }
        
        public static void ParseCity()
        {
            var path = @"F:\ПБ-41\Практика\Задание к УП03\Ресурсы\Город_import.csv";
            if (!File.Exists(path))
            {
                return;
            }

            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            List<City> list = new List<City>();
            foreach (var line in lines)
            {
                string[] temp = line.Split(';');
                list.Add(
                    new City()
                    {
                        CityName = temp[0]
                    });
                
            }

            using (var con = new PracticeContext())
            {
                con.City.AddRange(list);
                con.SaveChanges();
            }
        }
        
        public static void ParseActionJury()
        {
            var path = @"F:\ПБ-41\Практика\Задание к УП03\Ресурсы\МероприятияЖюри.csv";
            if (!File.Exists(path))
            {
                return;
            }

            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            List<ActionJury> list = new List<ActionJury>();
            foreach (var line in lines)
            {
                string[] temp = line.Split(';');
                list.Add(
                    new ActionJury()
                    {
                        JuryID = Int32.Parse(temp[0]),
                        ActionId = Int32.Parse(temp[1])
                    });
                
            }

            using (var con = new PracticeContext())
            {
                con.ActionJury.AddRange(list);
                con.SaveChanges();
            }
        }
        
        public static void ParseCountry()
        {
            var path = @"F:\ПБ-41\Практика\Задание к УП03\Ресурсы\Cтраны_import.csv";
            if (!File.Exists(path))
            {
                return;
            }

            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            List<Country> list = new List<Country>();
            foreach (var line in lines)
            {
                string[] temp = line.Split(';');
                list.Add(
                    new Country()
                    {
                        CountryName = temp[0],
                        CountryEngName = temp[1],
                        Code = temp[2],
                        CodeNumber = Int32.Parse(temp[3])
                    });
                
            }

            using (var con = new PracticeContext())
            {
                con.Countries.AddRange(list);
                con.SaveChanges();
            }
        }
        
        public static void ParseDirection()
        {
            var path = @"F:\ПБ-41\Практика\Задание к УП03\Ресурсы\Направление.csv";
            if (!File.Exists(path))
            {
                return;
            }

            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            List<Direction> list = new List<Direction>();
            foreach (var line in lines)
            {
                string[] temp = line.Split(';');
                list.Add(
                    new Direction()
                    {
                        DirectionName = temp[0]
                    });
                
            }

            using (var con = new PracticeContext())
            {
                con.Directions.AddRange(list);
                con.SaveChanges();
            }
        }
        
        public static void ParseJury()
        {
            var path = @"F:\ПБ-41\Практика\Задание к УП03\Ресурсы\жюри-4.csv";
            if (!File.Exists(path))
            {
                return;
            }

            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            List<Jury> list = new List<Jury>();
            foreach (var line in lines)
            {
                string[] temp = line.Split(';');
                list.Add(
                    new Jury()
                    {
                        FIO = temp[0],
                        Mail = temp[1],
                        gender = Char.Parse(temp[2]),
                        Birthday = DateOnly.Parse(temp[3]),
                        Country = Int32.Parse(temp[4]),
                        Phone = temp[5],
                        DirectionId = Int32.Parse(temp[6]),
                        Action = temp[7],
                        Password = temp[8],
                        Photo = temp[9],
                        IdNumber = Int32.Parse(temp[10])
                    });
                
            }

            using (var con = new PracticeContext())
            {
                con.Jury.AddRange(list);
                con.SaveChanges();
            }
        }
        
        public static void ParseModerator()
        {
            var path = @"F:\ПБ-41\Практика\Задание к УП03\Ресурсы\Модераторы.csv";
            if (!File.Exists(path))
            {
                return;
            }

            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            List<Moderator> list = new List<Moderator>();
            foreach (var line in lines)
            {
                string[] temp = line.Split(';');
                list.Add(
                    new Moderator()
                    {
                        FIO = temp[0],
                        Gender = Char.Parse(temp[1]),
                        Mail = temp[2],
                        Birthday = DateOnly.Parse(temp[3]),
                        CountryID = Int32.Parse(temp[4]),
                        Phone = temp[5],
                        DirectionId = Int32.Parse(temp[6]),
                        Action = temp[7],
                        Password = temp[8],
                        Photo = temp[9]
                    });
                
            }

            using (var con = new PracticeContext())
            {
                con.Moderators.AddRange(list);
                con.SaveChanges();
            }
        }
        
        public static void ParseOrganizers()
        {
            var path = @"F:\ПБ-41\Практика\Задание к УП03\Ресурсы\организаторы.csv";
            if (!File.Exists(path))
            {
                return;
            }

            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            List<Organizers> list = new List<Organizers>();
            foreach (var line in lines)
            {
                string[] temp = line.Split(';');
                list.Add(
                    new Organizers()
                    {
                        Mail = temp[0],
                        Birthday = DateOnly.Parse(temp[1]),
                        CountryID = Int32.Parse(temp[2]),
                        Phone = temp[3],
                        Password = temp[4],
                        Photo = temp[5],
                        Gender = Char.Parse(temp[6]),
                        IdNumber = Int32.Parse(temp[7])
                    });
                
            }

            using (var con = new PracticeContext())
            {
                con.Organizers.AddRange(list);
                con.SaveChanges();
            }
        }
        
        public static void ParseParticipant()
        {
            var path = @"F:\ПБ-41\Практика\Задание к УП03\Ресурсы\участники-4.csv";
            if (!File.Exists(path))
            {
                return;
            }

            var lines = File.ReadAllLines(path).ToList();
            lines.RemoveAt(0);
            List<Participant> list = new List<Participant>();
            foreach (var line in lines)
            {
                string[] temp = line.Split(';');
                list.Add(
                    new Participant()
                    {
                        Mail = temp[0],
                        Birthday = DateOnly.Parse(temp[1]),
                        CountryID = Int32.Parse(temp[2]),
                        Phone = temp[3],
                        Password = temp[4],
                        Photo = temp[5],
                        Gender = Char.Parse(temp[6]),
                        IdNumber = Int32.Parse(temp[7])
                    });
                
            }

            using (var con = new PracticeContext())
            {
                con.Participants.AddRange(list);
                con.SaveChanges();
            }
        }
    }
}

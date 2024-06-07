using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidBootcamp.ConsoleApp.Domain
{
    public class Lecturer : Person,ICrud,IStorable,IPrintable
    {
        public string? NIK { get; set; }
        public string? RoomNumber { get; set; }

        public override string GetFullName()
        {
            throw new NotImplementedException();
        }

        public override string GetInfo()
        {
            return $"Name: {FullName}, Address: {Address}, Phone: {PhoneNumber}, NIK: {NIK}, Room Number: {RoomNumber}";
        }

        public override void Load()
        {
            Console.WriteLine("Load from Lecturer");
        }

        public override void Save()
        {
            Console.WriteLine("Save from Lecturer");
        }
        public void Insert()
        {
            Console.WriteLine("Insert from Lecturer");
        }

        public void Update() { throw new NotImplementedException(); }

        public void Delete() { throw new NotImplementedException(); }
        public void Select() { throw new NotImplementedException(); }
        public void Store() { Console.WriteLine("Store from Lecturer"); }
        public void Print() { Console.WriteLine("Print from Lecturer"); }
    }
}
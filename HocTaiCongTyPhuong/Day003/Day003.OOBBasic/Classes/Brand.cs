using Day003.OOBBasic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day003.OOBBasic.Classes
{
    class Brand : Ishowable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }


        public List<Service> services;
        public List<Service> Services {
            get
            {
                if (services == null)
                {
                    services = new List<Service>();
                    return services;
                }
                else
                {
                    return services;
                }
            }
            set
            {
                services = value;
            }
        }

        public List<Stores> store;
        public List<Stores> Stores
        {
            get
            {
                if (store == null)
                {
                    store = new List<Stores>();
                    return store;
                }
                else
                {
                    return store;
                }
            }
            set
            {
                store = value;
            }
        }
        public Brand(int id , string name , string address, List<Service> service, List<Stores> stores)
        {
            Id = id;
            Name = name;
            Address = address;
            Services = service;
            Stores = stores;
        }

        public Brand()
        {
        }

        public void ShowInformation()
        {
            Console.WriteLine($"Name: {Name} - Address: {Address}");
            foreach (var item in Services)
            {
                item.ShowInformation();
            }
            foreach (var item in Stores)
            {
                item.ShowInformation();
            }
        }
    }
}

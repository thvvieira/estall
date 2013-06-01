using PCLEStall.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLEStall.Models;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            PCLEStall.ServiceConsumer.ServiceConsumer consumer = new PCLEStall.ServiceConsumer.ServiceConsumer("http://estallservices.azurewebsites.net/");
            ObservableCollection<Profile> result = consumer.GetProfile();

            result.ToList<Profile>().ForEach(profile => Console.WriteLine(string.Concat(profile.Handle, " - ", profile.Nome)));
            Console.ReadLine();
        }
    }
}

using AvicomTestTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvicomTestTask.Services
{
    internal interface IUserDialog
    {
        bool Edit(Client client, ObservableCollection<Client> clients, ObservableCollection<Manager> managers, ObservableCollection<Status> statuses);
    }
}

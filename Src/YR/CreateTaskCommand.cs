using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YandexTrains.ViewModels;

namespace YandexTrains
{
    class CreateTaskCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            /*
            if (parameter is MainViewModel viewModel)
            {
                return !String.IsNullOrWhiteSpace(viewModel.NewTaskName);

            }
            else
            {
                return false;
            }
            */
            return true;
        }

        public async void Execute(object parameter)
        {
            if (parameter is MainViewModel viewModel)
            {
                List<Model.Route> RouteData = await Helper.Helper.GetRoutesList("Lat", "Lng");

                if (RouteData != null)
                {
                    foreach (Model.Route route in RouteData)
                    {
                        viewModel.Tasks.Add(new TaskViewModel()
                        {
                            IsComplete = false,
                            TaskName = $"{route.depart},{route.title},{route.arrival}"
                        });
                        //viewModel.NewTaskName = ""; // reset new task name (for testing)
                        CanExecuteChanged?.Invoke(this, EventArgs.Empty);

                    }
                }               
            }
            else 
            {
                return;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}

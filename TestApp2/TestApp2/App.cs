using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApp2.infrastructure;
using TestApp2.model;
using Xamarin.Forms;

namespace TestApp2
{
    public class App : Application
    {
        public App()
        {
            //set up datebase
            CreateDatabase();


            MainPage =  new NavigationPage(  new Startpage());
            
        }

        public void CreateDatabase()
        {
           var  database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Task>();
            database.CreateTable<TaskList>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

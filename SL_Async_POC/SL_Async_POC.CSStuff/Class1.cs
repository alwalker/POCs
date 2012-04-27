using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Data.Services.Client;
using System.Collections.Generic;
using SL_Async_POC.CSStuff.EntityFeedServiceReference;

namespace SL_Async_POC.CSStuff
{
    public static class Class1
    {
        public static Task<List<T>> LoadAsync<T>(this DataServiceCollection<T> collection, DataServiceQuery<T> query)
        {
            collection.LoadCompleted += (sender, e) =>
            {
                var binding = (DataServiceCollection<T>)sender;
                var results = new List<T>();

                if (e.Error == null)
                {
                    // Consume a data feed that contains paged results.
                    if (binding.Continuation != null)
                    {
                        // If there is a continuation token, 
                        // load the next page of results.
                        binding.LoadNextPartialSetAsync();
                    }
                    else
                    {
                        foreach (T thing in binding)
                        {
                            results.Add(thing);
                        }

                        return new Task<List<T>>(() => results);
                    }
                }
            };
        }

        //public static void test()
        //{
        //    // Instantiate the context based on the data service URI.
        //    var context = new EntityFeedServiceReference.DB_Conn(new Uri("blarg"));

        //    // Instantiate the binding collection.
        //    var paygrades = new DataServiceCollection<EntityFeedServiceReference.PayGrade>();
        //    var query = context.PayGrades;
        //    context.BeginExecute(query, context).con
        //}
    }
}

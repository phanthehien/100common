using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using OneHundredCommonThings.Model;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = AppData.FromJson(jsonString);
//
// For POCOs visit quicktype.io?poco
//
namespace OneHundredCommonThings
{
    public class BaseDataService<T> where T : BaseModel, new() {

        private CancellationToken token;
		private SQLiteConnection database;
		private static object collisionLock = new object();
        private string _baseServiceUrl = string.Empty;
        private string _propertyName = string.Empty;

        protected BaseDataService(string baseServiceUrl, string propertyName) {
            this._baseServiceUrl = baseServiceUrl;
            this._propertyName = propertyName;
			this.token = new CancellationToken();
			database = DependencyService.Get<IDatabaseConnection>().DbConnection();
			database.CreateTable<T>();
        }
        
        public async Task<IEnumerable<T>> PopulateDataOnlineAsync() {
			var collection = await QueryAppData(token);
			// Drop and recreate
			database.DropTable<T>();
			database.CreateTable<T>();
			SaveAllTs(collection);
            return collection;
        }

        public async Task<IEnumerable<T>> PopulateDataOfflineAsync()
		{
			// If already any items in the table, no need of loading from Internet
			if (database.Table<T>().Any())
			{
				var collection = OfflineQuery();
                return collection;
			}
			else
			{
				// If not connected, raise an error
				if (!App.IsConnected) throw new InvalidOperationException();
				var collection = await QueryAppData(token);
				SaveAllTs(collection);
                return collection;
			}
		}

        public void SaveAllTs(IEnumerable<T> Ts)
		{
			lock (collisionLock)
			{
				// In the database, save or update each item in the collection
				foreach (var feedT in Ts)
				{
					if (feedT.Id != 0)
					{
                        //TODO: so far doesn't need to update
                        //database.Update(feedT);
					}
					else
					{
                        //database.Insert(feedT);
					}
				}
			}
		}

		private async Task<IEnumerable<T>> QueryAppData(CancellationToken token)
		{
			try
			{
				var client = new HttpClient();
                var data = await client.GetAsync(new Uri(_baseServiceUrl), token);
				var strData = await data.Content.ReadAsStringAsync();
				var appData = AppData.FromJson(strData);
                var Ts = GetPropValue(appData, _propertyName);
                return Ts;
			}
			catch (OperationCanceledException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		// Query the table in the database
		private IEnumerable<T> OfflineQuery()
		{
			lock (collisionLock)
			{
				return database.Table<T>().AsEnumerable();
			}
		}

        public static IEnumerable<T> GetPropValue(object src, string propName)
		{
            var runTimeProp = src.GetType().GetRuntimeProperties().FirstOrDefault(i => i.Name == propName);
            if (runTimeProp != null)
            {
                return runTimeProp.GetValue(src) as IEnumerable<T>;
            }

            return null;
		}
    }
}

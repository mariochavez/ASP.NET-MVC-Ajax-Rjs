using System;
using System.Collections.Generic;
using DecisionesInteligentes.Rjs.Web.Models;

namespace DecisionesInteligentes.Rjs.Web
{
	public class DataService
	{
		public DataService ()
		{
		}
		
		public IList<DataValue> GetStates()
		{
			IList<DataValue> states = new List<DataValue>() {
				new DataValue { Id = 1, Value = "Baja California" },
				new DataValue { Id = 2, Value = "Jalisco" }
			};
			
			return states;
		}
		
		public IList<DataValue> GetCities(int id) 
		{
			IList<DataValue> cities = new List<DataValue>();
			
			if(id == 1) {
				cities = new List<DataValue>(){
					new DataValue { Id = 1, Value = "Tijuana" },
					new DataValue { Id = 2, Value = "Ensenada" }
				};
			}
			else if(id == 2)
			{
				cities = new List<DataValue>(){
					new DataValue { Id = 3, Value = "Guadalajara" },
					new DataValue { Id = 4, Value = "Pto. Vallarta" }
				};
			}
			
			return cities;
		}
	}
}


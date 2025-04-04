﻿using FirebaseAdmin;
using Google.Cloud.Firestore;
using MyWebApp.Firebase;

namespace MyWebApp.Models
{
	public class Condominium
	{
		public String Id { get; set; }
		public String Name { get; set; }
		public String Address { get; set; }
		public int Count { get; set; }
		public String Photo { get; set; }
	}

	public static class CondominiumHelper
	{
		public static async Task<List<Condominium>> getCondominiums()
		{
			List<Condominium> condominiumList = new List<Condominium>();

			Query query = FirestoreDb.Create(FirebaseAuthHelper.firebaseAppId).Collection("Condominium");
			QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

			foreach (var item in querySnapshot)
			{
				Dictionary<string, object> data = item.ToDictionary();

				condominiumList.Add(new Condominium
				{
					Name = data["Name"].ToString(),
					Address = data["Address"].ToString(),
					Count = Convert.ToInt32(data["Count"]),
					Photo = data["Photo"].ToString(),
				});
			}

			return condominiumList;
		}

		public static async Task<bool> saveCondominium(Condominium condominium)
		{
			try
			{
				DocumentReference docRef = await FirestoreDb.Create(FirebaseAuthHelper.firebaseAppId).Collection("Condominium").AddAsync(
					new Dictionary<string, object>
						{
							{"Name", condominium.Name },
							{"Address", condominium.Address },
							{"Count", condominium.Count },
							{"Photo", condominium.Photo },
						});

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}

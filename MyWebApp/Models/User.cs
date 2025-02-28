using Firebase.Auth;
using Google.Cloud.Firestore;
using MyWebApp.Firebase;
using MyWebApp.Misc;
using System.Xml.Linq;

namespace MyWebApp.Models
{
	public class UserModel
	{
		public string uuid { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public List<Propertie> Properties { get; set; }
	}

	public class Propertie
	{
		public string CondoName { get; set; }
		public int CondoNumber { get; set; }
	}

	public class UserHelper
	{
		public async Task<UserModel> getUserInfo(string email)
		{
			Query query = FirestoreDb.Create(FirebaseAuthHelper.firebaseAppId).Collection("User").WhereEqualTo("email", email);
			QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

			Dictionary<string, object> data = querySnapshot.Documents[0].ToDictionary();

			UserModel user = new UserModel
			{
				Email = data["email"].ToString(),
				Name = data["name"].ToString(),
				Type = data["type"].ToString(),
			};

			user.Properties = new List<Propertie>();


			try
			{
				List<Object> propertieList = (List<Object>)data["properties"];

				foreach (Object propertie in propertieList)
				{
					Dictionary<string, object> propertieData = (Dictionary<string, object>)propertie;

					user.Properties.Add(new Propertie
					{
						CondoName = propertieData["condo"].ToString(),
						CondoNumber = Convert.ToInt16(propertieData["number"])
					});
				}
			}
			catch
			{
			}

			return user;
		}

		public async void postUserWithEmailAndPassword(string email, string password, string displayName, string type, string selCondo, int selCondoNumber)
		{
			UserCredential userCredential = await FirebaseAuthHelper.setFirebaseAuthClient().CreateUserWithEmailAndPasswordAsync(email, password, displayName);

			List<Dictionary<string, object>> objectProperties = new List<Dictionary<string, object>>
				{
					new Dictionary<string, object>
					{
						{ "condo", selCondo },
						{ "number", selCondoNumber }
					}
				};

			DocumentReference docRef = await FirestoreDb.Create(FirebaseAuthHelper.firebaseAppId).Collection("User").AddAsync(
					new Dictionary<string, object>
						{
							{"email", email },
							{"name", displayName },
							{"type", type},
							{"properties", objectProperties }
						});

			EmailHelper.SendEmail(email, displayName, password, selCondo, selCondoNumber);
		}

	}
}

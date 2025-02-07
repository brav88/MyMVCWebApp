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
        public String Photo{ get; set; }
    }

    public class CondominiumHelper
    {
        public async Task<List<Condominium>> getCondominiums()
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
    }
}

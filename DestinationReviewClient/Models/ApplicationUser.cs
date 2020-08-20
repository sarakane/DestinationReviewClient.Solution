using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DestinationReviewClient.Models
{
  public class ApplicationUser
  {
    public ApplicationUser()
    {
      this.Reviews = new HashSet<Review>();
      this.Destinations = new HashSet<Destination>();
    }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
  
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<Destination> Destinations { get; set; }

    public static List<ApplicationUser> GetUsers()
    {
      var apiCallTask = ApiHelper.GetAllUsers();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<ApplicationUser> userList = JsonConvert.DeserializeObject<List<ApplicationUser>>(jsonResponse.ToString());
      
      return userList;
    }

    public static ApplicationUser GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetUser(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      ApplicationUser applicationUser = JsonConvert.DeserializeObject<ApplicationUser>(jsonResponse.ToString());

      return applicationUser;
    }

    public static void Post(ApplicationUser user)
    {
      string jsonUser = JsonConvert.SerializeObject(user);
      var apiCallTask = ApiHelper.PostUser(jsonUser);
    }

    public static void Authenticate(ApplicationUser user)
    {
      string jsonUser = JsonConvert.SerializeObject(user);
      var apiCallTask = ApiHelper.AuthenticateUser(jsonUser);
    }
  }
}
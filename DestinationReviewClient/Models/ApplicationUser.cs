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
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
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

  }
}
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DestinationReviewClient.Models
{
  public class Destination
  {
    public Destination()
    {
      this.Reviews = new HashSet<Review>();
      
    }
    public int DestinationId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public int ReviewNumber { get; set; }
    public double ReviewAverage { get; set; }
    public int UserId { get; set; }
    public ICollection<Review> Reviews {get; set;}
    public void GetReviewNumber()
    { 
      this.ReviewNumber = Reviews.Count;
    }

    public void GetReviewAverage() 
    { 
      if(Reviews.Count != 0)
      {
        double sum = 0;
        foreach(var review in Reviews)
        {
          sum += review.Rating;
        }
        this.ReviewAverage = sum/Reviews.Count;
      }
      else
      {
        this.ReviewAverage = (double)0;
      }  
    }

    public static List<Destination> GetDestinations()
    {
      var apiCallTask = ApiHelper.GetAllDestinations();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Destination> destinationList = JsonConvert.DeserializeObject<List<Destination>>(jsonResponse.ToString());
      
      return destinationList;
    }

    public static Destination GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetDestination(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Destination destination = JsonConvert.DeserializeObject<Destination>(jsonResponse.ToString());

      return destination;
    }

    public static void Post(Destination destination)
    {
      string jsonDestination = JsonConvert.SerializeObject(destination);
      var apiCallTask = ApiHelper.PostDestination(jsonDestination);
    }
  }
}
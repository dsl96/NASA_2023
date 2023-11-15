using GUI.services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace GUI.MVVM.Model
{
    public class AstroidResponse
    {
        [JsonProperty("Links")]
        public Link Links { get; set; }

        [JsonProperty("ElementCount")]
        public int ElementCount { get; set; }

        [JsonProperty("NearEarthObjects")]
        public Dictionary<string, List<NearEarthObject>> NearEarthObjects { get; set; }
    }

    public class NearEarthObject
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("NeoReferenceId")]
        public string NeoReferenceId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("NasaJplUrl")]
        public string NasaJplUrl { get; set; }

        [JsonProperty("AbsoluteMagnitudeH")]
        public double AbsoluteMagnitudeH { get; set; }

        [JsonProperty("EstimatedDiameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonProperty("IsPotentiallyHazardousAsteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }

        [JsonProperty("CloseApproachData")]
        public List<CloseApproachData> CloseApproachData { get; set; }

        [JsonProperty("IsSentryObject")]
        public bool IsSentryObject { get; set; }
    }

    public class CloseApproachData
    {
        [JsonProperty("CloseApproachDate")]
        public string CloseApproachDate { get; set; }

        [JsonProperty("CloseApproachDateFull")]
        public string CloseApproachDateFull { get; set; }

        [JsonProperty("EpochDateCloseApproach")]
        public long EpochDateCloseApproach { get; set; }

        [JsonProperty("RelativeVelocity")]
        public RelativeVelocity RelativeVelocity { get; set; }

        [JsonProperty("MissDistance")]
        public MissDistance MissDistance { get; set; }

        [JsonProperty("OrbitingBody")]
        public string OrbitingBody { get; set; }
    }

    public class Link
    {
        [JsonProperty("Self")]
        public string Self { get; set; }

        [JsonProperty("Next")]
        public string Next { get; set; }

        [JsonProperty("Previous")]
        public string Previous { get; set; }
    }

    public class EstimatedDiameter
    {
        [JsonProperty("Kilometers")]
        public Kilometers Kilometers { get; set; }

        [JsonProperty("Meters")]
        public Meters Meters { get; set; }

        [JsonProperty("Miles")]
        public Miles Miles { get; set; }

        [JsonProperty("Feet")]
        public Feet Feet { get; set; }
    }

    public class Kilometers
    {
        [JsonProperty("EstimatedDiameterMin")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("EstimatedDiameterMax")]
        public double EstimatedDiameterMax { get; set; }
    }

    public class Meters
    {
        [JsonProperty("EstimatedDiameterMin")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("EstimatedDiameterMax")]
        public double EstimatedDiameterMax { get; set; }
    }

    public class Miles
    {
        [JsonProperty("EstimatedDiameterMin")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("EstimatedDiameterMax")]
        public double EstimatedDiameterMax { get; set; }
    }

    public class Feet
    {
        [JsonProperty("EstimatedDiameterMin")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("EstimatedDiameterMax")]
        public double EstimatedDiameterMax { get; set; }
    }

    public class RelativeVelocity
    {
        [JsonProperty("KilometersPerSecond")]
        public string KilometersPerSecond { get; set; }

        [JsonProperty("KilometersPerHour")]
        public string KilometersPerHour { get; set; }

        [JsonProperty("MilesPerHour")]
        public string MilesPerHour { get; set; }
    }

    public class MissDistance
    {
        [JsonProperty("Astronomical")]
        public string Astronomical { get; set; }

        [JsonProperty("Lunar")]
        public string Lunar { get; set; }

        [JsonProperty("Kilometers")]
        public string Kilometers { get; set; }

        [JsonProperty("Miles")]
        public string Miles { get; set; }
    }
}

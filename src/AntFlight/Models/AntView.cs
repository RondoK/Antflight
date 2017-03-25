using System;
using System.Collections.Generic;
using System.Linq;
using AntFlight.Models.Ants;

namespace AntFlight.Models
{
    public class AntView
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Subgenus { get; set;}
        public string Genus { get; set; }
        public string Subfamilie { get; set; }
        public OriginalFlightTime OriginalFlightTime { get; set; }

        public AntView ()
        { }

        public AntView (Ant ant , 
                        Subgenus subgenus = null , 
                        Genus genus = null , 
                        Subfamilie subfamilie  = null , 
                        OriginalFlightTime OFT = null )
        {
            Id = ant.Id;
            Species = ant.SpeciesName;
            Subgenus = subgenus.SubgenusName;
            Genus = genus.GenusName;
            Subfamilie = subfamilie.SubfamilieName;
            OriginalFlightTime = OFT; 
        }

        public AntView (Ant ant,
                        string subgenus = null ,
                        string genus = null ,
                        string subfamilie = null ,
                        OriginalFlightTime OFT = null)
        {
            Id = ant.Id;
            Species = ant.SpeciesName;
            Subgenus = subgenus;
            Genus = genus;
            Subfamilie = subfamilie;
            OriginalFlightTime = OFT;
        }

        public AntView (int AntId ,
                        string species,
                        string subgenus = null,
                        string genus = null, 
                        string subfamilie = null,
                        OriginalFlightTime OFT = null)
        {
            Id = AntId;
            Species = species;
            Subgenus = subgenus;
            Genus = genus;
            Subfamilie = subfamilie;
            OriginalFlightTime = OFT;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace PopulateDatabaseFromRescueGroupAPI.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        public int PetId { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return $"PictureId: {PictureId}, PetId: {PetId}, Url: {Url}";
        }
    }
}
